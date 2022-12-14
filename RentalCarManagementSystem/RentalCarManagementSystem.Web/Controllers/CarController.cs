using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Constants;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Models.Car;

namespace RentalCarManagementSystem.Web.Controllers
{
   
    public class CarController : BaseController
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
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
