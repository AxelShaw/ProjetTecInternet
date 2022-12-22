using Application.UseCases.Movies.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseFetchAllMovies : IUseCaseQuery<IEnumerable<DtoOutputMovie>>
{
    private readonly IMovieRepository _movieRepository;

    public UseCaseFetchAllMovies(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    //execute movie get all method
    public IEnumerable<DtoOutputMovie> Execute()
    {
        var dbMovie = _movieRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputMovie>>(dbMovie);
    }
}