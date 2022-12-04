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
        public IActionResult CreateCategory()
        {
            CreateCategoryInputModel model = new CreateCategoryInputModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryInputModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryModel);
            }

            try
            {
                await categoryServiceAdmin.CreateCategory(categoryModel);
                ViewData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRecord;
                return RedirectToAction("All", "Car");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong!");
                ViewData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                return View(categoryModel);
            }
        }
    }
}
