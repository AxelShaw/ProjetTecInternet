using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class RatingSerieRepository : IRatingSerieRepository
{
    private MovieContextProvider _contextProvider;

    public RatingSerieRepository(MovieContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }


    public IEnumerable<DbRatingSerie> FetchAll()
    {
        using var context = _contextProvider.NewContext();
        return context.RatingSerie.ToList();
    }

    public DbRatingSerie FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        var ratingSerie = context.RatingSerie.FirstOrDefault(g => g.SerieRefId == id);

        if (ratingSerie == null)
            throw new KeyNotFoundException($"Rating Serie with id {id} has not been found");

        return ratingSerie;
    }

    public DbRatingSerie Create(int average_rating, int numVote, int SerieRefId )
    {
        using var context = _contextProvider.NewContext();
        var ratingSerie = new DbRatingSerie
        {
            NumVote = numVote,
            Average_rating = average_rating,
            SerieRefId = SerieRefId
        };
        context.RatingSerie.Add(ratingSerie);
        context.SaveChanges();
        return ratingSerie;
    }

    public bool Delete(int id)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.RatingSerie.Remove(new DbRatingSerie { SerieRefId = id });
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    public bool Update(DbRatingSerie ratingSerie)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.RatingSerie.Update(ratingSerie);
            
            
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }
}