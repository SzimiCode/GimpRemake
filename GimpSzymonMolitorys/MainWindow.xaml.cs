using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Emgu.CV;
using Emgu.CV.Structure;

namespace GimpSzymonMolitorys
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        //Current Point where we click our mouse 
        Point currentPoint = new Point();
        Line previewLine = null;

        //Variable to choose which style of drawing we will choose
        int drawStyle = 1;
        private bool click;
        private Brush currentBrush = Brushes.Black;
        //private Line selectedLine = null;
        //private bool isEditingStartPoint = false;
        public MainWindow()
        {
            InitializeComponent();
            

        }
        public void SetColor(Color color)
        {
            currentBrush = new SolidColorBrush(color);
            whichColor.Fill = currentBrush; 
        }

        //pomocniczna funkcja do rysowania linii
        private void PreviewLine_MouseMove(object sender, MouseEventArgs e)
        {
            if (previewLine != null)
            {
                // Aktualizujemy współrzędne X2 i Y2 na podstawie pozycji myszy
                Point position = e.GetPosition(this);
                previewLine.X2 = position.X;
                previewLine.Y2 = position.Y;
            }
        }
        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 1;
        }

        private void btnPoints_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 2;
        }

        private void btnLines_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 3;
        }

        private void paintSurface_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Confirmation that button is pressed
            //e -> Gives Back what is pressed
            if(e.ButtonState == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(this);
            }
        }


        private void paintSurface_MouseMove(object sender, MouseEventArgs e)
        {
            //we checked whether we have our button pressed and it's drawstyle freely, so we can draw
            if(e.LeftButton == MouseButtonState.Pressed && drawStyle == 1)
            {
                Line line = new Line();

                line.Stroke = currentBrush;
                //We have to przypisać points to our line
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                //We take our position from mouse (e)
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                currentPoint = e.GetPosition(this);

                paintSurface.Children.Add(line);
            }
        }
        bool isRightClicked = false;
        private  void paintSurface_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //We set flag which means stop drawing, then we remove preview of the line and reset variable controlling click
            isRightClicked = true;

            if (previewLine != null)
            {
                this.MouseMove -= PreviewLine_MouseMove;
                previewLine = null;
            }

            click = true;
        }
        private void paintSurface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //Zrobic pozniej switcha
        {
            if (drawStyle == 2)
            {
                // We created ellipse object to immitate point
                System.Windows.Shapes.Ellipse ellipse = new System.Windows.Shapes.Ellipse();
                //We set height and width of our point
                ellipse.Width = 6;
                ellipse.Height = 6;
                //we give ellipse to possition of our mouse
                Canvas.SetTop(ellipse, e.GetPosition(this).Y - ellipse.Height/2);
                Canvas.SetLeft(ellipse, e.GetPosition(this).X - ellipse.Width/2);
                ellipse.Fill = currentBrush;
                paintSurface.Children.Add(ellipse);

                //We move by half of the height, to set at exact spot of mouse that,s why - 
            }
            

            if (drawStyle == 3)
            {
      
                if (click == true)
                {
                    // Pierwsze kliknięcie - ustawiamy początkowy punkt
                    currentPoint = e.GetPosition(this);
                    click = false;

                    // Tworzymy tymczasową linię do podglądu
                    previewLine = new Line
                    {
                        Stroke = currentBrush,
                        X1 = currentPoint.X,
                        Y1 = currentPoint.Y,
                        X2 = currentPoint.X, // Tymczasowo, zaktualizowane w MouseMove
                        Y2 = currentPoint.Y, // Tymczasowo, zaktualizowane w MouseMove
                    };
                    paintSurface.Children.Add(previewLine);

                    // Subskrybujemy zdarzenie MouseMove
                    this.MouseMove += PreviewLine_MouseMove;
                }
                else
                {
                    // Drugie kliknięcie - ustalamy końcowy punkt
                    if (previewLine != null)
                    {
                        // Ustawiamy ostateczne współrzędne linii
                        previewLine.X2 = e.GetPosition(this).X;
                        previewLine.Y2 = e.GetPosition(this).Y;

                        // Usuwamy MouseMove, bo linia jest już ustalona
                        this.MouseMove -= PreviewLine_MouseMove;
                        previewLine = null;
                    }

                    click = true;
                }
            }
            if (drawStyle == 11) //mozna probowac od użytkownika
            {
                Rectangle rect = new Rectangle();
                rect.Width = 60;
                rect.Height = 30;

                //Pojawi sie dokladnie na srodku gdzie klikniemy
                Canvas.SetTop(rect, e.GetPosition(this).Y - rect.Height / 2);
                Canvas.SetLeft(rect, e.GetPosition(this).X - rect.Width / 2);

                Brush brushColor = currentBrush;

                rect.Stroke = brushColor;

                paintSurface.Children.Add(rect);

            }

            if(drawStyle == 10)
            {
                Polygon poly = new Polygon();

                double mouseX = e.GetPosition(this).X;
                double mouseY = e.GetPosition(this).Y;

                double polySize = 30;

                Point point1 = new Point(mouseX - polySize, mouseY + 2*polySize);
                Point point2 = new Point(mouseX + polySize, mouseY + 2*polySize);
                Point point3 = new Point(mouseX + 2*polySize, mouseY);
                Point point4 = new Point(mouseX + polySize, mouseY - 2*polySize);
                Point point5 = new Point(mouseX - polySize, mouseY - 2 * polySize);
                Point point6 = new Point(mouseX - 2*polySize, mouseY);

                System.Windows.Media.PointCollection polyPoints = new System.Windows.Media.PointCollection();

                polyPoints.Add(point1);
                polyPoints.Add(point2);
                polyPoints.Add(point3);
                polyPoints.Add(point4);
                polyPoints.Add(point5);
                polyPoints.Add(point6);

                poly.Points = polyPoints;

                Brush brushColor = currentBrush;

                poly.Stroke = brushColor;

                paintSurface.Children.Add(poly);

            }
            if (drawStyle == 12)
            {
                System.Windows.Shapes.Ellipse ellipse = new System.Windows.Shapes.Ellipse();
                ellipse.Width = 60;
                ellipse.Height = 60;
                Canvas.SetTop(ellipse, e.GetPosition(this).Y - ellipse.Height / 2);
                Canvas.SetLeft(ellipse, e.GetPosition(this).X - ellipse.Width / 2);
                Brush brushColor = currentBrush;
                ellipse.Stroke = brushColor;
                paintSurface.Children.Add(ellipse);
            }
            if (drawStyle == 13) //Z internetu gwiazda za pomocą trygonometri
            {
                Polygon poly = new Polygon();

                double mouseX = e.GetPosition(this).X;
                double mouseY = e.GetPosition(this).Y;

                double outerRadius = 60; // Promień zewnętrzny
                double innerRadius = 30; // Promień wewnętrzny

                // Kolekcja punktów gwiazdy
                System.Windows.Media.PointCollection polyPoints = new System.Windows.Media.PointCollection();

                // Liczba wierzchołków gwiazdy
                int numPoints = 10;

                // Obliczanie punktów gwiazdy
                for (int i = 0; i < numPoints; i++)
                {
                    // Kąt dla danego punktu
                    double angle = i * Math.PI / 5; // 360° / 10 = 36° między punktami

                    // Zmienna promień zależna od pozycji (wewnętrzny/zewnętrzny)
                    double radius = (i % 2 == 0) ? outerRadius : innerRadius;

                    // Oblicz współrzędne punktu
                    double x = mouseX + radius * Math.Sin(angle);
                    double y = mouseY - radius * Math.Cos(angle);

                    polyPoints.Add(new Point(x, y));
                }

                // Dodanie punktów do wielokąta
                poly.Points = polyPoints;

                // Stylizacja wielokąta
                Brush brushColor = currentBrush;
                poly.Stroke = brushColor;

                // Dodanie wielokąta do obszaru rysowania
                paintSurface.Children.Add(poly);

            }
            if (drawStyle == 14)
            {

                Line line = new Line();
                Line line2 = new Line();
                Line line3 = new Line();
                Line line4 = new Line();

                double lineLength = 30;

                double mouseX = e.GetPosition(this).X;
                double mouseY = e.GetPosition(this).Y;

                line.Stroke = currentBrush;
                line2.Stroke = currentBrush;
                line3.Stroke = currentBrush;
                line4.Stroke = currentBrush;
                //We have to przypisać points to our line
                line.X1 = mouseX+lineLength;
                line.Y1 = mouseY;
                //We take our position from mouse (e)
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                line2.X1 = mouseX;
                line2.Y1 = mouseY+lineLength;

                line2.X2 = e.GetPosition(this).X;
                line2.Y2 = e.GetPosition(this).Y;

                line3.X1 = mouseX - lineLength;
                line3.Y1 = mouseY;

                line3.X2 = e.GetPosition(this).X;
                line3.Y2 = e.GetPosition(this).Y;

                line4.X1 = mouseX ;
                line4.Y1 = mouseY - lineLength;

                line4.X2 = e.GetPosition(this).X;
                line4.Y2 = e.GetPosition(this).Y;
                currentPoint = e.GetPosition(this);

                paintSurface.Children.Add(line);
                paintSurface.Children.Add(line2);
                paintSurface.Children.Add(line3);
                paintSurface.Children.Add(line4);

            }
            if (drawStyle == 16)
            {
                Rectangle rect = new Rectangle();
                rect.Width = 25;
                rect.Height = 60;

                Brush brushColor = currentBrush;

                Canvas.SetTop(rect, e.GetPosition(this).Y);
                Canvas.SetLeft(rect, e.GetPosition(this).X - rect.Width / 2);

                double mouseX = e.GetPosition(this).X;
                double mouseY = e.GetPosition(this).Y;

                double triangleWidth = 50;
                double triangleHeight = 50;


                Point topPoint = new Point(mouseX, mouseY - triangleHeight);           
                Point leftPoint = new Point(mouseX - triangleWidth / 2, mouseY);       
                Point rightPoint = new Point(mouseX + triangleWidth / 2, mouseY);    

                Polygon triangle = new Polygon
                {
                    Points = new System.Windows.Media.PointCollection { topPoint, leftPoint, rightPoint },
                 
                };
                triangle.Stroke = brushColor;
                rect.Stroke = brushColor;

                paintSurface.Children.Add(triangle);
                paintSurface.Children.Add(rect);

            }
            if(drawStyle == 17)
            {
                double mouseX = e.GetPosition(this).X;
                double mouseY = e.GetPosition(this).Y;


                double triangleWidth = 50;
                double triangleHeight = 50;


                Point topPoint = new Point(mouseX, mouseY - triangleHeight);        
                Point leftPoint = new Point(mouseX - triangleWidth / 2, mouseY);    
                Point rightPoint = new Point(mouseX + triangleWidth / 2, mouseY);

                Polygon triangle = new Polygon();

                System.Windows.Media.PointCollection polyPoints = new System.Windows.Media.PointCollection();

                polyPoints.Add(topPoint);
                polyPoints.Add(leftPoint);
                polyPoints.Add(rightPoint);

                triangle.Points = polyPoints;

                Brush brushColor = currentBrush;

                triangle.Stroke = brushColor;

                paintSurface.Children.Add(triangle);

            }
            if(drawStyle == 15)
            {
                Rectangle rect = new Rectangle();
                rect.Width = 20;
                rect.Height = 30;

                Brush brushColor = currentBrush;

                Canvas.SetTop(rect, e.GetPosition(this).Y);
                Canvas.SetLeft(rect, e.GetPosition(this).X - rect.Width / 2);

                double mouseX = e.GetPosition(this).X;
                double mouseY = e.GetPosition(this).Y;

                double triangleWidth = 50;
                double triangleHeight = 50;


                Point topPoint = new Point(mouseX, mouseY - triangleHeight);
                Point leftPoint = new Point(mouseX - triangleWidth / 2, mouseY);
                Point rightPoint = new Point(mouseX + triangleWidth / 2, mouseY);

                Polygon triangle = new Polygon
                {
                    Points = new System.Windows.Media.PointCollection { topPoint, leftPoint, rightPoint },

                };
                double triangleWidth2 = 40;
                double triangleHeight2 = 40;


                Point topPoint2 = new Point(mouseX, mouseY - triangleHeight - triangleHeight2);
                Point leftPoint2 = new Point(mouseX - triangleWidth2 / 2, mouseY - triangleHeight);
                Point rightPoint2 = new Point(mouseX + triangleWidth2 / 2, mouseY - triangleHeight);

                Polygon triangle2 = new Polygon
                {
                    Points = new System.Windows.Media.PointCollection { topPoint2, leftPoint2, rightPoint2 },

                };

                double triangleWidth3 = 30;
                double triangleHeight3 = 30;


                Point topPoint3 = new Point(mouseX, mouseY - triangleHeight2 - triangleHeight - triangleHeight3);
                Point leftPoint3 = new Point(mouseX - triangleWidth3 / 2, mouseY - triangleHeight2 - triangleHeight);
                Point rightPoint3 = new Point(mouseX + triangleWidth3 / 2, mouseY - triangleHeight2 - triangleHeight);

                Polygon triangle3 = new Polygon
                {
                    Points = new System.Windows.Media.PointCollection { topPoint3, leftPoint3, rightPoint3 },

                };



                triangle3.Stroke = brushColor;
                triangle2.Stroke = brushColor;
                triangle.Stroke = brushColor;
                rect.Stroke = brushColor;

                paintSurface.Children.Add(triangle);
                paintSurface.Children.Add(rect);
                paintSurface.Children.Add(triangle2);
                paintSurface.Children.Add(triangle3);
            }

            if(drawStyle == 21)
            {
                if (isRightClicked == false)
                {
                    
                    click = true;

                    if (click == true)
                    {
                        currentPoint = e.GetPosition(this);
                        click = false;

                        previewLine = new Line
                        {
                            Stroke = currentBrush,
                            X1 = currentPoint.X,
                            Y1 = currentPoint.Y,
                            X2 = currentPoint.X,
                            Y2 = currentPoint.Y,
                        };
                        paintSurface.Children.Add(previewLine);


                        this.MouseMove += PreviewLine_MouseMove;
                    }
                    else
                    {

                        if (previewLine != null)
                        {

                            previewLine.X2 = e.GetPosition(this).X;
                            previewLine.Y2 = e.GetPosition(this).Y;


                            this.MouseMove -= PreviewLine_MouseMove;
                            previewLine = null;
                        }

                    }



                }
                else
                {

                    if (previewLine != null)
                    {
                        this.MouseMove -= PreviewLine_MouseMove;
                        previewLine = null;
                    }

                    isRightClicked = false;
                    click = true; 
                    return;
                }

            }
            if (drawStyle == 22) { 
            }
                
        }

        private void drawPolygon_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 10;
        }

        private void drawRectangle_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 11;
        }

        private void drawEllipse_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 12;
        }

        private void drawStar_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 13;
        }

        private void drawPlus_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 14;
        }

        private void drawTree_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 15;
        }
        private void drawArrow_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 16;
        }
        private void drawTriangle_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 17;
        }

        private void brokenLine_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 21;
        }

        private void editLine_Click(object sender, RoutedEventArgs e)
        {
            drawStyle = 22;
        }

        private void whichColor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorPicker colorpicker = new ColorPicker();
            colorpicker.ShowDialog();
        }

        private void paintSurface_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void OnAddImageClick(object sender, RoutedEventArgs e)
        {
            //  Open window with choosing files
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "(*.jpg;*.png)|*.jpg;*.png|(*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    
                    string filePath = openFileDialog.FileName;

                    // Create BitmapImage
                    BitmapImage bitmap = new BitmapImage(new Uri(filePath));

                
                    Image imageControl = new Image
                    {
                        Source = bitmap,
                        Width = 200, 
                        Height = 200,
                       
                    };

                    // Add image to Canvas
                    Canvas.SetLeft(imageControl, 50); 
                    Canvas.SetTop(imageControl, 50); 
                    paintSurface.Children.Add(imageControl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during uploading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void OnApplySobelFilterClick(object sender, RoutedEventArgs e)
        {
            Image<Bgr, byte> img = new Image<Bgr, byte>("C:\\Users\\Lenovo\\Pictures\\Screenshots\\Zrzut ekranu 2024-12-18 194139.png");
            Image<Gray, byte> img2 = img.Convert<Gray, byte>();
            Image<Gray, Single> img_final = (img2.Sobel(1, 0, 5));

            CvInvoke.Imshow("Image", img_final);
            CvInvoke.Imshow("Image2", img2);
            CvInvoke.WaitKey(0);
        }
    }
}
