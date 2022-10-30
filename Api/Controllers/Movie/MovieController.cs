using Application.UseCases;
using Application.UseCases.Movies;
using Application.UseCases.Movies.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Movie;

[ApiController]
[Route("api/v1/movie")]
public class MovieController : ControllerBase
{
    private readonly UseCaseFetchAllMovies _useCaseFetchAllMovies;
    private readonly UseCaseCreateMovie _useCaseCreateMovie;
    private readonly UseCaseFetchMovieById _useCaseFetchMovieById;

    public MovieController(UseCaseFetchAllMovies useCaseFetchAllMovies, UseCaseCreateMovie useCaseCreateMovie, UseCaseFetchMovieById useCaseFetchMovieById)
    {
        _useCaseFetchAllMovies = useCaseFetchAllMovies;
        _useCaseCreateMovie = useCaseCreateMovie;
        _useCaseFetchMovieById = useCaseFetchMovieById;
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
    
}