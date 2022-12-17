using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Favorie.Dtos;

public class DtoInputCreateFavorie
{
    [Required]public int IdMovieRef{ get; set; }
    [Required]public int IdUserRef{ get; set; }
}