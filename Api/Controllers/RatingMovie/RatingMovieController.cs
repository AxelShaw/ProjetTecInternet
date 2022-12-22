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
    private readonly UseCaseFetchAllRatingMoviesTopHome _useCaseFetchAllRatingMoviesTopHome;
    private readonly UseCaseFetchAllRatingMoviesDownHome _useCaseFetchAllRatingMoviesDownHome;


    public RatingMovieController(UseCaseFetchAllRatingMovies useCaseFetchAllRatingMovies, UseCaseCreateRatingMovie useCaseCreateRatingMovie,
        UseCaseFetchRatingMovieById useCaseFetchRatingMovieById,UseCaseDeleteRatingMovie useCaseDeleteRatingMovie, UseCaseUpdateRatingMovie useCaseUpdateRatingMovie, UseCaseFetchAllRatingMoviesDown useCaseFetchAllRatingMoviesDown, UseCaseFetchAllRatingMoviesTop useCaseFetchAllRatingMoviesTop, UseCaseFetchAllRatingMoviesTopHome useCaseFetchAllRatingMoviesTopHome, UseCaseFetchAllRatingMoviesDownHome useCaseFetchAllRatingMoviesDownHome)
    {
        _useCaseFetchAllRatingMovies = useCaseFetchAllRatingMovies;
        _useCaseCreateRatingMovie = useCaseCreateRatingMovie;
        _useCaseFetchRatingMovieById = useCaseFetchRatingMovieById;
        _useCaseDeleteRatingMovie = useCaseDeleteRatingMovie;
        _useCaseUpdateRatingMovie = useCaseUpdateRatingMovie;
        _useCaseFetchAllRatingMoviesDown = useCaseFetchAllRatingMoviesDown;
        _useCaseFetchAllRatingMoviesTop = useCaseFetchAllRatingMoviesTop;
        _useCaseFetchAllRatingMoviesTopHome = useCaseFetchAllRatingMoviesTopHome;
        _useCaseFetchAllRatingMoviesDownHome = useCaseFetchAllRatingMoviesDownHome;
    }
    
    //execute use case _useCaseFetchAllRatingMovies
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputRatingMovie>> FetchAll()
    {
        return Ok(_useCaseFetchAllRatingMovies.Execute());
    }
    //execute use case _useCaseFetchAllRatingMoviesDown
    [HttpGet]
    [Route("Down")]
    public ActionResult<IEnumerable<DtoOutputRatingMovie>> FetchAllDown()
    {
        return Ok(_useCaseFetchAllRatingMoviesDown.Execute());
    }
    //execute use case _useCaseFetchAllRatingMoviesTop
    [HttpGet]
    [Route("Top")]
    public ActionResult<IEnumerable<DtoOutputRatingMovie>> FetchAllTop()
    {
        return Ok(_useCaseFetchAllRatingMoviesTop.Execute());
    }
    //execute use case _useCaseFetchAllRatingMoviesDownHome
    [HttpGet]
    [Route("DownHome")]
    public ActionResult<IEnumerable<DtoOutputRatingMovie>> FetchAllDownHome()
    {
        return Ok(_useCaseFetchAllRatingMoviesDownHome.Execute());
    }
    //execute use case _useCaseFetchAllRatingMoviesTopHome
    [HttpGet]
    [Route("TopHome")]
    public ActionResult<IEnumerable<DtoOutputRatingMovie>> FetchAllTopHome()
    {
        return Ok(_useCaseFetchAllRatingMoviesTopHome.Execute());
    }
    //execute use case _useCaseCreateRatingMovie
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
    //execute use case _useCaseDeleteRatingMovie
    //execute use case _useCaseDeleteRatingMovie
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
    //execute use case _useCaseFetchRatingMovieById
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
    //execute use case _useCaseUpdateRatingMovie
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update(DbRatingMovie ratingMovie)
    {
        return _useCaseUpdateRatingMovie.Execute(ratingMovie) ? NoContent() : NotFound();
    }
    

    
}