using Application.UseCases;
using Application.UseCases.Series.Dtos;
using Application.UseCases.Series.UseCaseSerie;
using Infrastructure.Ef.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Serie;

[ApiController]
[Route("api/v1/serie")]
public class SerieController : ControllerBase
{
    private readonly UseCaseFetchAllSeries _useCaseFetchAllSeries;
    private readonly UseCaseCreateSerie _useCaseCreateSerie;
    private readonly UseCaseFetchSerieById _useCaseFetchSerieById;
    private readonly UseCaseDeleteSerie _useCaseDeleteSerie;
    private readonly UseCaseUpdateSerie _useCaseUpdateSerie;

    public SerieController(UseCaseFetchAllSeries useCaseFetchAllSeries, UseCaseCreateSerie useCaseCreateSerie,
        UseCaseFetchSerieById useCaseFetchSerieById,UseCaseDeleteSerie useCaseDeleteSerie, UseCaseUpdateSerie useCaseUpdateSerie)
    {
        _useCaseFetchAllSeries = useCaseFetchAllSeries;
        _useCaseCreateSerie = useCaseCreateSerie;
        _useCaseFetchSerieById = useCaseFetchSerieById;
        _useCaseDeleteSerie = useCaseDeleteSerie;
        _useCaseUpdateSerie = useCaseUpdateSerie;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputSerie>> FetchAll()
    {
        return Ok(_useCaseFetchAllSeries.Execute());
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputSerie> Create(DtoInputCreateSerie dto)
    {
        var output = _useCaseCreateSerie.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.IdSerie },
            output
        );
    }
    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputSerie>  Delete(int id)
    {
        try
        {
            return _useCaseDeleteSerie.Execute(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputSerie> FetchById(int id)
    {
        try
        {
            return _useCaseFetchSerieById.Execute(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update(DbSerie serie)
    {
        return _useCaseUpdateSerie.Execute(serie) ? NoContent() : NotFound();
    }
    
}