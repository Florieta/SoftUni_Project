using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RentalCarManagementSystem.Core.Constants;


namespace RentalCarManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = UserConstants.Roles.Administrator)]

    public class BaseController : Controller
    {

    }
}
