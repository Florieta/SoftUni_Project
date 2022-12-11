using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Constants;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Core.Models.Car;
using System.Security.Claims;

namespace RentalCarManagementSystem.Web.Areas.Admin.Controllers
{
    public class CarController : BaseController
    {

        private readonly ICarServiceAdmin carServiceAdmin;

        private readonly ICarService carService;

        public CarController(ICarServiceAdmin carServiceAdmin, ICarService carService)
        {
            this.carServiceAdmin = carServiceAdmin;
            this.carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            CreateCarInputModel model = new CreateCarInputModel()
            {
                Categories = await carService.GetCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarInputModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return View(carModel);
            }

            try
            {
                await carServiceAdmin.CreateCar(carModel);
                TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRecord;
                return RedirectToAction(nameof(All));
            }
            catch
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                return View(carModel);
            }
        }

       

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await carServiceAdmin.RemoveCarAsync(id);
                TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRemoving;
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                return RedirectToAction("Home", "Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await carService.Exists(id)) == false)
            {
                ViewData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                return RedirectToAction(nameof(All));
            }

            var car = await carServiceAdmin.FindCarAsync(id);
            var categoryId = await carServiceAdmin.GetCarCategoryIdAsync(id);

            var model = new EditCarViewModel()
            {
                Id = id,
                Make = car.Make,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                CategoryId = categoryId,
                MakeYear = car.MakeYear,
                RegNumber = car.RegNumber,
                Color = car.Color,
                GearBox = car.GearBox,
                DailyRate = car.DailyRate,
                Categories = await carService.GetCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCarViewModel editModel)
        {
            if (id != editModel.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await carService.Exists(editModel.Id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.CarError;
                editModel.Categories = await carService.GetCategoriesAsync();

                return View(editModel);
            }

            if ((await carServiceAdmin.CategoryExistsById(editModel.CategoryId)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.CategoryError;
                editModel.Categories = await carServiceAdmin.GetCategoriesAsync();

                return View(editModel);
            }

            if (ModelState.IsValid == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                editModel.Categories = await carServiceAdmin.GetCategoriesAsync();

                return View(editModel);
            }

            await carServiceAdmin.Edit(editModel.Id, editModel);
            TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulEdittingCar;
            return RedirectToAction("All", "Car");
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllCarsQueryModel query)
        {
            var result = await carService.GetAllCarsAsync(
                query.SearchMake,
                query.SearchModel,
                query.SearchRegNumber);

            query.Cars = result;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if ((await carService.Exists(id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                return RedirectToAction(nameof(All));
            }
            var carModel = await carService.CarDetailsById(id);

            return View(carModel);
        }
    }
}
