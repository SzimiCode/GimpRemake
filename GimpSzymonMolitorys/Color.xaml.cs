using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GimpSzymonMolitorys
{
    public partial class Color : Window
    {
        int paraR = 0;
        int paraG = 0;
        int paraB = 0;

        public Color()
        {
            InitializeComponent();
            MessageBox.Show("InitializeComponent completed.");
            Loaded += Color_Loaded;
            // Inicjalizacja koloru prostokąta
           // changeRectColor();

            // Obliczenie wartości HSV dla początkowego koloru
           // hsvValues(paraR, paraG, paraB);

            
        }
        private void Color_Loaded(object sender, RoutedEventArgs e)
        {
            // Sprawdzanie czy rectColor jest poprawnie zainicjowane
            if (rectColor == null)
            {
                MessageBox.Show("Rectangle rectColor is null right after Loaded.");
            }
            else
            {
                MessageBox.Show("Rectangle rectColor initialized correctly.");
            }
        }
        void changeRectColor()
        {
          
            try
            {
                // Tworzenie koloru z parametrów RGB
                System.Windows.Media.Color currentColor = System.Windows.Media.Color.FromRgb((byte)paraR, (byte)paraG, (byte)paraB);


                // Aktualizacja wypełnienia prostokąta
                rectColor.Fill = new SolidColorBrush(currentColor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zmiany koloru: {ex.Message}");
            }
        }

        void hsvValues(int rVal, int gVal, int bVal)
        {
            float rPrim = rVal / 255f;
            float gPrim = gVal / 255f;
            float bPrim = bVal / 255f;

            float mmax = Math.Max(rPrim, Math.Max(gPrim, bPrim));
            float mmin = Math.Min(rPrim, Math.Min(gPrim, bPrim));
            float delta = mmax - mmin;

            // Obliczanie HSV
            float hValue = 0;
            if (delta != 0)
            {
                if (mmax == rPrim) hValue = 60 * (((gPrim - bPrim) / delta) % 6);
                else if (mmax == gPrim) hValue = 60 * ((bPrim - rPrim) / delta + 2);
                else if (mmax == bPrim) hValue = 60 * ((rPrim - gPrim) / delta + 4);
            }

            float sValue = (mmax == 0) ? 0 : delta / mmax;
            float vValue = mmax;

            // Aktualizacja pól tekstowych
            txtBoxH.Text = hValue.ToString("F2");
            txtBoxS.Text = sValue.ToString("F2");
            txtBoxV.Text = vValue.ToString("F2");
        }

        bool isValidValue(string input, out int value)
        {
            // Sprawdzanie poprawności wartości (zakres 0-255)
            if (int.TryParse(input, out value) && value >= 0 && value <= 255)
            {
                return true;
            }
            value = 0;
            return false;
        }

        void handleTextChanged(TextBox textBox, ref int parameter)
        {
            if (isValidValue(textBox.Text, out int newValue))
            {
                parameter = newValue;
                changeRectColor();
                hsvValues(paraR, paraG, paraB);
                dataChanger.Content = ""; // Resetowanie komunikatu o błędzie
            }
            else
            {
                textBox.Text = "0";
                dataChanger.Content = $"Nieprawidłowa wartość dla {textBox.Name}.";
            }
        }

        private void txtBoxR_TextChanged(object sender, TextChangedEventArgs e)
        {
            handleTextChanged((TextBox)sender, ref paraR);
        }

        private void txtBoxG_TextChanged(object sender, TextChangedEventArgs e)
        {
            handleTextChanged((TextBox)sender, ref paraG);
        }

        private void txtBoxB_TextChanged(object sender, TextChangedEventArgs e)
        {
            handleTextChanged((TextBox)sender, ref paraB);
        }

        private void Button_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
