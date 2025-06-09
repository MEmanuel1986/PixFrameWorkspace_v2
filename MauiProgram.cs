﻿using Microsoft.Extensions.Logging;
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

        // DI-Registrierungen
        builder.Services.AddSingleton<CustomerService>();
        builder.Services.AddTransient<CustomerViewModel>();
        builder.Services.AddTransient<MainPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}