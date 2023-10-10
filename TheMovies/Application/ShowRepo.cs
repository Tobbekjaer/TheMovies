using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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

        public void AddShow(Movie movie, DateTime startTime, DateTime endTime, int runTimeTotal, Cinema cinema)
        {
            // Create a new movie 
            Show newShow = new Show(movie, startTime, endTime, runTimeTotal, cinema);
            // Add the new show to list of shows
            shows.Add(newShow);
            // Add the new show to the database
            // AddShowToDatabase(newShow);
        }

        //public void AddShowToDatabase(Show show)
        //{
        //    try {
        //        using (SqlConnection con = new SqlConnection(connectionString)) {
        //            con.Open();

        //            // Create an INSERT command to add the show to the database
        //            SqlCommand cmd = new SqlCommand("INSERT INTO vwViewAllShows (Title, Duration, Genre) " +
        //                "VALUES (@Title, @Duration, @Genre);", con);
        //            cmd.Parameters.AddWithValue("@Title", title);
        //            cmd.Parameters.AddWithValue("@Duration", duration);
        //            cmd.Parameters.AddWithValue("@Genre", genre);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex) {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally {
        //        MessageBox.Show($"{title} blev tilføjet.");
        //    }
        //}

    }
}
