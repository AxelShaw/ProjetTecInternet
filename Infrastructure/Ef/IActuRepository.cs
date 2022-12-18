using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IActuRepository
{
    IEnumerable<DbActu> FetchAll();
    
    IEnumerable<DbActu> FetchById(int id);

    DbActu Create(int IdMovieRef, string NewsActu, string Release_actu );
    
    bool Delete(int id);

    bool Update(DbActu dbActu);
}