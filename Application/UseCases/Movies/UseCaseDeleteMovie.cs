using Application.UseCases.Movies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseDeleteMovie: IUseCaseParameterizedQuery<DtoOutputMovie, int>
{
    private readonly IMovieRepository _movieRepository;

    public UseCaseDeleteMovie(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public DtoOutputMovie Execute(int id)
    {
        var dbUser = _movieRepository.Delete(id);
        return Mapper.GetInstance().Map<DtoOutputMovie>(dbUser);
    }
}