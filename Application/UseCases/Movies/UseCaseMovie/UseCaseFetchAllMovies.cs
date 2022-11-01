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

    public IEnumerable<DtoOutputMovie> Execute()
    {
        var dbUsers = _movieRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputMovie>>(dbUsers);
    }
}