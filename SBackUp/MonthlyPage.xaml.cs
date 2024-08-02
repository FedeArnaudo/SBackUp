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
    /// Interaction logic for MonthlyPage.xaml
    /// </summary>
    public partial class MonthlyPage : Page
    {
        public MonthlyPage()
        {
            InitializeComponent();
            for (int i = 1; i <= 28; i++)
            {
                _ = ComboBoxDia.Items.Add(i);
            }
            ComboBoxDia.SelectedIndex = 0;
        }
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

        private void TextBoxHoras_TextChanged(object sender, TextChangedEventArgs e)
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
    }
}
