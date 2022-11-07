namespace Application.UseCases.Series.Dtos;

public class DtoOutputSerie
{
    public int IdSerie { get; set; }
    
    public string NameSerie { get; set; }

    public string SerieType { get; set; }
    
    public string DescriptionSerie { get; set; }
    
    public string ImageSerie { get; set; }
    
    public int NbSeason { get; set; }
}