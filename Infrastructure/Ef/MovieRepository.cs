using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using Domain;
using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Ef;

public class MovieRepository : IMovieRepository
{
    private MovieContextProvider _contextProvider;
    private IMovieRepository _movieRepositoryImplementation;

    public MovieRepository(MovieContextProvider contextProvider)
    {   
        _contextProvider = contextProvider;
    }


    public IEnumerable<DbMovie> FetchAll()
    {
        using var context = _contextProvider.NewContext();
        return context.Movie.ToList();
    }

    public DbMovie FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        var movie = context.Movie.FirstOrDefault(g => g.IdMovie == id);

        if (movie == null)
            throw new KeyNotFoundException($"Movie with id {id} has not been found");

        return movie;
    }
    public IEnumerable<DbMovie> FetchByName(string name)
    {
        using var context = _contextProvider.NewContext();
        var movie = context.Movie.ToList().Where(g => g.NameMovie.ToLower().Contains(name.ToLower()));
        
        movie = movie.Take(5);

        if (movie == null)
            throw new KeyNotFoundException($"Comment Movie with id {name} has not been found");

        return movie;
    }
    
    public IEnumerable<DbMovie> FetchByGenre(string genre)
    {
        using var context = _contextProvider.NewContext();
        var movie = context.Movie.ToList().Where(g => g.FilmGenre.ToLower().Contains(genre.ToLower()));
        
        movie = movie.Take(500);

        if (movie == null)
            throw new KeyNotFoundException($"Comment Movie with id {genre} has not been found");

        return movie;
    }

    public DbMovie Create(string name, int minute, string type, string description, byte[] image, string genre,
        string director, string release)
    {
        using var context = _contextProvider.NewContext();
        var movie = new DbMovie
        {
            NameMovie = name,
            RuntimeMinute = minute,
            MovieType = type,
            DescriptionMovie = description,
            ImageMovie = image,
            FilmGenre = genre,
            Director = director,
            Release_movie = release
        };
        context.Movie.Add(movie);
        context.SaveChanges();
        return movie;
    }

    public bool Delete(int id)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.Movie.Remove(new DbMovie { IdMovie = id });
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    public bool Update(DbMovie movie)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.Movie.Update(movie);
            
            
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }
}
