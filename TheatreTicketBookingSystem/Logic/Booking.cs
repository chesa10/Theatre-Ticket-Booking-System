using DatabaseAccessLayer;
using System.Collections.Generic;
using System.Data.SqlClient;
using TheatreTicketBookingSystem.Models;

namespace TheatreTicketBookingSystem.Logic
{
    public class Booking
    {
        public static int BookTicket(Person person)
        {
            DataAccess dataAccess = new DataAccess();
            var result = dataAccess.ExecuteCommand("InsertIntoPerson", SetSqlParameters(person));
            return result;
        }

        private static Dictionary<string, SqlParameter> SetSqlParameters(Person person)
        {
            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();

            cmdParameters["bookingDate"] = new SqlParameter("bookingDate", person.Date);
            cmdParameters["name"] = new SqlParameter("name", person.Name);
            cmdParameters["email"] = new SqlParameter("email", person.Email);
            cmdParameters["quantity"] = new SqlParameter("quantity", person.Quantity);

            return cmdParameters;
        }
    }
}