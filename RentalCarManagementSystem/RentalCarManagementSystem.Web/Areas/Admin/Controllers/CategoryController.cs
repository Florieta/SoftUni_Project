using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Constants;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;

namespace RentalCarManagementSystem.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryServiceAdmin categoryServiceAdmin;

        public CategoryController(ICategoryServiceAdmin categoryServiceAdmin)
        {
            this.categoryServiceAdmin = categoryServiceAdmin;

        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await categoryServiceAdmin.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CreateCategoryInputModel model = new CreateCategoryInputModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryInputModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryModel);
            }

            try
            {
                await categoryServiceAdmin.CreateCategory(categoryModel);
                ViewData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRecord;
                return Redirect("/");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong!");
                ViewData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                return View(categoryModel);
            }
        }

        public async Task<IActionResult> Remove(int Id)
        {
            try
            {
                await categoryServiceAdmin.RemoveCategoryAsync(Id);
                TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRecord;
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                return RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await categoryServiceAdmin.IsExisted(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var category = await categoryServiceAdmin.FindCategoryAsync(id);


            var model = new CategoryViewModel()
            {
                CategoryName = category.CategoryName,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, CategoryViewModel editModel)
        {
            if (Id != editModel.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await categoryServiceAdmin.IsExisted(editModel.Id)) == false)
            {
                ModelState.AddModelError("", "Category does not exist");

                return View(editModel);
            }

            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            await categoryServiceAdmin.Edit(editModel.Id, editModel);
            TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRecord;
            return RedirectToAction(nameof(All));
        }
    }
}
