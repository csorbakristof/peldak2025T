using DataServer.Model;

namespace DataServer
{
    public class Program
    {
        private static List<TempHum> tempHums = new List<TempHum>();
        public static void Main(string[] args)
        {
            // These come from the default project template...
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();

            // Now the custom code...
            LoadCsvData();

            app.MapGet("/data", (HttpContext httpContext) =>
            {
                return tempHums;
            })
            .WithName("Data")
            .WithOpenApi();

            app.Run();
        }

        private static void LoadCsvData()
        {
            var loader = new DataLoader();
            tempHums.Clear();
            var appDirectory = System.AppContext.BaseDirectory;
            foreach (var item in loader.LoadCsv(Path.Combine(appDirectory, @"Data/data.csv")).Take(200))
            {
                tempHums.Add(item);
            }
        }
    }
}
