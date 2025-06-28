using Microsoft.Extensions.Logging;
using PixFrameWorkspace.Services;
using PixFrameWorkspace.ViewModels;
using PixFrameWorkspace.Views;

namespace PixFrameWorkspace;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services
        builder.Services.AddSingleton<CustomerService>();

        // ViewModels
        builder.Services.AddTransient<CustomerViewModel>();

        // Views
        builder.Services.AddTransient<MainPage>(sp =>
            new MainPage { BindingContext = sp.GetRequiredService<CustomerViewModel>() });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}