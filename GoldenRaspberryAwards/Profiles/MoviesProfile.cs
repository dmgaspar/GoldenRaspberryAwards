namespace GoldenRaspberryAwards.Profiles
{
    using AutoMapper;
    using GoldenRaspberryAwards.Dto;
    using GoldenRaspberryAwards.Models;

    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            CreateMap<Movie, MovieReadDto>();
        }
    }
}
