using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Users.Dtos;

public class DtoInputCreateUser
{

    [Required] public int IdUser { get; set; }
    [Required] public string last_name { get; set; }
    [Required] public string first_name { get; set; }
    [Required] public string mail { get; set; }
    [Required] public string nickname { get; set; }
    
    [Required] public string password { get; set; }
    
    public string role { get; set; }
    
    public string profil_picture { get; set; }
}
