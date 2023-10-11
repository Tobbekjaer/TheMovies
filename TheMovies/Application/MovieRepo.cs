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
        public int generatedMovieID;

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
                    SqlCommand cmd = new SqlCommand("INSERT INTO tmMOVIE (Title, Duration, Genre, Director, PremiereDate) " +
                        "VALUES (@Title, @Duration, @Genre, @Director, @PremiereDate); SELECT SCOPE_IDENTITY();", con);
                    cmd.Parameters.AddWithValue("@Title", movie.Title);
                    cmd.Parameters.AddWithValue("@Duration", movie.Duration);
                    cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                    cmd.Parameters.AddWithValue("@Director", movie.Director);
                    cmd.Parameters.AddWithValue("@PremiereDate", movie.PremiereDate);

                    // Retrieve the generated MovieID using SCOPE_IDENTITY()
                    generatedMovieID = Convert.ToInt32(cmd.ExecuteScalar());
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
