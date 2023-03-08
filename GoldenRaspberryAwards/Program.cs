using CsvHelper.Configuration;
using CsvHelper;
using GoldenRaspberryAwards.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using GoldenRaspberryAwards.Models;

namespace GoldenRaspberryAwards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));

            // Add services to the container.

            builder.Services.AddScoped<IMovieRepo, MovieRepo>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            ReadMovieList();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            PrepareDB.PrepPopulation(app);

            app.Run();
        }

        private static void ReadMovieList()
        {
            List<CsvMovie> result = new List<CsvMovie>();

            string? _filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            string currentDirectory = _filePath + "\\movielist.csv";
    
            try
            {
                using (var streaReader = new StreamReader(currentDirectory))
                {
                    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ";"
                    };

                    using (var csv = new CsvReader(streaReader, csvConfig))
                    {

                        result = csv.GetRecords<CsvMovie>().ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ////Csv data as Json string if needed
            //jsonString = JsonConvert.SerializeObject(records);
            foreach (CsvMovie details in result)
            {
                Console.WriteLine(details.Year + " <=> " + details.Title + " <=> " + details.Studio + " <=> " + details.Producers + " <=> " + details.Winner);
            }

        }
    }
}