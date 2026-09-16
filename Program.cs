using Application = Avalonia.Application;
using AppBuilder = Avalonia.AppBuilder;
using AppBuilderDesktopExtensions = Avalonia.AppBuilderDesktopExtensions;
using ClassicDesktopStyleApplicationLifetimeExtensions = Avalonia.ClassicDesktopStyleApplicationLifetimeExtensions;
using IClassicDesktopStyleApplicationLifetime = Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime;
using Window = Avalonia.Controls.Window;
using TextBlock = Avalonia.Controls.TextBlock;
using HorizontalAlignment = Avalonia.Layout.HorizontalAlignment;
using VerticalAlignment = Avalonia.Layout.VerticalAlignment;
using FluentTheme = Avalonia.Themes.Fluent.FluentTheme;

namespace Uranus;

class App : Application
{
    public override void Initialize() => Styles.Add(new FluentTheme());

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new Window
            {
                Title = "Uranus",
                Width = 400,
                Height = 250,
                Content = new TextBlock
                {
                    Text = "Hello, World!",
                    FontSize = 28,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
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
        var builder = AppBuilderDesktopExtensions.UsePlatformDetect(AppBuilder.Configure<App>());
        ClassicDesktopStyleApplicationLifetimeExtensions.StartWithClassicDesktopLifetime(builder, args);
    }
}
