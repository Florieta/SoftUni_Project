using Microsoft.AspNetCore.Mvc;

namespace RentalCarManagementSystem.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
