using GoldenRaspberryAwards.Models;
using GoldenRaspberryAwards.ViewModel;

namespace GoldenRaspberryAwards.Service
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        bool SaveChanges();

        ProducerAwardIntervalViewModel GetAllAwards();
    }
}
