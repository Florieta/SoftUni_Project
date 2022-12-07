using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Constants;

namespace RentalCarManagementSystem.Web.Controllers
{
    [Authorize(Roles = $"{UserConstants.Roles.Administrator}, {UserConstants.Roles.Agent}")]
    public class BaseController : Controller
    {
       
    }
}
