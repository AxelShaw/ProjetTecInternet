using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface ICommentMovieRepository
{
    IEnumerable<DbCommentMovie> FetchAll();
    IEnumerable<DbCommentMovie> FetchById(int id);

    DbCommentMovie Create(int rating, string commentText, int IdMovieRef, int IdUserRef );
    bool Delete(int id);
    bool Update(DbCommentMovie dbCommentMovie);

    bool DeleteByUser(int id);
}