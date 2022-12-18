using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Actu.Dtos;

public class DtoInputCreateActu
{
    [Required]public int IdMovieRef { get; set; }
    [Required]public string NewsActu { get; set; }
    [Required]public string Release_actu { get; set; }
}