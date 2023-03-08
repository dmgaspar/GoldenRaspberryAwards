using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GoldenRaspberryAwards.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id{ get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Studio { get; set; }
        [Required]
        public string? Producers { get; set; }
        [Required]
        public string? Winner { get; set; }
    }
}
