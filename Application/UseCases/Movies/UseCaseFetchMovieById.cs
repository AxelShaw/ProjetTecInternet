using Application.UseCases.Movies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

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
        var dbUser = _movieRepository.FetchById(id);
        return Mapper.GetInstance().Map<DtoOutputMovie>(dbUser);
    }
}