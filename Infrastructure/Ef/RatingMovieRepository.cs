using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class RatingMovieRepository : IRatingMovieRepository
{
    private MovieContextProvider _contextProvider;

    public RatingMovieRepository(MovieContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }


    public IEnumerable<DbRatingMovie> FetchAll()
    {
        using var context = _contextProvider.NewContext();
        return context.RatingMovie.ToList();
    }

    public DbRatingMovie FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        var ratingMovie = context.RatingMovie.FirstOrDefault(g => g.MovieRefId == id);

        if (ratingMovie == null)
            throw new KeyNotFoundException($"Rating Movie with id {id} has not been found");

        return ratingMovie;
    }

    public DbRatingMovie Create(int average_rating, int numVote, int movieRefId )
    {
        using var context = _contextProvider.NewContext();
        var ratingMovie = new DbRatingMovie
        {
            NumVote = numVote,
            Average_rating = average_rating,
            MovieRefId = movieRefId
        };
        context.RatingMovie.Add(ratingMovie);
        context.SaveChanges();
        return ratingMovie;
    }

    public bool Delete(int id)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.RatingMovie.Remove(new DbRatingMovie { MovieRefId = id });
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    public bool Update(DbRatingMovie ratingMovie)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.RatingMovie.Update(ratingMovie);
            
            
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }
    
    public IEnumerable<DbRatingMovie> FetchAllDown()
    {
        using var context = _contextProvider.NewContext();
        var rating = context.RatingMovie.OrderBy(r => r.Average_rating).ToList().Where(g => g.NumVote != 0);
        
        rating = rating.Take(500);

        return rating;
    }

    public IEnumerable<DbRatingMovie> FetchAllTopHome()
    {
        using var context = _contextProvider.NewContext();
        var rating = context.RatingMovie.OrderByDescending(r => r.Average_rating).ToList().Where(g => g.NumVote != 0);

        return rating;
    }

    public IEnumerable<DbRatingMovie> FetchAllDownHome()
    {
        using var context = _contextProvider.NewContext();
        var rating = context.RatingMovie.OrderBy(r => r.Average_rating).ToList().Where(g => g.NumVote != 0);
        return rating;
    }

    public IEnumerable<DbRatingMovie> FetchAllTop()
    {
        using var context = _contextProvider.NewContext();
        var rating = context.RatingMovie.OrderByDescending(r => r.Average_rating).ToList().Where(g => g.NumVote != 0);
        
        rating = rating.Take(500);

        return rating;
    }

}