using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;
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
                return RedirectToAction("All", "Car");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View(carModel);
            }
        }

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await carServiceAdmin.RemoveCarAsync(id);
                return RedirectToAction("All", "Car");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return RedirectToAction("Home", "Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await carService.Exists(id)) == false)
            {
                return RedirectToAction("All", "Car");
            }


            //return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });


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
                ModelState.AddModelError("", "Car does not exist");
                editModel.Categories = await carService.GetCategoriesAsync();

                return View(editModel);
            }

            if ((await carServiceAdmin.CategoryExists(editModel.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(editModel.CategoryId), "Category does not exist");
                editModel.Categories = await carServiceAdmin.GetCategoriesAsync();

                return View(editModel);
            }

            if (ModelState.IsValid == false)
            {
                editModel.Categories = await carServiceAdmin.GetCategoriesAsync();

                return View(editModel);
            }

            await carServiceAdmin.Edit(editModel.Id, editModel);

            return RedirectToAction("All", "Car");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await carService.GetAllCarsAsync();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var carModel = await carService.CarDetailsById(id);

            return View(carModel);
        }
    }
}
