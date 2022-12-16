using Application.UseCases.Movies.Dtos;
using Application.UseCases.Utils;
using Domain;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases;

public class UseCaseUpdateMovie : IUseCaseParameterizedQueryUp<DtoOutputMovie, Movie>
{
    private readonly IMovieRepository _movieRepository;

    public UseCaseUpdateMovie(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public bool Execute(DbMovie movie)
    {
        var dbMovie = _movieRepository.Update(movie);
        return Mapper.GetInstance().Map<bool>(dbMovie);
    }
    
}