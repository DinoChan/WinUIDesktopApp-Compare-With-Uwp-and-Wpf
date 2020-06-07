# WinUIDesktopApp-Compare-With-Uwp-and-Wpf

为了验证 WinUI 的性能我写了下面这些代码，然后分别移植到 WPF .Net Framework
 4.8、WPF .NET 5、UWP、WinUI，WPF 和 UWP 的代码稍微有一点出入：

``` cs
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
```

|      |  CPU    | 内存     | GPU |
| ---- | ---- | ---- | ----|
|  WPF .NET Framework 4.8    |   12   |   60	   | 76 |
| WPF .NET 5.0 |12 |85	| 72 |
| UWP |	3	| 28	| 36 |
| WinUI |	5	| 65 |	95 |


我的环境是 i7-6820HQ 及集成显卡。
WinUI有明显掉帧。
