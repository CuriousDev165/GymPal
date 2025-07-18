using GymPal.Core.Interfaces;
using GymPal.Core.ViewModels;
using GymPal.Core.Repositories;
using GymPal.Core.Services;
using Microsoft.Extensions.Logging;
using GymPal.Models;

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
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<RecordsViewModel>();

            // Register services here.
            builder.Services.AddSingleton<MovementService>();

            // Register repositories here.
            builder.Services.AddSingleton<IRepository<WeightTrainingMovement>, WeightTrainingRepository>(provider => 
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "movements.db3");
                return new WeightTrainingRepository(dbPath);
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
