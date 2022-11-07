using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface ISerieRepository
{
    IEnumerable<DbSerie> FetchAll();
    DbSerie FetchById(int id);
    DbSerie Create(string name, string type, string description, string image, int saison);
    bool Delete(int id);
    bool Update(DbSerie serie);

    

}