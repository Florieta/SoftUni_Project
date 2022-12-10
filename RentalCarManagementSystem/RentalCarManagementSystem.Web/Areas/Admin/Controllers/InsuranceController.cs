using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Constants;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;

namespace RentalCarManagementSystem.Web.Areas.Admin.Controllers
{
    public class InsuranceController : BaseController
    {
        private readonly IInsuranceServiceAdmin insuranceService;

        public InsuranceController(IInsuranceServiceAdmin insuranceService)
        {
            this.insuranceService = insuranceService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await insuranceService.GetAllAsync();

            return View(model);
        }


        [HttpGet]
        public IActionResult Add()
        {
            CreateInsuranceViewModel model = new CreateInsuranceViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateInsuranceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                return View(model);
            }

            try
            {
                await insuranceService.CreateInsurance(model);
                TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRecord;
                return Redirect(nameof(All));
            }
            catch
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                return View(model);
            }
        }

        public async Task<IActionResult> Remove(int insuranceCode)
        {
            try
            {
                await insuranceService.RemoveInsuranceAsync(insuranceCode);
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
        public async Task<IActionResult> Edit(int InsuranceCode)
        {
            if ((await insuranceService.IsExisted(InsuranceCode)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.InsuranceError;

                return RedirectToAction(nameof(All));
            }

            var insurance = await insuranceService.FindInsuranceAsync(InsuranceCode);

            var model = new InsuranceViewModel()
            {
                TypeOfInsurance = insurance.TypeOfInsurance,
                CostPerDay = insurance.CostPerDay
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int InsuranceCode, InsuranceViewModel editModel)
        {
            if (InsuranceCode != editModel.InsuranceCode)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await insuranceService.IsExisted(InsuranceCode)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.InsuranceError;

                return View(editModel);
            }

            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;

                return View(editModel);
            }

            await insuranceService.Edit(editModel.InsuranceCode, editModel);
            TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulEdittingInsurance;
            return RedirectToAction(nameof(All));
        }
    }
}
