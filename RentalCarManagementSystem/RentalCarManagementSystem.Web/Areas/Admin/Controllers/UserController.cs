using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentalCarManagementSystem.Core.Constants;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Infrastructure.Models.Identity;

namespace RentalCarManagementSystem.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserServiceAdmin userService;
        private readonly IMapper mapper;
        public UserController(RoleManager<IdentityRole> roleManager,
           UserManager<ApplicationUser> userManager, IUserServiceAdmin userService,
           IMapper mapper)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.userService = userService;
            this.mapper = mapper;
        }

       
        public async Task<IActionResult> Roles(string id)
        {
            var user = await userService.GetUserByIdRoles(id);

            ViewBag.RoleItems = roleManager.Roles
                .ToList()
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Name,
                    Selected = userManager.IsInRoleAsync(user, x.Name).Result
                })
                .ToList();

            var model = mapper.Map<UserRolesViewModel>(user);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Roles(UserRolesViewModel model)
        {
            var user = await userService.GetUserByIdRoles(model.Id);

            var userRoles = await userManager.GetRolesAsync(user);

            await userManager.RemoveFromRolesAsync(user, userRoles);

            if (model.RoleNames?.Length > 0)
            {
                await userManager.AddToRolesAsync(user, model.RoleNames);
            }

            return Redirect("/Admin/User/UserManage");
        }

       
        public async Task<IActionResult> UserManage(int pageNumber)
        {
            var model = await userService.GetAllUsersForManage();

            return View(model);
        }

        
        public async Task<IActionResult> CreateRole()
        {
            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "User"
            });

            return Redirect("/");
        }

        
        public async Task<IActionResult> Edit(string id)
        {
            var editModel = await userService.GetUserByIdEditAsync(id);

            var viewModel = mapper.Map<EditUserViewModel>(editModel);

            return View(viewModel);
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var editModel = mapper.Map<EditUserViewModel>(model);

            if (await userService.UpdateUser(editModel))
            {
                ViewData[MessageConstant.SuccessMessage] = MessageConstant.SuccessMessage;
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
            }

            return View(model);
        }
    }
}
