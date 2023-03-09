using GoldenRaspberryAwards.Data;
using GoldenRaspberryAwards.Models;
using GoldenRaspberryAwards.ViewModel;

namespace GoldenRaspberryAwards.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepo _moveRepository;

        public MovieService(IMovieRepo movieRepo)
        {
            _moveRepository = movieRepo;
        }

        public IEnumerable<AwardViewModel> GetAllAwards()
        {
            List<Movie> movies = _moveRepository.GetAllMovies().ToList();

            var sortedList = movies.OrderBy(p => p.Producers).ToList();

            List<AwardViewModel> awards = new List<AwardViewModel>();

            foreach (var movie in sortedList)
            {
                awards.Add(new AwardViewModel
                {
                    Producer = movie.Producers,
                    Interval = 1,
                    PreviousWin = movie.Year,
                    FollowingWin = movie.Year
                });
            }

            return awards;

        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _moveRepository.GetAllMovies();
        }

        public bool SaveChanges()
        {
            return _moveRepository.SaveChanges();
        }
    }
}
