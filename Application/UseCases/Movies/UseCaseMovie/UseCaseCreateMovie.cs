using Application.UseCases.Movies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseCreateMovie : IUseCaseWriter<DtoOutputMovie, DtoInputCreateMovie>
{
    private readonly IMovieRepository _movieRepository;

    public UseCaseCreateMovie(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    //execute movie create method
    public DtoOutputMovie Execute(DtoInputCreateMovie input)
    {
        var dbMovie = _movieRepository.Create(input.NameMovie, input.RuntimeMinute, input.MovieType, input.DescriptionMovie, input.ImageMovie, input.FilmGenre, input.Director, input.Release_movie);
        return Mapper.GetInstance().Map<DtoOutputMovie>(dbMovie);
    }
}