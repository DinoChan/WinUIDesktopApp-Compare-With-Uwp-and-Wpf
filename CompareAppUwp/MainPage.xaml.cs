using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace CompareAppUwp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Loaded += OnLoaded;
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
                    RenderTransformOrigin = new Point(0.5, 0.5)
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
