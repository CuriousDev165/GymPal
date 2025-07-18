using GymPal.Core.Services;
using Microsoft.Extensions.Logging;

namespace GymPal
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register pages here.
            builder.Services.AddSingleton<MainPage>();

            // Register viewmodels here.
            builder.Services.AddSingleton<ViewModels.MainPageViewModel>();

            // Register services here.
            builder.Services.AddSingleton<MovementService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
