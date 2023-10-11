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
using System.Windows.Shapes;
using TheMovies.Application;

namespace TheMovies.UI
{
    /// <summary>
    /// Interaction logic for RegisterMovieWindow.xaml
    /// </summary>
    public partial class RegisterMovieWindow : Window
    {
        public RegisterMovieWindow()
        {
            InitializeComponent();
        }

        Controller controller = new Controller();

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            //// Calls AddMovie in Controller class
            //controller.AddMovie(tbTitel.Text, Convert.ToInt32(tbDuration.Text), tbGenre.Text);
            //ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            // Clears all text boxes except movie info
            tbTitel.Clear();
            tbDuration.Clear();
            tbGenre.Clear();
        }
    }
}
