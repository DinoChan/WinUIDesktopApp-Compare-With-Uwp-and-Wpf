﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Shapes;
using System;
using Windows.Foundation;
using Windows.UI;

// The Blank Window item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyWinUIDesktopApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Root.Loaded += OnLoaded;
        }



        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                var rectangle = new Rectangle
                {
                    Height = 500,
                    Width = 500,
                    Opacity = ((double)i + 40) / 100d,
                    RadiusX = 108,
                    RadiusY = 98,
                    StrokeThickness = 3,
                    Stroke = new SolidColorBrush(Color.FromArgb(255, 75, 75, (byte)(i * 250d / 50d))),
                    RenderTransformOrigin = new Point(0.5f, 0.5f)
                };
                Root.Children.Add(rectangle);
                var angle = i * 360d / 50d;
                var transform = new RotateTransform
                {
                    Angle = angle
                };

                rectangle.RenderTransform = transform;

                var storyboard = new Storyboard();
                storyboard.Children.Add(new DoubleAnimation { Duration = TimeSpan.FromSeconds(1), From = angle, To = angle + 360 });
                Storyboard.SetTarget(storyboard, transform);
                Storyboard.SetTargetProperty(storyboard, "Angle");
                storyboard.RepeatBehavior = RepeatBehavior.Forever;
                storyboard.Begin();

            }
        }
    }
}
