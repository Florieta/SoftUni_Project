using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Contracts;

namespace RentalCarManagementSystem.Web.Areas.Admin.Controllers
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

    }
}
