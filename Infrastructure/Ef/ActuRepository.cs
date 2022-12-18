using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class ActuRepository :IActuRepository
{
    private MovieContextProvider _contextProvider;

    public ActuRepository(MovieContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }


    public IEnumerable<DbActu> FetchAll()
    {
        using var context = _contextProvider.NewContext();
        return context.Actu.ToList();
    }

    public IEnumerable<DbActu> FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        return context.Actu.ToList().Where(g => g.IdMovieRef == id);
    }


    public DbActu Create(int IdMovieRef, string NewsActu, string Release_actu )
    {
        using var context = _contextProvider.NewContext();
        var actu = new DbActu()
        {
            IdMovieRef = IdMovieRef,
            NewsActu = NewsActu,
            Release_actu = Release_actu
        };
        context.Actu.Add(actu);
        context.SaveChanges();
        return actu;
    }

    public bool Delete(int id)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.Actu.Where(g => g.IdMovieRef == id).ExecuteDelete();
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    public bool Update(DbActu actu)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.Actu.Update(actu);
            
            
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }
}