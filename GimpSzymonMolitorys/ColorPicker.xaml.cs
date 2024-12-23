using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GimpSzymonMolitorys
{
    public partial class ColorPicker : Window
    {
        int paraR = 0;
        int paraG = 0;
        int paraB = 0;

        public ColorPicker()
        {
            InitializeComponent();
            changeRectColor();
            Loaded += ColorPicker_Loaded;
        }
        private void ColorPicker_Loaded(object sender, RoutedEventArgs e)
        {
            changeRectColor(); // Wywołanie zmiany koloru po załadowaniu
        }

        private void changeRectColor()
        {
            try
            {
                if (rectColor != null) // Sprawdzenie, czy prostokąt istnieje
                {
                    var currentColor = Color.FromRgb((byte)paraR, (byte)paraG, (byte)paraB);
                    rectColor.Fill = new SolidColorBrush(currentColor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zmiany koloru: {ex.Message}");
            }
        }


        private void hsvValues(int rVal, int gVal, int bVal)
        {
            float rPrim = rVal / 255f;
            float gPrim = gVal / 255f;
            float bPrim = bVal / 255f;

            float mmax = Math.Max(rPrim, Math.Max(gPrim, bPrim));
            float mmin = Math.Min(rPrim, Math.Min(gPrim, bPrim));
            float delta = mmax - mmin;

            float hValue = 0;
            if (delta != 0)
            {
                if (mmax == rPrim) hValue = 60 * (((gPrim - bPrim) / delta) % 6);
                else if (mmax == gPrim) hValue = 60 * ((bPrim - rPrim) / delta + 2);
                else if (mmax == bPrim) hValue = 60 * ((rPrim - gPrim) / delta + 4);
            }

            float sValue = (mmax == 0) ? 0 : delta / mmax;
            float vValue = mmax;

            //txtBoxH.Text = hValue.ToString("F2");
            //txtBoxS.Text = sValue.ToString("F2");
            //txtBoxV.Text = vValue.ToString("F2");
        }

        private bool isValidValue(string input, out int value)
        {
            if (int.TryParse(input, out value) && value >= 0 && value <= 255)
            {
                return true;
            }
            value = 0;
            return false;
        }

        private void handleTextChanged(TextBox textBox, ref int parameter)
        {
            if (isValidValue(textBox.Text, out int newValue))
            {
                if (dataChanger != null)
                {
                    parameter = newValue;
                    changeRectColor();
                    hsvValues(paraR, paraG, paraB);
                    dataChanger.Content = "";
                }
                    
            }
            else
            {
                textBox.Text = "";
                if(textBox.Name== "txtBoxR") dataChanger.Content = $"Wrong value for R.";
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

        private void Button_SaveColor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Kolor zapisany: RGB({paraR}, {paraG}, {paraB})");
        }

        private void Button_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
