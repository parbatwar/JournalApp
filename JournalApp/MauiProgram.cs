using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace JournalApp
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
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "journal.db");

                options.UseSqlite($"Data Source={dbPath}");
            });




#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }
            return app;




            //var app = builder.Build();

            //using (var scope = app.Services.CreateScope())
            //{

            //    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            //    var realPath = Path.Combine(FileSystem.AppDataDirectory, "journal.db");

            //    var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //    File.WriteAllText(Path.Combine(desktop, "db_location.txt"), realPath);

            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();

            //}
            //return app;


        }
    }
}

