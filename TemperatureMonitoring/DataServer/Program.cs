
using DataServer.Model;

namespace DataServer
{
    public class Program
    {
        private static List<TempHum> tempHums = new List<TempHum>();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            // --------------------------------
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
            var appDirectory = AppContext.BaseDirectory;
            foreach(var item in loader.LoadCsv(Path.Combine(appDirectory, @"Data/data.csv"))
                .Take(200))
            {
                tempHums.Add(item);
            }

        }
    }
}
