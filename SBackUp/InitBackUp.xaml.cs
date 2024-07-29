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

namespace SBackUp
{
    /// <summary>
    /// Interaction logic for InitBackUp.xaml
    /// </summary>
    public partial class InitBackUp : Window
    {
        public InitBackUp()
        {
            InitializeComponent();
        }

        private void Crear_Click(object sender, RoutedEventArgs e)
        {
            CreateWindows createWindows = new CreateWindows
            {
                Owner = this
            };
            createWindows.Closed += CreateWindows_Closed;
            createWindows.Show();
            Hide();
        }
        private void CreateWindows_Closed(object sender, EventArgs e)
        {
            IsEnabled = true;
            Show();
            _ = Activate();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
