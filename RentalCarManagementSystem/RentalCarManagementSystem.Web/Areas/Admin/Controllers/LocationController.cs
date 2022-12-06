using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Constants;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;

namespace RentalCarManagementSystem.Web.Areas.Admin.Controllers
{
    public class LocationController : BaseController
    {
        private readonly ILocationServiceAdmin locationService;

        public LocationController(ILocationServiceAdmin locationService)
        {
            this.locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await locationService.GetAllAsync();

            return View(model);
        }


        [HttpGet]
        public IActionResult Add()
        {
            CreateLocationViewModel model = new CreateLocationViewModel();
          
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateLocationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await locationService.CreateLocation(model);
                TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRecord;
                return Redirect(nameof(All));
            }
            catch
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                return View(model);
            }
        }

        //public async Task<IActionResult> Remove(int id)
        //{
        //    try
        //    {
        //        await carServiceAdmin.RemoveCarAsync(id);
        //        TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRecord;
        //        return RedirectToAction("All", "Car");
        //    }
        //    catch (Exception)
        //    {
        //        TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
        //        return RedirectToAction("Home", "Index");
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await locationService.IsExisted(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var location = await locationService.FindLocationAsync(id);
            

            var model = new LocationViewModel()
            {
                Id = id,
                LocationName = location.LocationName,
                Address = location.Address
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, LocationViewModel editModel)
        {
            if (id != editModel.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await locationService.IsExisted(editModel.Id)) == false)
            {
                ModelState.AddModelError("", "Location does not exist");

                return View(editModel);
            }

            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            await locationService.Edit(editModel.Id, editModel);
            TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRecord;
            return RedirectToAction(nameof(All));
        }
    }
}
