using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class SerieRepository : ISerieRepository
{
    private MovieContextProvider _contextProvider;

    public SerieRepository(MovieContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }


    public IEnumerable<DbSerie> FetchAll()
    {
        using var context = _contextProvider.NewContext();
        return context.Serie.ToList();
    }

    public DbSerie FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        var serie = context.Serie.FirstOrDefault(g => g.IdSerie == id);

        if (serie == null)
            throw new KeyNotFoundException($"Serie with id {id} has not been found");

        return serie;
    }

    public DbSerie Create(string name, string type, string description, string image, int saison)
    {
        using var context = _contextProvider.NewContext();
        var serie = new DbSerie
        {
            NameSerie = name,
            SerieType = type,
            DescriptionSerie = description,
            ImageSerie = image,
            NbSeason = saison
        };
        context.Serie.Add(serie);
        context.SaveChanges();
        return serie;
    }

    public bool Delete(int id)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.Serie.Remove(new DbSerie { IdSerie = id });
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    public bool Update(DbSerie serie)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.Serie.Update(serie);
            
            
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }
}