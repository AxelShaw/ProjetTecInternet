using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IRatingSerieRepository
{
    IEnumerable<DbRatingSerie> FetchAll();
    DbRatingSerie FetchById(int id);
    DbRatingSerie Create(int average_rating, int numVote, int SerieRefId );
    bool Delete(int id);
    bool Update(DbRatingSerie dbRatingSerie);
}