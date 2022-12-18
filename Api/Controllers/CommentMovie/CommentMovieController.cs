using Application.UseCases.CommentMovies.Dtos;
using Application.UseCases.CommentMovies.UseCaseCommentMovie;
using Infrastructure.Ef.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.CommentMovie;
[ApiController]
[Route("api/v1/commentmovie")]
public class CommentMovieController : ControllerBase
{
    private readonly UseCaseFetchAllCommentMovies _useCaseFetchAllCommentMovies;
    private readonly UseCaseCreateCommentMovie _useCaseCreateCommentMovie;
    private readonly UseCaseFetchCommentMovieById _useCaseFetchCommentMovieById;
    private readonly UseCaseDeleteCommentMovie _useCaseDeleteCommentMovie;
    private readonly UseCaseUpdateCommentMovie _useCaseUpdateCommentMovie;
    private readonly UseCaseDeleteCommentMovieByUser _useCaseDeleteCommentMovieByUser;
    private readonly UseCaseDeleteCommentMovieById _useCaseDeleteCommentMovieById;

    public CommentMovieController(UseCaseFetchAllCommentMovies useCaseFetchAllCommentMovies,
        UseCaseCreateCommentMovie useCaseCreateCommentMovie, UseCaseFetchCommentMovieById useCaseFetchCommentMovieById,
        UseCaseDeleteCommentMovie useCaseDeleteCommentMovie, UseCaseUpdateCommentMovie useCaseUpdateCommentMovie,
        UseCaseDeleteCommentMovieByUser useCaseDeleteCommentMovieByUser, UseCaseDeleteCommentMovieById useCaseDeleteCommentMovieById)
    {
        _useCaseFetchAllCommentMovies = useCaseFetchAllCommentMovies;
        _useCaseCreateCommentMovie = useCaseCreateCommentMovie;
        _useCaseFetchCommentMovieById = useCaseFetchCommentMovieById;
        _useCaseDeleteCommentMovie = useCaseDeleteCommentMovie;
        _useCaseUpdateCommentMovie = useCaseUpdateCommentMovie;
        _useCaseDeleteCommentMovieByUser = useCaseDeleteCommentMovieByUser;
        _useCaseDeleteCommentMovieById = useCaseDeleteCommentMovieById;
    }
    
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputCommentMovie>> FetchAll()
    {
        return Ok(_useCaseFetchAllCommentMovies.Execute());
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputCommentMovie> Create(DtoInputCreateCommentMovie dto)
    {
        var output = _useCaseCreateCommentMovie.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.IdComMovie },
            output
        );
    }
    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputCommentMovie>  Delete(int id)
    {
        try
        {
            return _useCaseDeleteCommentMovie.Execute(id);
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
    public ActionResult<IEnumerable<DtoOutputCommentMovie>> FetchById(int id)
    {
        return Ok(_useCaseFetchCommentMovieById.Execute(id));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update(DbCommentMovie commentMovie)
    {
        return _useCaseUpdateCommentMovie.Execute(commentMovie) ? NoContent() : NotFound();
    }
    [HttpDelete]
    [Route("deletebyuser/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputCommentMovie>  DeleteByUser(int id)
    {
        try
        {
            return _useCaseDeleteCommentMovieByUser.Execute(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
    [HttpDelete]
    [Route("id/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputCommentMovie>  DeleteById(int id)
    {
        try
        {
            return _useCaseDeleteCommentMovieById.Execute(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
}