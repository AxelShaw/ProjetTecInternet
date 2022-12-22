using System.Text.RegularExpressions;

namespace Domain;

public class User
{
    public int IdUser { get; set; }
    
    public string last_name { get; set; }
    
    public string first_name { get; set; }
    
    public string mail { get; set; }
    
    public string password { get; set; }
    
    public string role { get; set; }
    
    public byte[] profil_picture { get; set; }

    public bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        return Regex.IsMatch(email, pattern);
    }

}