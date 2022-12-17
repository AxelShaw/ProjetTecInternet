using Application.UseCases.CommentSeries.Dtos;
using Application.UseCases.CommentSeries.UseCase;
using Infrastructure.Ef.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.CommentSerie;

[ApiController]
[Route("api/v1/commentserie")]
public class CommentSerieController : ControllerBase
{
    private readonly UseCaseFetchAllCommentSeries _useCaseFetchAllCommentSeries;
    private readonly UseCaseCreateCommentSerie _useCaseCreateCommentSerie;
    private readonly UseCaseFetchCommentSerieById _useCaseFetchCommentSerieById;
    private readonly UseCaseDeleteCommentSerie _useCaseDeleteCommentSerie;
    private readonly UseCaseUpdateCommentSerie _useCaseUpdateCommentSerie;

    public CommentSerieController(UseCaseFetchAllCommentSeries useCaseFetchAllCommentSeries, UseCaseCreateCommentSerie useCaseCreateCommentSerie,
        UseCaseFetchCommentSerieById useCaseFetchCommentSerieById,UseCaseDeleteCommentSerie useCaseDeleteCommentSerie, UseCaseUpdateCommentSerie useCaseUpdateCommentSerie)
    {
        _useCaseFetchAllCommentSeries = useCaseFetchAllCommentSeries;
        _useCaseCreateCommentSerie = useCaseCreateCommentSerie;
        _useCaseFetchCommentSerieById = useCaseFetchCommentSerieById;
        _useCaseDeleteCommentSerie = useCaseDeleteCommentSerie;
        _useCaseUpdateCommentSerie = useCaseUpdateCommentSerie;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputCommentSerie>> FetchAll()
    {
        return Ok(_useCaseFetchAllCommentSeries.Execute());
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputCommentSerie> Create(DtoInputCreateCommentSerie dto)
    {
        var output = _useCaseCreateCommentSerie.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.IdComSerie },
            output
        );
    }
    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputCommentSerie>  Delete(int id)
    {
        try
        {
            return _useCaseDeleteCommentSerie.Execute(id);
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
    public ActionResult<DtoOutputCommentSerie> FetchById(int id)
    {
        try
        {
            return _useCaseFetchCommentSerieById.Execute(id);
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
    public ActionResult Update(DbCommentSerie commentSerie)
    {
        return _useCaseUpdateCommentSerie.Execute(commentSerie) ? NoContent() : NotFound();
    }
 
}