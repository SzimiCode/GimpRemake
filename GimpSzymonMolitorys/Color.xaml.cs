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
        public Color()
        {
            InitializeComponent();

            int paraR = int.Parse(txtBoxR.Text);
            int paraG = int.Parse(txtBoxG.Text);
            int paraB = int.Parse(txtBoxB.Text);

            Rectangle rectWithColor = new Rectangle();
            rectWithColor = rectColor;

            hsvValues(paraR, paraG, paraB);

            //currentColor = (paraR, paraG, paraB);

            //rectWithColor.Fill(paraR, paraG, paraB);
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

            txtBoxH.Text = string(hValue);
            txtBoxS.Text = string(sValue);
            txtBoxV.Text = string(vValue);

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
    }
}
