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


    public IEnumerable<DbFavorie> FetchAll()
    {
        using var context = _contextProvider.NewContext();
        return context.Favorie.ToList();
    }

    public IEnumerable<DbFavorie> FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        return context.Favorie.ToList().Where(g => g.IdUserRef == id);
    }


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