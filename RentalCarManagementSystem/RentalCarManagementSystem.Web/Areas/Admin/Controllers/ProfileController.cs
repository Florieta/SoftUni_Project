using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Constants;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;

namespace RentalCarManagementSystem.Web.Areas.Admin.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IProfileServiceAdmin userService;

        public ProfileController(IProfileServiceAdmin userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> MyProfile()
        {
            var profileModel = await userService.GetUserByUsernameAsync(User.Identity.Name);

            return View(profileModel);
        }
        public async Task<IActionResult> Edit()
        {
            var user = await userService.GetUserByUsernameAsync(User.Identity.Name);

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
        public async Task<IActionResult> Edit(EditUserProfileViewModel model, string id)
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

            if (await userService.EditProfile(editModel, id))
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
