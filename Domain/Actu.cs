using System.Globalization;
using System.Text.RegularExpressions;

namespace Domain;

public class Actu
{
    public int IdActu{ get; set; }
    public int IdMovieRef { get; set; }
    public string NewsActu { get; set; }
    public string Release_actu { get; set; }

    public bool IsValidateDate(string releaseDate)
    {
        /*bool pattern  = DateTime.TryParseExact(actu.Release_actu, "MM/dd/yyyy",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        
        return Regex.IsMatch(releaseDate, pattern);*/
        
        return DateTime.TryParseExact(releaseDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    }
}