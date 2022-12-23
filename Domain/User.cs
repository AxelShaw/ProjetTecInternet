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
    
    //Method to check if the password is secure
    public bool IsSecurePassword(string password)
    {
        //check that the password has at least 8 characters
        if (password.Length < 8)
        {
            return false;
        }
        //check that the password has at least 1 uppercase letter
        if (!password.Any(char.IsUpper))
        {
            return false;
        }
        //check that the password has at least 1 digit
        if (!password.Any(char.IsDigit))
        {
            return false;
        }

        return true;
    }

}