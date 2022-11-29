using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Constants;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Models.Car;

namespace RentalCarManagementSystem.Web.Controllers
{
   
    public class CarController : Controller
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
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
