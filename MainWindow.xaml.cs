using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPF_Canvas_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Ellipse> points = new List<Ellipse>();
        Random random = new Random();
        Double radiusSize = 10;
        bool isDrawing = false;
        SolidColorBrush color = new SolidColorBrush();
        public MainWindow()
        {
            InitializeComponent();
            color = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
        }

        private void StartDrawing(object sender, MouseButtonEventArgs e)
        {
            isDrawing = true;
        }

        private void LeaveDrawing(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
        }

        private void PaintCircle()
        {
            Ellipse ellipse = new Ellipse
            {
                Width = radiusSize,
                Height = radiusSize,
                //StrokeThickness = 5,
                //Stroke = Brushes.Black,
                Fill = color,
            };

            Canvas.SetLeft(ellipse, Mouse.GetPosition(CanvasApp).X);
            Canvas.SetTop(ellipse, Mouse.GetPosition(CanvasApp).Y);

            CanvasApp.Children.Add(ellipse);
            points.Add(ellipse);
        }

        private void RemovePoint(object sender, MouseButtonEventArgs e)
        {
            if(e.OriginalSource is Ellipse)
            {
                Ellipse ellipse = (Ellipse)e.OriginalSource;

                points.Remove(ellipse);
                CanvasApp.Children.Remove(ellipse);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Clear all rectangles
        {
            for(int i = 0; i < points.Count; i++)
            {
                CanvasApp.Children.Remove(points[i]);
            }
            points.Clear();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //ChangeColor
        {
            color = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) //Change points size
        {
            radiusSize = e.NewValue;
        }

        private void Draw(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                PaintCircle();
            }
        }


    }
}
