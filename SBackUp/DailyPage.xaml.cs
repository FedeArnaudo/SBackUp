using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DailyPage.xaml
    /// </summary>
    public partial class DailyPage : Page
    {
        public DailyPage()
        {
            InitializeComponent();
        }

        public List<string> Informacion { get; } = new List<string>();

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Verifica si el input es un número
            e.Handled = !IsTextAllowed(e.Text);
        }

        // Método para verificar si el texto es un número
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[0-9]+"); // Solo números
            return regex.IsMatch(text);
        }
        // Evento para limitar la longitud del texto a 2 caracteres
        private void NumberTextBoxHoras_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string init = "00";
            string end = "23";

            // Limita la longitud del texto a 2 caracteres
            if (textBox.Text.Length > 2)
            {
                VerificationLength(textBox);
            }
            // Verifica que el valor esté entre los valores adecuados
            if (int.TryParse(textBox.Text, out int value))
            {
                VerificationTime(textBox, init, end, value);
            }
        }

        private void TextBoxMinutos_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string init = "00";
            string end = "59";

            // Limita la longitud del texto a 2 caracteres
            if (textBox.Text.Length > 2)
            {
                VerificationLength(textBox);
            }
            // Verifica que el valor esté entre los valores adecuados
            if (int.TryParse(textBox.Text, out int value))
            {
                VerificationTime(textBox, init, end, value);
            }
        }

        private void TextBoxSegundos_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string init = "00";
            string end = "59";

            // Limita la longitud del texto a 2 caracteres
            if (textBox.Text.Length > 2)
            {
                VerificationLength(textBox);
            }
            // Verifica que el valor esté entre los valores adecuados
            if (int.TryParse(textBox.Text, out int value))
            {
                VerificationTime(textBox, init, end, value);
            }
        }

        private void VerificationLength(TextBox textBox)
        {
            int caretIndex = textBox.CaretIndex;
            textBox.Text = textBox.Text.Substring(0, 2);
            textBox.CaretIndex = caretIndex > 2 ? 2 : caretIndex;
        }
        private void VerificationTime(TextBox textBox, string init, string end, int value)
        {
            if (value < int.Parse(init) || value > int.Parse(end))
            {
                textBox.Text = value < 0 ? init : end;
                textBox.CaretIndex = textBox.Text.Length;
            }
        }

        public void GetInformation()
        {
            string hours;
            string minutes;
            string seconds;

            if (TextBoxHoras.Text != null && TextBoxHoras.Text != "")
            {
                hours = TextBoxHoras.Text;
                if (TextBoxHoras.Text.Length == 1)
                {
                    hours = "0" + TextBoxHoras.Text;
                }
                if (TextBoxMinutos.Text != null && TextBoxMinutos.Text != "")
                {
                    minutes = TextBoxMinutos.Text;
                    if (TextBoxMinutos.Text.Length == 1)
                    {
                        minutes = "0" + TextBoxMinutos.Text;
                    }
                    if (TextBoxSegundos.Text != null && TextBoxSegundos.Text != "")
                    {
                        seconds = TextBoxSegundos.Text;
                        if (TextBoxSegundos.Text.Length == 1)
                        {
                            seconds = "0" + TextBoxSegundos.Text;
                        }
                        Informacion.Add(hours);
                        Informacion.Add(minutes);
                        Informacion.Add(seconds);
                    }
                    else
                    {
                        _ = MessageBox.Show("Debe ingresar un valor para los segundos");
                    }
                }
                else
                {
                    _ = MessageBox.Show("Debe ingresar un valor para los minutos");
                }
            }
            else
            {
                _ = MessageBox.Show("Debe ingresar un valor para las Horas");
            }
        }

        private void BtnProve_Click(object sender, RoutedEventArgs e)
        {
            GetInformation();
            List<string> information = Informacion;
            if (information.Count > 0)
            {
                string respuesta = "Comienzo de la tarea de mantenimiento diaria: ";
                for (int i = 0; i < information.Count; i ++)
                {
                    if ((i + 1) < information.Count)
                    {
                        respuesta += information[i] + ":";
                    }
                    else
                    {
                        respuesta += information[i] + " Hs.";
                    }
                }
                _ = MessageBox.Show(respuesta);
            }
        }
    }
}
