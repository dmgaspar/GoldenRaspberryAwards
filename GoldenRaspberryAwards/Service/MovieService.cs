using GoldenRaspberryAwards.Data;
using GoldenRaspberryAwards.Models;
using GoldenRaspberryAwards.ViewModel;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace GoldenRaspberryAwards.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepo _moveRepository;

        public MovieService(IMovieRepo movieRepo)
        {
            _moveRepository = movieRepo;
        }

        public ProducerAwardIntervalViewModel GetAllAwards()
        {
            List<Movie> movies = _moveRepository.GetAllMovies().ToList();

            var awards = ExtractProducerAwardsIntervals(movies);

            return FindMinMaxInternalProducer(awards);
        }


        public IEnumerable<Movie> GetAllMovies()
        {
            return _moveRepository.GetAllMovies();
        }

        public bool SaveChanges()
        {
            return _moveRepository.SaveChanges();
        }


        private List<AwardViewModel> ExtractProducerAwardsIntervals(List<Movie> movies)
        {
            string curProducer = "";
            int beginYear = 0;
            int endYear = 0;
            int curInterval = 0;
            int producerCount = 0;

            List<AwardViewModel> awards = new List<AwardViewModel>();

            AwardViewModel temp = new AwardViewModel();

            var sortedList = movies.OrderBy(p => p.Producers).ToList();

            foreach (var movie in sortedList)
            {
                if (curProducer != movie.Producers)
                {
                    if (producerCount > 0)
                    {
                        awards.Add(temp);
                    }
                    curProducer = movie.Producers;
                    beginYear = movie.Year;
                    producerCount = 0;
                }
                else
                {
                    endYear = movie.Year;
                    curInterval = endYear - beginYear;

                    temp = new AwardViewModel
                    {
                        Producer = movie.Producers,
                        Interval = curInterval,
                        PreviousWin = beginYear,
                        FollowingWin = endYear
                    };
                    producerCount++;
                }
            }
            return awards;
        }


        private ProducerAwardIntervalViewModel FindMinMaxInternalProducer(List<AwardViewModel> awards)
        {
            var sortedList = awards.OrderBy(p => p.Interval).ToList();

            ProducerAwardIntervalViewModel producerAwardInterval = new ProducerAwardIntervalViewModel();

            int interval = 0;
            for (int i = 0; i < sortedList.Count; i++)
            {
                if(i == 0)
                {
                    interval = awards[i].Interval;
                    producerAwardInterval.Min.Add(awards[i]);
                }
                else if (interval == awards[i].Interval)
                {
                    producerAwardInterval.Min.Add(awards[i]);
                }
                else
                {
                    break;
                }
            }

            for (int i = sortedList.Count -1 ; i >= 0; i--)
            {
                if (i == sortedList.Count - 1)
                {
                    interval = awards[i].Interval;
                    producerAwardInterval.Max.Add(awards[i]);
                }
                else if (interval == awards[i].Interval)
                {
                    producerAwardInterval.Max.Add(awards[i]);
                }
                else
                {
                    break;
                }
            }

            return producerAwardInterval;
        }
    }
}
