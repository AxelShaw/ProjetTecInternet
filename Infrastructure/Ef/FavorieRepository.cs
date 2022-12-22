using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class FavorieRepository :IFavorieRepository
{
    private MovieContextProvider _contextProvider;

    public FavorieRepository(MovieContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }


    //get all favorie
    public IEnumerable<DbFavorie> FetchAll()
    {
        using var context = _contextProvider.NewContext();
        return context.Favorie.ToList();
    }

    //get a favori by id
    public IEnumerable<DbFavorie> FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        return context.Favorie.ToList().Where(g => g.IdUserRef == id);
    }

    //create a favori 
    public DbFavorie Create(int IdMovieRef, int IdUserRef )
    {
        using var context = _contextProvider.NewContext();
        var favorie = new DbFavorie
        {
            IdMovieRef = IdMovieRef,
            IdUserRef = IdUserRef
        };
        context.Favorie.Add(favorie);
        context.SaveChanges();
        return favorie;
    }

    //delete a favori by movie
    public bool Delete(int id)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.Favorie.Where(g => g.IdMovieRef == id).ExecuteDelete();
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }
    
    //delete a favori by user
    public bool DeleteByUser(int id)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.Favorie.Where(g => g.IdUserRef == id).ExecuteDelete();
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    //delete a favori by id
    public bool DeleteById(int id)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.Favorie.Where(g => g.IdFav == id).ExecuteDelete();
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    //update a favori 
    public bool Update(DbFavorie favorie)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.Favorie.Update(favorie);
            
            
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }
}