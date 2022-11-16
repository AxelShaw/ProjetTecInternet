using Domain;
using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IRatingMovieRepository
{
    IEnumerable<DbRatingMovie> FetchAll();
    DbRatingMovie FetchById(int id);
    DbRatingMovie Create(int average_rating, int numVote, int MovieRefId );
    bool Delete(int id);
    bool Update(DbRatingMovie dbRatingMovie);
}