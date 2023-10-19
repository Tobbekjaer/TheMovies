using System;
using System.Collections.Generic;
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

namespace TheMovies.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegisterMovie_Click(object sender, RoutedEventArgs e)
        {
            // Open RegisterMovieWindow
            RegisterMovieWindow registerMovieWindow = new RegisterMovieWindow();
            registerMovieWindow.Show();
        }

        private void btnCreateShow_Click(object sender, RoutedEventArgs e)
        {
            // Open CreateShowWindow
            CreateShowWindow createShowWindow = new CreateShowWindow();
            createShowWindow.Show();
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            // Open BookingPage
            BookingPage bookingPage = new BookingPage();
            Content = bookingPage;
        }
    }
}
