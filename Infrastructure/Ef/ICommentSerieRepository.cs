using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface ICommentSerieRepository
{
    IEnumerable<DbCommentSerie> FetchAll();
    DbCommentSerie FetchById(int id);

    DbCommentSerie Create(int rating, string commentText, int IdSerieRef, int IdUserRef );
    bool Delete(int id);
    bool Update(DbCommentSerie dbCommentSerie);
}