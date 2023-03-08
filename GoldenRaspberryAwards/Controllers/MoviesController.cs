using AutoMapper;
using GoldenRaspberryAwards.Data;
using GoldenRaspberryAwards.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GoldenRaspberryAwards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepo _repository;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepo movieRepo, IMapper mapper)
        {
            _repository = movieRepo;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<MovieReadDto>> GetMovies()
        {

            var movieItems = _repository.GetAllMovies();

            return Ok(_mapper.Map<IEnumerable<MovieReadDto>>(movieItems));
        }
            
    }
}
