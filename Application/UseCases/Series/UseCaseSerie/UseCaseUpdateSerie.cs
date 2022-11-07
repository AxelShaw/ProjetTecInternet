using Application.UseCases.Series.Dtos;
using Application.UseCases.Utils;
using Domain;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases;

public class UseCaseUpdateSerie : IUseCaseParameterizedQueryUpSerie<DtoOutputSerie, Serie>
{
    private readonly ISerieRepository _serieRepository;

    public UseCaseUpdateSerie(ISerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    public bool Execute(DbSerie serie)
    {
        var dbUser = _serieRepository.Update(serie);
        return Mapper.GetInstance().Map<bool>(dbUser);
    }
    
}