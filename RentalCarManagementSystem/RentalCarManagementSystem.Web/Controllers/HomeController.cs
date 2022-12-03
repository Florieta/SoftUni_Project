using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Web.Models;
using System.Diagnostics;

namespace RentalCarManagementSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IScheduleService scheduleService;

        public HomeController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }


        public async Task<IActionResult> Index()
        {
            var model = await scheduleService.TotalAvailableCarsAsync();

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}