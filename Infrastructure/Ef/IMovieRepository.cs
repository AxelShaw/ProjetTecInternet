using Infrastructure.Ef.DbEntities;


namespace Infrastructure.Ef;

public interface IMovieRepository
{
    IEnumerable<DbMovie> FetchAll();
    DbMovie FetchById(int id);
    DbMovie Create(string name, int minute, string type, string description, string image, string genre, string director, string release);
    

}