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
    /// Interaction logic for CreateShowWindow.xaml
    /// </summary>
    public partial class CreateShowWindow : Window
    {
        public CreateShowWindow()
        {
            InitializeComponent();
        }

        Controller controller = new Controller();

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            // Calls AddShow in Controller class
            controller.AddShow(tbTitel.Text, Convert.ToInt32(tbDuration.Text), tbGenre.Text, tbDirector.Text,
                Convert.ToDateTime(tbPremiereDate.Text), tbCinemaName.Text, Convert.ToInt32(tbCinemaHall.Text),
                Convert.ToDateTime(tbStartTime.Text), Convert.ToDateTime(tbEndTime.Text), Convert.ToInt32(tbRunTime.Text));
            
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            // Clears all text boxes except movie info
            //tbTitel.Clear();
            //tbDuration.Clear();
            //tbGenre.Clear();
            //tbDirector.Clear();
            //tbPremiereDate.Clear();
            tbCinemaName.Clear();
            tbCinemaHall.Clear();
            //tbStartTime.Clear();
            //tbEndTime.Clear();
            //tbRunTime.Clear();
        }
    }
}
