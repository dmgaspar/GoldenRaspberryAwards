using CsvHelper.Configuration;
using CsvHelper;
using GoldenRaspberryAwards.Models;
using System.Globalization;
using System.Runtime.ConstrainedExecution;

namespace GoldenRaspberryAwards.Data
{
    public static class PrepareDB
    {
        const string csvFile = "\\movielist.csv";
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext? context)
        {
            if (!context.Movies.Any())
            {
                List<CsvMovie> csvMovies = new List<CsvMovie>();

                try
                {
                    csvMovies = ReadCsvMovieList();
                    PersistMovieList(csvMovies, context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }

        private static void PersistMovieList(List<CsvMovie> csvMovies, AppDbContext? context)
        {
            foreach (var csvItem in csvMovies)
            {
                Movie movie = new Movie
                {
                    Year = csvItem.Year,
                    Title = csvItem.Title,
                    Studio = csvItem.Studio,
                    Producers = csvItem.Producers,
                    Winner = csvItem.Winner
                };
                context.Add(movie);
            }
            context.SaveChanges();
        }

        private static List<CsvMovie> ReadCsvMovieList()
        {
            List<CsvMovie> movies = new List<CsvMovie>();

            string? _filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            string currentDirectory = _filePath + csvFile;

                using (var streaReader = new StreamReader(currentDirectory))
                {
                    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ";"
                    };

                    using (var csv = new CsvReader(streaReader, csvConfig))
                    {

                        movies = csv.GetRecords<CsvMovie>().ToList();
                    }
                }
            return movies;
        }
    }
}
