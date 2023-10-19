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
    public class ShowRepo
    {
        private List<Show> shows; // List of shows
        private string connectionString; // Connection string for database

        public ShowRepo()
        {
            // Create a new list of shows 
            shows = new List<Show>();

            // Load the database connection string from appsettings.json
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = config.GetConnectionString("MyDBConnection");
        }

        public void AddShow(Movie movie, DateTime startTime, Cinema cinema)
        {
            // Create a new show 
            Show newShow = new Show(movie, startTime, cinema);
            // Add the new show to list of shows
            shows.Add(newShow);

            Debug.WriteLine($"{newShow.Movie.Title} går i {newShow.Cinema.CinemaName} sal {newShow.Cinema.CinemaHall}" +
                $" kl. {newShow.StartTime} og tager {newShow.RunTimeTotal} minutter.");

            // Add the new show to the database
            AddShowToDatabase(newShow);
        }
        public void AddShowToBooking(Movie movie, DateTime startTime, Cinema cinema, int showID)
        {
            // Create a new show 
            Show newShow = new Show(movie, startTime, cinema, showID);
            // Add the new show to list of shows
            shows.Add(newShow);
        }

        public Show GetAddedShow()
        {
            return shows.Last();
        }
        public void AddShowToDatabase(Show show)
        {

            try {
                using (SqlConnection con = new SqlConnection(connectionString)) {
                    con.Open();

                    // Create an INSERT command to add the show to the database
                    SqlCommand cmd = new SqlCommand("spInsertShow", con);
                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartTime", show.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", show.EndTime);
                    cmd.Parameters.AddWithValue("@RunTimeTotal", show.RunTimeTotal);
                    cmd.Parameters.AddWithValue("@MovieID", show.Movie.GeneratedMovieID);
                    cmd.Parameters.AddWithValue("@CinemaID", show.Cinema.GeneratedCinemaID);

                    // Adding the output parameters
                    cmd.Parameters.Add("@ShowID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    // Retrieve the generated ShowID using the Stored Procedure output
                    show.GeneratedShowID = (int)cmd.Parameters["@ShowID"].Value;
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
