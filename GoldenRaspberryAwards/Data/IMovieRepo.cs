using GoldenRaspberryAwards.Models;

namespace GoldenRaspberryAwards.Data
{
    public interface IMovieRepo
    {
        IEnumerable<Movie> GetAllMovies();
        bool SaveChanges();

    }
}
