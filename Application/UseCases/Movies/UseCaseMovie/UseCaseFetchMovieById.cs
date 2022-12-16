using Application.UseCases.Movies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases;

public class UseCaseFetchMovieById: IUseCaseParameterizedQuery<DtoOutputMovie, int>
{
    private readonly IMovieRepository _movieRepository;

    public UseCaseFetchMovieById(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public DtoOutputMovie Execute(int id)
    {
        var dbMovie = _movieRepository.FetchById(id);
        return Mapper.GetInstance().Map<DtoOutputMovie>(dbMovie);
    }
    
}