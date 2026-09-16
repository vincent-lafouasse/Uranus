using Av = Avalonia;
using AvControls = Avalonia.Controls;
using IAvApplicationLifetime = Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime;

namespace Uranus;

class App : Av.Application
{
    public override void Initialize() => Styles.Add(new Av.Themes.Fluent.FluentTheme());

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IAvApplicationLifetime desktop)
        {
            desktop.MainWindow = new AvControls.Window
            {
                Title = "Uranus",
                Width = 400,
                Height = 250,
                Content = new AvControls.TextBlock
                {
                    Text = "Hello, World!",
                    FontSize = 28,
                    HorizontalAlignment = Av.Layout.HorizontalAlignment.Center,
                    VerticalAlignment = Av.Layout.VerticalAlignment.Center,
                },
            };
        }
        base.OnFrameworkInitializationCompleted();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var builder = Av.AppBuilderDesktopExtensions.UsePlatformDetect(Av.AppBuilder.Configure<App>());
        Av.ClassicDesktopStyleApplicationLifetimeExtensions.StartWithClassicDesktopLifetime(builder, args);
    }
}
