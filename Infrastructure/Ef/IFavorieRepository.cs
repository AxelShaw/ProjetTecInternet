using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IFavorieRepository
{
    IEnumerable<DbFavorie> FetchAll();
    
    IEnumerable<DbFavorie> FetchById(int id);

    DbFavorie Create(int IdMovieRef, int IdUserRef );
    
    bool Delete(int id);
    
    bool Update(DbFavorie dbCommentMovie);
}