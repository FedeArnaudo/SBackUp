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
using CheckBox = System.Windows.Controls.CheckBox;
using MessageBox = System.Windows.MessageBox;

namespace SBackUp
{
    /// <summary>
    /// Lógica de interacción para CreateWindows.xaml
    /// </summary>
    public partial class CreateWindows : Window
    {
        private Page page = new Page();
        public CreateWindows()
        {
            InitializeComponent();
            CheckBoxDiario.IsChecked = true;
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
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                // Uncheck all other checkboxes
                if (checkBox != CheckBoxDiario)
                {
                    CheckBoxDiario.IsChecked = false;
                }

                if (checkBox != CheckBoxSemanal)
                {
                    CheckBoxSemanal.IsChecked = false;
                }

                if (checkBox != CheckBoxMensual)
                {
                    CheckBoxMensual.IsChecked = false;
                }

                // Load the corresponding page into the frame
                if (checkBox == CheckBoxDiario)
                {
                    page = new DailyPage();
                    _ = FramePage.Navigate(page);
                }
                else if (checkBox == CheckBoxSemanal)
                {
                    page = new WeeklyPage();
                    _ = FramePage.Navigate(page);
                }
                else if (checkBox == CheckBoxMensual)
                {
                    page = new MonthlyPage();
                    _ = FramePage.Navigate(page);
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Optionally clear the frame if no checkbox is checked
            if (!CheckBoxDiario.IsChecked.GetValueOrDefault() &&
                !CheckBoxSemanal.IsChecked.GetValueOrDefault() &&
                !CheckBoxMensual.IsChecked.GetValueOrDefault())
            {
                FramePage.Content = null;
            }
        }

        private void Crear_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxDiario.IsChecked == true)
            {
                _ = MessageBox.Show($"Tarea de mantenimiento diario");
            }
            else if (CheckBoxSemanal.IsChecked == true)
            {
                _ = MessageBox.Show("Tarea de mantenimiento semanal");
            }
            else if(CheckBoxMensual.IsChecked == true)
            {
                _ = MessageBox.Show("Tarea de mantenimiento mensual");
            }
            else
            {
                _ = MessageBox.Show("Debe seleccionar un período de ejecución");
            }
        }
    }
}
