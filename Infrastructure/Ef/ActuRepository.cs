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

    //get all news 
    public IEnumerable<DbActu> FetchAll()
    {
        using var context = _contextProvider.NewContext();
        return context.Actu.ToList();
    }
    
    //get by id a news
    public IEnumerable<DbActu> FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        return context.Actu.ToList().Where(g => g.IdMovieRef == id);
    }

    //create a news 
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

    //delete a news
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
    //delete by id news
    public bool DeleteById(int id)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.Actu.Where(g => g.IdActu == id).ExecuteDelete();
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    //update a news
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