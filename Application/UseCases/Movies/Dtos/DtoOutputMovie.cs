namespace Application.UseCases.Movies.Dtos;

public class DtoOutputMovie
{
    public int IdMovie { get; set; }

    public string NameMovie { get; set; }

    public int RuntimeMinute { get; set; }

    public string MovieType { get; set; }

    public string DescriptionMovie { get; set; }

    public byte[] ImageMovie { get; set; }

    public string FilmGenre { get; set; }

    public string Director { get; set; }

    public string Release_movie { get; set; }
}