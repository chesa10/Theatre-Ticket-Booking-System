using DatabaseAccessLayer;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TheatreTicketBookingSystem.Logic
{
    public static class DateTicket
    {
        public static int GetNumberOfTickets(string date)
        {
            DataAccess dataAccess = new DataAccess();

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["date"] = new SqlParameter("date", date);

            return dataAccess.ExecuteCommand("GetNumberOfTicketsByDate", cmdParameters);
        }
    }
}