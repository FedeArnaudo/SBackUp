using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SBackUp
{
    /// <summary>
    /// Lógica de interacción para CreateWindows.xaml
    /// </summary>
    public partial class CreateWindows : Window
    {
        public CreateWindows()
        {
            InitializeComponent();
        }

        private void CloseWindowsCreate_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BtnBuscar1_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFuente.Text = BuscarRuta();
        }

        private void BtnBuscar2_Click(object sender, RoutedEventArgs e)
        {
            TextBoxDestino.Text = BuscarRuta();
        }
        private string BuscarRuta()
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.MyComputer, // Carpeta raíz (opcional)
                Description = "Selecciona una carpeta" // Descripción del diálogo (opcional)
            };

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;
            }
            return folderPath;
        }
    }
}
