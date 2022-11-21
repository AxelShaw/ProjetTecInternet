using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.RatingSerie.UseCaseRatingSerie;
using Infrastructure.Ef.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.RatingSerie;
[ApiController]
[Route("api/v1/ratingserie")]
public class RatingSerieController : ControllerBase
{
    private readonly UseCaseFetchAllRatingSeries _useCaseFetchAllRatingSeries;
    private readonly UseCaseCreateRatingSerie _useCaseCreateRatingSerie;
    private readonly UseCaseFetchRatingSerieById _useCaseFetchRatingSerieById;
    private readonly UseCaseDeleteRatingSerie _useCaseDeleteRatingSerie;
    private readonly UseCaseUpdateRatingSerie _useCaseUpdateRatingSerie;

    public RatingSerieController(UseCaseFetchAllRatingSeries useCaseFetchAllRatingSeries, UseCaseCreateRatingSerie useCaseCreateRatingSerie,
        UseCaseFetchRatingSerieById useCaseFetchRatingSerieById,UseCaseDeleteRatingSerie useCaseDeleteRatingSerie, UseCaseUpdateRatingSerie useCaseUpdateRatingSerie)
    {
        _useCaseFetchAllRatingSeries = useCaseFetchAllRatingSeries;
        _useCaseCreateRatingSerie = useCaseCreateRatingSerie;
        _useCaseFetchRatingSerieById = useCaseFetchRatingSerieById;
        _useCaseDeleteRatingSerie = useCaseDeleteRatingSerie;
        _useCaseUpdateRatingSerie = useCaseUpdateRatingSerie;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputRatingSerie>> FetchAll()
    {
        return Ok(_useCaseFetchAllRatingSeries.Execute());
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputRatingSerie> Create(DtoInputCreateRatingSerie dto)
    {
        var output = _useCaseCreateRatingSerie.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.SerieRefId },
            output
        );
    }
    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputRatingSerie>  Delete(int id)
    {
        try
        {
            return _useCaseDeleteRatingSerie.Execute(id);
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
    public ActionResult<DtoOutputRatingSerie> FetchById(int id)
    {
        try
        {
            return _useCaseFetchRatingSerieById.Execute(id);
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
    public ActionResult Update(DbRatingSerie ratingSerie)
    {
        return _useCaseUpdateRatingSerie.Execute(ratingSerie) ? NoContent() : NotFound();
    }
}