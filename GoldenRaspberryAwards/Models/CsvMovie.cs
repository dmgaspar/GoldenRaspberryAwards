using CsvHelper.Configuration.Attributes;

namespace GoldenRaspberryAwards.Models
{
    public class CsvMovie
    {
        [Name("year")]
        public int Year { get; set; }
        [Name("title")]
        public string? Title { get; set; }
        [Name("studios")]
        public string? Studio { get; set; }
        [Name("producers")]
        public string? Producers { get; set; }
        [Name("winner")]
        public string? Winner { get; set; }

    }
}