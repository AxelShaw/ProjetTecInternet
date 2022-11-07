using Application.UseCases.Series.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases;

public class UseCaseFetchSerieById: IUseCaseParameterizedQuery<DtoOutputSerie, int>
{
    private readonly ISerieRepository _serieRepository;

    public UseCaseFetchSerieById(ISerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    public DtoOutputSerie Execute(int id)
    {
        var dbUser = _serieRepository.FetchById(id);
        return Mapper.GetInstance().Map<DtoOutputSerie>(dbUser);
    }
    
}