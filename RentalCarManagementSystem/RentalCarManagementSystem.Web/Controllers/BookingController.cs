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
        public async Task<IActionResult> Add(int Id)
        {
            var car = await bookingService.GetCarById(Id);

            BookingFormViewModel bookingModel = new()
            {
                DailyRate = car.DailyRate,
                PickUpLocations = await bookingService.GetLocationsAsync(),
                DropOffLocations = await bookingService.GetLocationsAsync(),
                Insurance = await bookingService.GetInsurancesAsync()
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
                TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRecord;
                return RedirectToAction("All", "Car");
            }
            catch
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await bookingService.Exists(id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                return RedirectToAction("All", "Booking");
            }

            var booking = await bookingService.FindBookingById(id);
            var customer = await bookingService.FindCustomerById(booking.CustomerId);

            var model = new EditBookingViewModel()
            {
                FullName = booking.Customer.FullName,
                Address = booking.Customer.Address,
                PhoneNumber = booking.Customer.PhoneNumber,
                Email = booking.Customer.Email,
                IdCardNumber = booking.Customer.IdCardNumber,
                DriverLicenseNumber = booking.Customer.DriverLicenseNumber,
                Gender = booking.Customer.Gender,
                PickUpDateAndTime = booking.PickUpDateAndTime,
                DropOffDateAndTime = booking.DropOffDateAndTime,
                Duration = booking.Duration,
                PickUpLocations = await bookingService.GetLocationsAsync(),
                DropOffLocations = await bookingService.GetLocationsAsync(),
                Insurance = await bookingService.GetInsurancesAsync(),
                TotalAmount = booking.TotalAmount,
                PaymentType = booking.PaymentType
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditBookingViewModel editModel)
        {
            if (id != editModel.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await bookingService.Exists(editModel.Id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.BookingError;


                return View(editModel);
            }

            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            await bookingService.Edit(editModel.Id, editModel);
            TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulRecord;
            return RedirectToAction("All", "Booking");
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllBookingsQueryModel query)
        {
            var result = await bookingService.GetAllBookingsAsync(
                query.SearchTerm);

            query.Bookings = result;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AllCheckIns([FromQuery] AllBookingsQueryModel query)
        {
            var result = await bookingService.AllCheckIns(
                query.SearchTerm);

            query.Bookings = result;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> AllCheckOuts([FromQuery] AllBookingsQueryModel query)
        {
            var result = await bookingService.AllCheckOuts(
                query.SearchTerm);

            query.Bookings = result;

            return View(query);
        }

        [HttpPost]
        public async Task<IActionResult> CheckIn(int id)
        {
            await bookingService.CheckIn(id);
            TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulCheckedIn;
            return RedirectToAction("All", "Booking");
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(int id)
        {
            await bookingService.CheckOut(id);
            TempData[MessageConstant.SuccessMessage] = MessageConstant.SuccessfulCheckedOut;
            return RedirectToAction("All", "Booking");
        }


        public async Task<IActionResult> Details(int id)
        {
            if ((await bookingService.Exists(id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.OccurredError;
                return RedirectToAction(nameof(All));
            }

            var model = await bookingService.BookingDetailsById(id);

            return View(model);
        }
    }
}
