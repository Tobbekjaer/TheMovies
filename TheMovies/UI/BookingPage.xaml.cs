﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheMovies.Model;

namespace TheMovies.UI
{
    /// <summary>
    /// Interaction logic for BookingPage.xaml
    /// </summary>
    public partial class BookingPage : Page
    {
        private string connectionString; // Connection string for database
        public BookingPage()
        {
            InitializeComponent(); 

            // Load the database connection string from appsettings.json
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = config.GetConnectionString("MyDBConnection");

            LoadGrid();
        }

        public void LoadGrid()
        {
            try {
                using (SqlConnection con = new SqlConnection(connectionString)) {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM vShowCinemaMovieConnected", con);
                    DataTable dt = new DataTable();                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    datagrid.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

