using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.RatingMovies.UseCaseRatingMovie;
using Infrastructure.Ef.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.RatingMovie;
[ApiController]
[Route("api/v1/ratingmovie")]
public class RatingMovieController : ControllerBase
{
    private readonly UseCaseFetchAllRatingMovies _useCaseFetchAllRatingMovies;
    private readonly UseCaseCreateRatingMovie _useCaseCreateRatingMovie;
    private readonly UseCaseFetchRatingMovieById _useCaseFetchRatingMovieById;
    private readonly UseCaseDeleteRatingMovie _useCaseDeleteRatingMovie;
    private readonly UseCaseUpdateRatingMovie _useCaseUpdateRatingMovie;
    private readonly UseCaseFetchAllRatingMoviesDown _useCaseFetchAllRatingMoviesDown;
    private readonly UseCaseFetchAllRatingMoviesTop _useCaseFetchAllRatingMoviesTop;


    public RatingMovieController(UseCaseFetchAllRatingMovies useCaseFetchAllRatingMovies, UseCaseCreateRatingMovie useCaseCreateRatingMovie,
        UseCaseFetchRatingMovieById useCaseFetchRatingMovieById,UseCaseDeleteRatingMovie useCaseDeleteRatingMovie, UseCaseUpdateRatingMovie useCaseUpdateRatingMovie, UseCaseFetchAllRatingMoviesDown useCaseFetchAllRatingMoviesDown, UseCaseFetchAllRatingMoviesTop useCaseFetchAllRatingMoviesTop)
    {
        _useCaseFetchAllRatingMovies = useCaseFetchAllRatingMovies;
        _useCaseCreateRatingMovie = useCaseCreateRatingMovie;
        _useCaseFetchRatingMovieById = useCaseFetchRatingMovieById;
        _useCaseDeleteRatingMovie = useCaseDeleteRatingMovie;
        _useCaseUpdateRatingMovie = useCaseUpdateRatingMovie;
        _useCaseFetchAllRatingMoviesDown = useCaseFetchAllRatingMoviesDown;
        _useCaseFetchAllRatingMoviesTop = useCaseFetchAllRatingMoviesTop;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputRatingMovie>> FetchAll()
    {
        return Ok(_useCaseFetchAllRatingMovies.Execute());
    }
    
    [HttpGet]
    [Route("Down")]
    public ActionResult<IEnumerable<DtoOutputRatingMovie>> FetchAllDown()
    {
        return Ok(_useCaseFetchAllRatingMoviesDown.Execute());
    }
    
    [HttpGet]
    [Route("Top")]
    public ActionResult<IEnumerable<DtoOutputRatingMovie>> FetchAllTop()
    {
        return Ok(_useCaseFetchAllRatingMoviesTop.Execute());
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputRatingMovie> Create(DtoInputCreateRatingMovie dto)
    {
        var output = _useCaseCreateRatingMovie.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.MovieRefId },
            output
        );
    }
    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputRatingMovie>  Delete(int id)
    {
        try
        {
            return _useCaseDeleteRatingMovie.Execute(id);
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
    public ActionResult<DtoOutputRatingMovie> FetchById(int id)
    {
        try
        {
            return _useCaseFetchRatingMovieById.Execute(id);
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
    public ActionResult Update(DbRatingMovie ratingMovie)
    {
        return _useCaseUpdateRatingMovie.Execute(ratingMovie) ? NoContent() : NotFound();
    }
    

    
}