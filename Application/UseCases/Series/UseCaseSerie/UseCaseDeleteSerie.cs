using Application.UseCases.Series.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases;

public class UseCaseDeleteSerie: IUseCaseParameterizedQuery<DtoOutputSerie, int>
{
    private readonly ISerieRepository _serieRepository;

    public UseCaseDeleteSerie(ISerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    public DtoOutputSerie Execute(int id)
    {
        var dbUser = _serieRepository.Delete(id);
        return Mapper.GetInstance().Map<DtoOutputSerie>(dbUser);
    }


}