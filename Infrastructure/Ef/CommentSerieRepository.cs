using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class CommentSerieRepository : ICommentSerieRepository
{
    private MovieContextProvider _contextProvider;

    public CommentSerieRepository(MovieContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }


    public IEnumerable<DbCommentSerie> FetchAll()
    {
        using var context = _contextProvider.NewContext();
        return context.CommentSerie.ToList();
    }

    public DbCommentSerie FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        var commentSerie = context.CommentSerie.FirstOrDefault(g => g.IdComSerie == id);

        if (commentSerie == null)
            throw new KeyNotFoundException($"Comment Serie with id {id} has not been found");

        return commentSerie;
    }


    public DbCommentSerie Create(int rating, string commentText, int IdSerieRef, int IdUserRef )
    {
        using var context = _contextProvider.NewContext();
        var commentSerie = new DbCommentSerie
        {
            Rating = rating,
            CommentText = commentText,
            IdSerieRef = IdSerieRef,
            IdUserRef = IdUserRef
        };
        context.CommentSerie.Add(commentSerie);
        context.SaveChanges();
        return commentSerie;
    }

    public bool Delete(int id)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.CommentSerie.Remove(new DbCommentSerie { IdComSerie = id });
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    public bool Update(DbCommentSerie commentSerie)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.CommentSerie.Update(commentSerie);
            
            
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }
}