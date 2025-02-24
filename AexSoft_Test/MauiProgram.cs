using AexSoft_Test.DAL.Context;
using AexSoft_Test.Data;
using AexSoft_Test.Services;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AexSoft_Test
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddViewModels();
            builder.Services.AddServices();
            builder
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ApplicationDbContext>(serviceProvider =>
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite($"Data Source={Immutable.dbpath}")
                    .Options;

                var context = new ApplicationDbContext(options);

                return context;
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
