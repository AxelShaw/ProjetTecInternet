using Domain;
using Infrastructure.Ef.DbEntities;


namespace Infrastructure.Ef;

public interface IMovieRepository
{
    IEnumerable<DbMovie> FetchAll();
    DbMovie FetchById(int id);
    IEnumerable<DbMovie> FetchByName(string name);
    DbMovie Create(string name, int minute, string type, string description, string image, string genre, string director, string release);
    bool Delete(int id);
    bool Update(DbMovie movie);

    

}