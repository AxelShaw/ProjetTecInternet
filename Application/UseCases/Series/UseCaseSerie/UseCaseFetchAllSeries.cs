using Application.UseCases.Series.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseFetchAllSeries : IUseCaseQuery<IEnumerable<DtoOutputSerie>>
{
    private readonly ISerieRepository _serieRepository;

    public UseCaseFetchAllSeries(ISerieRepository SerieRepository)
    {
        _serieRepository = SerieRepository;
    }

    public IEnumerable<DtoOutputSerie> Execute()
    {
        var dbUsers = _serieRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputSerie>>(dbUsers);
    }
}