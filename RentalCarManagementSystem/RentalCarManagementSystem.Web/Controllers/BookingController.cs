using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCarManagementSystem.Core.Constants;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Models.Booking;
using System.Security.Claims;

namespace RentalCarManagementSystem.Web.Controllers
{
    
    public class BookingController : BaseController
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            BookingFormViewModel bookingModel = new()
            {
                PickUpLocations = await bookingService.GetLocationsAsync(),
                DropOffLocations = await bookingService.GetLocationsAsync(),
                Insurances = await bookingService.GetInsurancesAsync()
            };


            return View(bookingModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookingFormViewModel model, [FromRoute] int Id)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                await bookingService.Create(model, Id, userId);

                return RedirectToAction("All", "Car");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }

       

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await bookingService.GetAllBookingsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AllCheckIns()
        {
            var model = await bookingService.GetAllCheckInsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AllCheckOuts()
        {
            var model = await bookingService.GetAllCheckOutsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CheckIn(int id)
        {
            await bookingService.CheckIn(id);

            return RedirectToAction("All", "Booking");
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(int id)
        {
            await bookingService.CheckOut(id);

            return RedirectToAction("All", "Booking");
        }

        
        public async Task<IActionResult> Details(int id)
        {
            if ((await bookingService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await bookingService.BookingDetailsById(id);

            return View(model);
        }
    }
}
