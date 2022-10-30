using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Movies.Dtos;

public class DtoInputCreateMovie
{
    [Required] public string NameMovie { get; set; }

    public int RuntimeMinute { get; set; }

    [Required] public string MovieType { get; set; }

    [Required] public string DescriptionMovie { get; set; }

    [Required] public string ImageMovie { get; set; }

    [Required] public string FilmGenre { get; set; }

    public string Director { get; set; }

    public string Release_movie { get; set; }
}