﻿using Microsoft.Extensions.Configuration;
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

        public void AddMovie(string title, int duration, string genre, string director, DateTime premiereDate)
        {
            // Create a new movie 
            Movie newMovie = new Movie(title, duration, genre, director, premiereDate); 
            // Add the new movie to list of movies
            movies.Add(newMovie);
            // Add the new movie to the database
            AddMovieToDatabase(newMovie);
        }

        public void AddMovieToBooking(string title)
        {
            // Create a new movie 
            Movie newMovie = new Movie(title);
            // Add the new movie to list of movies
            movies.Add(newMovie);
        }

        public Movie GetAddedMovie()
        {
            return movies.Last();
        }

        public void AddMovieToDatabase(Movie movie)
        {
            try {
                using (SqlConnection con = new SqlConnection(connectionString)) {
                    con.Open();

                    // Create an INSERT command to add the movie to the database

                    SqlCommand cmd = new SqlCommand("spInsertMovie", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", movie.Title);
                    cmd.Parameters.AddWithValue("@Duration", movie.Duration);
                    cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                    cmd.Parameters.AddWithValue("@Director", movie.Director);
                    cmd.Parameters.AddWithValue("@PremiereDate", movie.PremiereDate);
                    // Adding the output parameters
                    cmd.Parameters.Add("@MovieID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    // Retrieve the generated MovieID using the Stored Procedure output
                    movie.GeneratedMovieID = (int)cmd.Parameters["@MovieID"].Value;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {

                // MessageBox.Show($"{movie.Title} blev tilføjet.");
            }
        }

    }
}
