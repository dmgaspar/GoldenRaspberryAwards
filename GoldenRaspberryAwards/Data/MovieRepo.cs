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
            throw new NotImplementedException();
        }
    }
}
