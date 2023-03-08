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

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            PrepareDB.PrepPopulation(app);

            app.Run();
        }
    }
}