using Microsoft.Data.SqlClient;
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
using TheMovies.Application;
using TheMovies.Model;

namespace TheMovies.UI
{
    /// <summary>
    /// Interaction logic for BookingPage.xaml
    /// </summary>
    public partial class BookingPage : Page
    {      
        private string connectionString; // Connection string for database
        private int showID;
        private int capacity;
        public BookingPage()
        {
            InitializeComponent(); 

            // Load the database connection string from appsettings.json
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = config.GetConnectionString("MyDBConnection");

            LoadGrid();
        }

        Controller controller = new Controller();

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
            // Add booking to system
            controller.AddBooking(Convert.ToInt32(tbTicketAmount.Text), tbEmail.Text,
            tbPhone.Text, tbTitle.Text, tbCinemaName.Text, Convert.ToInt32(tbCinemaHall.Text), 
            capacity, Convert.ToDateTime(tbStartTime.Text), showID);

        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView rowSelected = dg.SelectedItem as DataRowView;
            if(rowSelected != null) {
               tbTitle.Text = rowSelected["Title"].ToString();
               tbStartTime.Text = rowSelected["StartTime"].ToString();
               tbCinemaName.Text = rowSelected["CinemaName"].ToString();
               tbCinemaHall.Text = rowSelected["CinemaHall"].ToString();
               showID = (int)rowSelected["ShowID"];
               capacity = (int)rowSelected["Capacity"];
            }
        }

    }
}

