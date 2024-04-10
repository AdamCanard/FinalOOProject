using Microsoft.Extensions.Logging;
using OOProject.Models;

namespace OOProject
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            DatabaseManager db = new DatabaseManager();

            //Book book = new Book()
            //{
            //    ISBN = 1,
            //    Quantity = 101,
            //    Author = "Adam",
            //    Title = "Title",
            //    Genre = "Horror"
                
            //};
            //db.UpdateBook(book);

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
