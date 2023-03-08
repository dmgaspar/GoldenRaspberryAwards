using System.ComponentModel.DataAnnotations;

namespace GoldenRaspberryAwards.Dto
{
    public class MovieReadDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string? Title { get; set; }
        public string? Studio { get; set; }
        public string? Producers { get; set; }
        public string? Winner { get; set; }
    }
}
