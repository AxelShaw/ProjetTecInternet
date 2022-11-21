using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.CommentSeries.Dtos;

public class DtoInputCreateCommentSerie
{
    [Required]public int Rating { get; set; }
    public string CommentText { get; set; }

    [Required]public int IdSerieRef{ get; set; }
    [Required]public int IdUserRef{ get; set; }
}