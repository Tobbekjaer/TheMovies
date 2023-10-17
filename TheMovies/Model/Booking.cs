using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class Booking
    {
        public int TicketAmount { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Show Show { get; set; }
        public int GeneratedBookingID { get; set; }

        public Booking(int ticketAmount, string email, string phone, Show show)
        {
            TicketAmount = ticketAmount;
            Email = email;
            Phone = phone;
            Show = show;
        }


    }
}
