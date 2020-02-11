using FluentValidation.Results;
using System.Web.Mvc;
using TheatreTicketBookingSystem.Helpers;
using TheatreTicketBookingSystem.Logic;
using TheatreTicketBookingSystem.Models;
using TheatreTicketBookingSystem.ValidateModel;

namespace TheatreTicketBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public ActionResult TicketDate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TicketDate(FormCollection collection)
        {
            var Bookingdate = collection["date"];

            // Check if date is valid on the server incase the user disabled javascript
            if (Helper.IsDateValid(Bookingdate))
            {
                if (DateTicket.GetNumberOfTickets(Bookingdate) < 20)
                {
                    return RedirectToAction("Book", new { date = Bookingdate });
                }
                else
                {
                    return RedirectToAction("Error", new { erroMsg = "Sorry, We don't have available tickets for the date you've chosen" });
                } 
            }

            return View();
        }

        [HttpGet]
        public ActionResult Book(string date)
        {
            ViewBag.Date = date;
            ViewBag.Quantity = Helper.GetQuantity(DateTicket.GetNumberOfTickets(date));
            return View();
        }

        [HttpPost]
        public ActionResult Book(Person person)
        {
            if (IsModelValid(person))
            {
                if (DateTicket.GetNumberOfTickets(person.Date) + person.Quantity <= 20)
                {
                    Booking.BookTicket(person);
                    return RedirectToAction("Successfull", person);
                }

                return RedirectToAction("Error", new { erroMsg = "some users might have made a booking while you busy capturing details" });
            }

            ViewBag.Quantity = Helper.GetQuantity(DateTicket.GetNumberOfTickets(Request.QueryString["date"]));
            return View();
        }

        [HttpGet]
        public ActionResult Error(string erroMsg)
        {
            ViewBag.errorMsg = erroMsg;
            return View();
        }

        [HttpGet]
        public ActionResult Successfull(Person user)
        {
            return View(user);
        }

        public bool IsModelValid(Person person)
        {
            ValidatePerson validatePerson = new ValidatePerson();
            ValidationResult model = validatePerson.Validate(person);

            if (!model.IsValid)
            {
                foreach (ValidationFailure error in model.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return model.IsValid;
        }
    }
}