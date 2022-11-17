using Application.UseCases;
using Application.UseCases.Movies.Dtos;
using Infrastructure.Ef.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Movie;

[ApiController]
[Route("api/v1/movie")]
public class MovieController : ControllerBase
{
    private readonly UseCaseFetchAllMovies _useCaseFetchAllMovies;
    private readonly UseCaseCreateMovie _useCaseCreateMovie;
    private readonly UseCaseFetchMovieById _useCaseFetchMovieById;
    private readonly UseCaseFetchMovieByName _useCaseFetchMovieByName;
    private readonly UseCaseDeleteMovie _useCaseDeleteMovie;
    private readonly UseCaseUpdateMovie _useCaseUpdateMovie;

    public MovieController(UseCaseFetchAllMovies useCaseFetchAllMovies, UseCaseCreateMovie useCaseCreateMovie,
        UseCaseFetchMovieById useCaseFetchMovieById,UseCaseDeleteMovie useCaseDeleteMovie,
        UseCaseUpdateMovie useCaseUpdateMovie, UseCaseFetchMovieByName useCaseFetchMovieByName)
    {
        _useCaseFetchAllMovies = useCaseFetchAllMovies;
        _useCaseCreateMovie = useCaseCreateMovie;
        _useCaseFetchMovieById = useCaseFetchMovieById;
        _useCaseDeleteMovie = useCaseDeleteMovie;
        _useCaseUpdateMovie = useCaseUpdateMovie;
        _useCaseFetchMovieByName = useCaseFetchMovieByName;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputMovie>> FetchAll()
    {
        return Ok(_useCaseFetchAllMovies.Execute());
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputMovie> Create(DtoInputCreateMovie dto)
    {
        var output = _useCaseCreateMovie.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.IdMovie },
            output
        );
    }
    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputMovie>  Delete(int id)
    {
        try
        {
            return _useCaseDeleteMovie.Execute(id);
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
    public ActionResult<DtoOutputMovie> FetchById(int id)
    {
        try
        {
            return _useCaseFetchMovieById.Execute(id);
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
    [Route("{:string}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputMovie> FetchByName(string name)
    {
        try
        {
            return _useCaseFetchMovieByName.Execute(name);
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
    public ActionResult Update(DbMovie movie)
    {
        return _useCaseUpdateMovie.Execute(movie) ? NoContent() : NotFound();
    }
    
}