using AutoMapper;
using GoldenRaspberryAwards.Data;
using GoldenRaspberryAwards.Dto;
using GoldenRaspberryAwards.Service;
using GoldenRaspberryAwards.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GoldenRaspberryAwards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;


        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<MovieReadDto>> GetMovies()
        {

            var movieItems = _movieService.GetAllMovies();

            return Ok(_mapper.Map<IEnumerable<MovieReadDto>>(movieItems));
        }
        [HttpGet]
        [Route("awards")]
        public ActionResult<ProducerAwardIntervalViewModel> GetAwards()
        {
            var movieItems = _movieService.GetAllAwards();

            return Ok(movieItems);
        }

    }
}
