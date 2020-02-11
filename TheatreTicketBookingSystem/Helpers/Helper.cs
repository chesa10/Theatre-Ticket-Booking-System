using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TheatreTicketBookingSystem.Helpers
{
    public static class Helper
    {
        /// <summary>
        /// Calculate dropdown values based on available tickets for the date
        /// </summary>
        /// <param name="numTickets"></param>
        /// <returns>list of dropdown values</returns>
        public static List<SelectListItem> GetQuantity(int numTickets)
        {
            int availableTickets = (20 - numTickets) + 1;
            List<SelectListItem> List = new List<SelectListItem>();
            for (int i = 1; i < availableTickets; i++)
            {
                List.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            return List;
        }

        /// <summary>
        /// Server side validation to incase the user disabled javascript
        /// </summary>
        /// <param name="numTickets"></param>
        /// <returns></returns>
        public static bool IsDateValid(string date)
        {
            DateTime dateTime;
            return DateTime.TryParse(date, out dateTime);
        }
    }
}