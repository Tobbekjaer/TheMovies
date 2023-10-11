﻿using Microsoft.Data.SqlClient;
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
    public class CinemaRepo
    {

        private List<Cinema> cinemas; // List of cinemas
        private string connectionString; // Connection string for database
        public int generatedCinemaID;

        public CinemaRepo()
            {
                // Create a new list of cinemas 
                cinemas = new List<Cinema>();

                // Load the database connection string from appsettings.json
                IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                connectionString = config.GetConnectionString("MyDBConnection");
            }

            public void AddCinema(string cinemaName, int cinemaHall)
            {
                // Create a new cinema 
                Cinema newCinema = new Cinema(cinemaName, cinemaHall);
                // Add the new cinema to list of cinemas
                cinemas.Add(newCinema);
                // Add the new cinema to the database
                AddCinemaToDatabase(newCinema);
            }

        public Cinema GetAddedCinema()
        {
            return cinemas.Last();
        }


        public void AddCinemaToDatabase(Cinema cinema)
            {
                try {
                    using (SqlConnection con = new SqlConnection(connectionString)) {
                        con.Open();

                        // Create an INSERT command to add the cinema to the database
                        SqlCommand cmd = new SqlCommand("INSERT INTO tmCINEMA (CinemaName, CinemaHall) " +
                            "VALUES (@CinemaName, @CinemaHall);", con);
                        cmd.Parameters.AddWithValue("@CinemaName", cinema.CinemaName);
                        cmd.Parameters.AddWithValue("@CinemaHall", cinema.CinemaHall);

                    // Execute the INSERT command
                    cmd.ExecuteNonQuery();

                    // Retrieve the generated CinemaID using @@IDENTITY
                    cmd.CommandText = "SELECT IDENT_CURRENT('tmCINEMA') AS [IDENT_CURRENT('tmCINEMA')]";
                    generatedCinemaID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                finally {
                   // MessageBox.Show($"{cinema.CinemaName} blev tilføjet.");
                }
            }

        }
    }

