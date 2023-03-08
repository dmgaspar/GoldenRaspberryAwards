using GoldenRaspberryAwards.Models;

namespace GoldenRaspberryAwards.Data
{
    public class MovieRepo : IMovieRepo
    {
        private readonly AppDbContext _context;

        public MovieRepo(AppDbContext context)
        {
            _context = context;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }

        IEnumerable<Movie> IMovieRepo.GetAllMovies()
        {
            return _context.Movies.ToList();
        }
    }
}
