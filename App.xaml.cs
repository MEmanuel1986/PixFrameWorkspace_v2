using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace PixFrameWorkspace;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();  // Geändert von MainPage zu AppShell
    }

    // WICHTIG: Diese Methode muss hinzugefügt werden
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}