using Blazored.Modal;
using Microsoft.Extensions.Logging;
using BibliotecaDonarVidaApp;
using BibliotecaDonarVidaApp.Models;
using BibliotecaDonarVidaApp.Services;
using System.Net.Http;

namespace DonarVidaApp
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

            // Agregar soporte para Blazor en MAUI
            builder.Services.AddMauiBlazorWebView();

            // Configuración de HttpClient para los servicios compartidos

            builder.Services.AddHttpClient<DonanteService>(client =>
            {
                client.BaseAddress = new Uri("https://donarvida.azurewebsites.net"); // URL base de tu API
            });

            builder.Services.AddHttpClient<DonacionService>(client =>
            {
                client.BaseAddress = new Uri("https://donarvida.azurewebsites.net"); // URL base de tu API
            });

            builder.Services.AddHttpClient<ProgramaDonacionService>(client =>
            {
                client.BaseAddress = new Uri("https://donarvida.azurewebsites.net"); // URL base de tu API
            });

            builder.Services.AddHttpClient<DonacionService>(client =>
            {
                client.BaseAddress = new Uri("https://donarvida.azurewebsites.net"); // URL base de tu API
            });

            builder.Services.AddScoped<CentroDonacionService>();
            builder.Services.AddScoped<DonanteService>();
            builder.Services.AddScoped<DonacionService>();
            builder.Services.AddScoped<ProgramaDonacionService>();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
