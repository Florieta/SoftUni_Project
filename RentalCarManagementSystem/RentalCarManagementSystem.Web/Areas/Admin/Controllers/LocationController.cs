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
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
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

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await locationService.RemoveLocationAsync(id);
                TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRemoving;
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
            if ((await locationService.IsExisted(id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.LocationError;

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
                TempData[MessageConstant.ErrorMessage] = MessageConstant.LocationError;

                return View(editModel);
            }

            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;

                return View(editModel);
            }

            await locationService.Edit(editModel.Id, editModel);
            TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulEdittingLocation;
            return RedirectToAction(nameof(All));
        }
    }
}
