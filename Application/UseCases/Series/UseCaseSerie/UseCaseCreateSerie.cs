using Application.UseCases.Series.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Series.UseCaseSerie;

public class UseCaseCreateSerie : IUseCaseWriter<DtoOutputSerie, DtoInputCreateSerie>
{
    private readonly ISerieRepository _serieRepository;

    public UseCaseCreateSerie(ISerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }
    
    
    public DtoOutputSerie Execute(DtoInputCreateSerie input)
    {
        var dbSerie = _serieRepository.Create(input.NameSerie, input.SerieType, input.DescriptionSerie, input.ImageSerie, input.NbSeason);
        return Mapper.GetInstance().Map<DtoOutputSerie>(dbSerie);
    }
}