using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Constants;

namespace RentalCarManagementSystem.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
