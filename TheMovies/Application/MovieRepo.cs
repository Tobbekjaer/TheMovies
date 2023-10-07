using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;
using System.Windows;
using System.DirectoryServices;

namespace TheMovies.Application
{
    public class MovieRepo
    {

        private List<Movie> movies; // List of movies
        private string connectionString; // Connection string for database

        public MovieRepo()
        {
            // Create a new list of movies 
            movies = new List<Movie>();

            // Load the database connection string from appsettings.json
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = config.GetConnectionString("MyDBConnection");
        }

        public void AddMovie(string title, int duration, string genre)
        {
            // Create a new movie 
            Movie newMovie = new Movie(title, duration, genre);
            // Add the new movie to list of movies
            movies.Add(newMovie);
            // Add the new movie to the database
            AddMovieToDatabase(title, duration, genre);
        }

        public void AddMovieToDatabase(string title, int duration, string genre)
        {
            try {
                using (SqlConnection con = new SqlConnection(connectionString)) {
                    con.Open();

                    // Create an INSERT command to add the movie to the database
                    SqlCommand cmd = new SqlCommand("INSERT INTO tmMOVIE (Title, Duration, Genre) " +
                        "VALUES (@Title, @Duration, @Genre);", con);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Duration", duration);
                    cmd.Parameters.AddWithValue("@Genre", genre);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                MessageBox.Show($"{title} blev tilføjet.");
            }
        }

    }
}
