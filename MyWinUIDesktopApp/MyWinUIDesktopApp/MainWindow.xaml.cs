using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Media.Animation;
using Windows.UI;
using Microsoft.UI.Xaml.Shapes;

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
                    Stroke = new SolidColorBrush(Color.FromArgb(255, 75, 75, (byte)((double)i * 250d / 50d))),
                    RenderTransformOrigin = new Point(0.5f, 0.5f)
                };
                Root.Children.Add(rectangle);
                var angle = (double)i * 360d / 50d;
                RotateTransform transform = new RotateTransform
                {
                    Angle = angle
                };

                rectangle.RenderTransform = transform;

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(new DoubleAnimation { Duration = TimeSpan.FromSeconds(1), From = angle, To = angle + 360 });
                Storyboard.SetTarget(storyboard, transform);
                Storyboard.SetTargetProperty(storyboard, "Angle");
                storyboard.RepeatBehavior = RepeatBehavior.Forever;
                storyboard.Begin();

            }
        }
    }
}
