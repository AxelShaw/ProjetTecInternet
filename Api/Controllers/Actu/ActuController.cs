using Application.UseCases.Actu.Dtos;
using Application.UseCases.Actu.UseCaseActu;
using Application.UseCases.Actu.UseCaseCommentMovie;
using Application.UseCases.Favorie.UseCaseCommentMovie;
using Infrastructure.Ef.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Actu;
[ApiController
]
[Route("api/v1/actu")]
public class ActuController : ControllerBase
{
    private readonly UseCaseFetchAllActu _useCaseFetchAllActu;
    private readonly UseCaseCreateActu _useCaseCreateActu;
    private readonly UseCaseFetchActuById _useCaseFetchActuById;
    private readonly UseCaseDeleteActu _useCaseDeleteActu;
    private readonly UseCaseDeleteByIdActu _useCaseDeleteByIdActu;
    private readonly UseCaseUpdateActu _useCaseUpdateActu;

    public ActuController(UseCaseFetchAllActu useCaseFetchAllActu,
        UseCaseCreateActu useCaseCreateActu, UseCaseFetchActuById useCaseFetchActuById,
        UseCaseDeleteActu useCaseDeleteActu, UseCaseUpdateActu useCaseUpdateActu, UseCaseDeleteByIdActu useCaseDeleteByIdActu)
    {
        _useCaseFetchAllActu = useCaseFetchAllActu;
        _useCaseCreateActu = useCaseCreateActu;
        _useCaseFetchActuById = useCaseFetchActuById;
        _useCaseDeleteActu = useCaseDeleteActu;
        _useCaseUpdateActu = useCaseUpdateActu;
        _useCaseDeleteByIdActu = useCaseDeleteByIdActu;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputActu>> FetchAll()
    {
        return Ok(_useCaseFetchAllActu.Execute());
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputActu> Create(DtoInputCreateActu dto)
    {
        var output = _useCaseCreateActu.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.IdActu },
            output
        );
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputActu>  Delete(int id)
    {
        try
        {
            return _useCaseDeleteActu.Execute(id);
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
    public ActionResult<DtoOutputActu>  DeleteById(int id)
    {
        try
        {
            return _useCaseDeleteByIdActu.Execute(id);
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
    public ActionResult<IEnumerable<DtoOutputActu>> FetchById(int id)
    {
        return Ok(_useCaseFetchActuById.Execute(id));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update(DbActu actu)
    {
        return _useCaseUpdateActu.Execute(actu) ? NoContent() : NotFound();
    }
}