using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace PixFrameWorkspace;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new MainPage();
    }

    // WICHTIG: Diese Methode muss vorhanden sein
    public static override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}