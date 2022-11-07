using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Series.Dtos;

public class DtoInputCreateSerie
{

    [Required] public string NameSerie { get; set; }

    [Required] public string SerieType { get; set; }
    
    [Required] public string DescriptionSerie { get; set; }
    
    [Required] public string ImageSerie { get; set; }
    
    public int NbSeason { get; set; }
}