using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;
using TheatreTicketBookingSystem.ValidateModel;

namespace TheatreTicketBookingSystem.Models
{
    [Validator(typeof(ValidatePerson))]
    public class Person
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Quantity { get; set; }
    }
}