using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Constants;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Models.User;
using static RentalCarManagementSystem.Core.Constants.UserConstants;

namespace RentalCarManagementSystem.Web.Controllers
{
    
    public class UserController : BaseController
    {
     
        private readonly IUserService userService;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> MyProfile()
        {
            var userName = User?.Identity?.Name;
            if (userName == null)
            {
                ViewData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
            }
            var profileModel = await userService.GetUserByUsernameAsync(userName);

            return View(profileModel);
        }
        public async Task<IActionResult> Edit()
        {
            var userName = User?.Identity?.Name;
            if (userName == null)
            {
                ViewData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
            }
            var user = await userService.GetUserByUsernameAsync(userName);

            EditUserProfileViewModel editModel = new EditUserProfileViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                Address = user.Address,
                JobPosition = user.JobPosition
            };

            return View(editModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var editModel = new EditUserProfileViewModel()
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                ImageUrl = model.ImageUrl,
                JobPosition = model.JobPosition,
                Address = model.Address
            };

            if (await userService.EditProfile(editModel))
            {
                ViewData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRecord;
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
            }

            return RedirectToAction(nameof(MyProfile));
        }
    }
}
