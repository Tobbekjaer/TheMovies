using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheMovies.Model;

namespace TheMovies.Application
{
    public class BookingRepo
    {
        private List<Booking> bookings; // List of bookings
        private string connectionString; // Connection string for database

        public BookingRepo()
        {
            // Create a new list of bookings 
            bookings = new List<Booking>();

            // Load the database connection string from appsettings.json
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = config.GetConnectionString("MyDBConnection");
        }

        public void AddBooking(int ticketNumber, string email, string phone, Show show)
        {
            // Create a new booking 
            Booking newBooking = new Booking(ticketNumber, email, phone, show);
            // Add the new booking to list of bookings
            bookings.Add(newBooking);

            Debug.WriteLine($"{newBooking.TicketAmount} tickets has been reserved for {newBooking.Show.Movie.Title}" +
                $" in {newBooking.Show.Cinema.CinemaName} in cinema hall {newBooking.Show.Cinema.CinemaHall}");

            // Add the new booking to the database
            // AddBookingToDatabase(newBooking);
        }

        public void AddBookingToDatabase(Booking booking)
        {

            try {
                using (SqlConnection con = new SqlConnection(connectionString)) {
                    con.Open();

                    // Create an INSERT command to add the booking to the database
                    SqlCommand cmd = new SqlCommand("spInsertBooking", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@StartTime", show.StartTime);
                    //cmd.Parameters.AddWithValue("@EndTime", show.EndTime);
                    //cmd.Parameters.AddWithValue("@RunTimeTotal", show.RunTimeTotal);
                    //cmd.Parameters.AddWithValue("@MovieID", show.Movie.GeneratedMovieID);
                    //cmd.Parameters.AddWithValue("@CinemaID", show.Cinema.GeneratedCinemaID);

                    // Adding the output parameters
                    cmd.Parameters.Add("@BookingID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    // Retrieve the generated BookingID using the Stored Procedure output
                    booking.GeneratedBookingID = (int)cmd.Parameters["@BookingID"].Value;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                // MessageBox.Show($"{title} blev tilføjet.");
            }
        }
    }
}
