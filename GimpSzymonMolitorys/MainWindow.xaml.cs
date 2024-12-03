﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace GimpSzymonMolitorys
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Current Point where we click our mouse 
        Point currentPoint = new Point();
        Line previewLine = null;

        //Variable to choose which style of drawing we will choose
        int drawStyle = 1;
        private bool click;

        public MainWindow()
        {
            InitializeComponent();
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

                line.Stroke = SystemColors.WindowFrameBrush;
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

        private void paintSurface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //Zrobic pozniej switcha
        {
            if (drawStyle == 2)
            {
                // We created ellipse object to immitate point
                Ellipse ellipse = new Ellipse();
                //We set height and width of our point
                ellipse.Width = 6;
                ellipse.Height = 6;
                //we give ellipse to possition of our mouse
                Canvas.SetTop(ellipse, e.GetPosition(this).Y - ellipse.Height/2);
                Canvas.SetLeft(ellipse, e.GetPosition(this).X - ellipse.Width/2);
                ellipse.Fill = SystemColors.WindowFrameBrush;
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
                        Stroke = SystemColors.WindowFrameBrush,
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

                Brush brushColor = new SolidColorBrush(Colors.Black);

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

                PointCollection polyPoints = new PointCollection();

                polyPoints.Add(point1);
                polyPoints.Add(point2);
                polyPoints.Add(point3);
                polyPoints.Add(point4);
                polyPoints.Add(point5);
                polyPoints.Add(point6);

                poly.Points = polyPoints;

                Brush brushColor = new SolidColorBrush(Colors.Black);

                poly.Stroke = brushColor;

                paintSurface.Children.Add(poly);

            }
            if (drawStyle == 12)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = 60;
                ellipse.Height = 60;
                Canvas.SetTop(ellipse, e.GetPosition(this).Y - ellipse.Height / 2);
                Canvas.SetLeft(ellipse, e.GetPosition(this).X - ellipse.Width / 2);
                Brush brushColor = new SolidColorBrush(Colors.Black);
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
                PointCollection polyPoints = new PointCollection();

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
                Brush brushColor = new SolidColorBrush(Colors.Black);
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

                line.Stroke = SystemColors.WindowFrameBrush;
                line2.Stroke = SystemColors.WindowFrameBrush;
                line3.Stroke = SystemColors.WindowFrameBrush;
                line4.Stroke = SystemColors.WindowFrameBrush;
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

                Brush brushColor = new SolidColorBrush(Colors.Black);

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
                    Points = new PointCollection { topPoint, leftPoint, rightPoint },
                 
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

                PointCollection polyPoints = new PointCollection();

                polyPoints.Add(topPoint);
                polyPoints.Add(leftPoint);
                polyPoints.Add(rightPoint);

                triangle.Points = polyPoints;

                Brush brushColor = new SolidColorBrush(Colors.Black);

                triangle.Stroke = brushColor;

                paintSurface.Children.Add(triangle);

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
    }
}
