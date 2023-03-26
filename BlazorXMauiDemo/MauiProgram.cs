using BlazorXMauiDemo.Data;
using BlazorXMauiDemo.Service;
using Demo.Pages;
using Microsoft.Extensions.Logging;
using Morris.Blazor.Validation;

namespace BlazorXMauiDemo
{
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
                });

            builder.Services.AddMauiBlazorWebView();
            
            builder.Services.AddFormValidation(config =>
                config.AddFluentValidation(typeof(InputFieldDemo.FormModel).Assembly));

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

#if WINDOWS
            builder.Services.AddSingleton<IFileManager, FileManager>();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}