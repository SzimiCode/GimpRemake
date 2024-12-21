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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GimpSzymonMolitorys
{
    /// <summary>
    /// Logika interakcji dla klasy Color.xaml
    /// </summary>
    public partial class Color : Window
    {
        int paraR = 0;
        int paraG = 0;
        int paraB = 0;
        public Color()
        {
            InitializeComponent();

            paraR = int.Parse(txtBoxR.Text);
            paraG = int.Parse(txtBoxG.Text);
            paraB = int.Parse(txtBoxB.Text);

            changeRectColor();

            hsvValues(paraR, paraG, paraB);

            //currentColor = (paraR, paraG, paraB);

            //rectWithColor.Fill(paraR, paraG, paraB);
        }

        void ChangeRectColor(Rectangle rectWithColor, byte paraR, byte paraG, byte paraB)
        {
            System.Windows.Media.Color currentColor = System.Windows.Media.Color.FromRgb(paraR, paraG, paraB);

            Brush brushColor = new SolidColorBrush(currentColor);

            rectWithColor.Fill = brushColor;
        }
        void hsvValues(int rVal, int gVal, int bVal)
        {
            float rPrim = rVal / 255;
            float gPrim = gVal / 255;
            float bPrim = bVal / 255;

            float mmax = maxValue(rPrim, gPrim, bPrim);
            float mmin = minValue(rPrim, gPrim, bPrim);

            float delta = mmax - mmin;

            float vValue = mmax;

            float sValue = 0;

            float hValue = 0;

            if (delta == 0)
            {
                hValue = 0;
            }
            else if(mmax == rPrim)
            {
                hValue = 60 * (((gPrim - bPrim)/delta)%6);
            }
            else if(mmax == gPrim)
            {
                hValue = 60 * ((bPrim - rPrim) / delta + 2);
            }
            else if(mmax == bPrim)
            {
                hValue = 60 * ((rPrim - gPrim) / delta + 4);
            }

            if (mmax == 0)
            {
                sValue = 0;
            }
            else
            {
                sValue = delta/ mmax;
            }
            
            txtBoxH.Text = hValue.ToString();
            txtBoxS.Text = sValue.ToString();
            txtBoxV.Text = vValue.ToString();
            

        }


        float minValue(float rPrim, float gPrim, float bPrim)
        {
            float min = Math.Min(rPrim, gPrim);
            min = Math.Min(min, bPrim);
            return min;
        }
        float maxValue(float rPrim, float gPrim, float bPrim)
        {
            float max = Math.Max(rPrim, gPrim);
            max = Math.Max(max, bPrim);
            return max;
        }

        bool valueChecker(int a)
        {
            if (a < 256 || a > 0) return true;
            return false;
        }

        private void txtBoxR_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (valueChecker(paraR))
            {
                paraR = int.Parse(txtBoxR.Text);
                changeRectColor();
                hsvValues(paraR, paraG, paraB);
            }
            else
            {
                txtBoxR.Text = "0";
                dataChanger.Content = "Wrong R number";
            }
        }

        private void txtBoxG_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (valueChecker(paraG))
            {
                paraG = int.Parse(txtBoxG.Text);
                changeRectColor();
                hsvValues(paraR, paraG, paraB);
            }
            else
            {
                txtBoxG.Text = "0";
                dataChanger.Content = "Wrong G number";
            }
        }

        private void txtBoxB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (valueChecker(paraB))
            {
                paraB = int.Parse(txtBoxB.Text);
                changeRectColor();
                hsvValues(paraR, paraG, paraB);
            }
            else
            {
                txtBoxB.Text = "0";
                dataChanger.Content = "Wrong B number";
            }
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
