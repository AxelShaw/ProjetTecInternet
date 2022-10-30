using Domain;
using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class MovieContext : DbContext
{
    private readonly IConnectionStringProvider _connectionStringProvider;
    
    public MovieContext(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }
    
    public DbSet<DbMovie> Movie { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionStringProvider.Get("db"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbMovie>(entity =>
        {
            entity.ToTable("MOVIE");
            entity.HasKey(m => m.IdMovie);
            entity.Property(m => m.IdMovie).HasColumnName("IdMovie");
            entity.Property(m => m.NameMovie).HasColumnName("NameMovie");
            entity.Property(m => m.RuntimeMinute).HasColumnName("RuntimeMinute");
            entity.Property(m => m.MovieType).HasColumnName("MovieType");
            entity.Property(m => m.DescriptionMovie).HasColumnName("DescriptionMovie");
            entity.Property(m => m.ImageMovie).HasColumnName("ImageMovie");
            entity.Property(m => m.FilmGenre).HasColumnName("FilmGenre");
            entity.Property(m => m.Director).HasColumnName("Director");
            entity.Property(m => m.Release_movie).HasColumnName("Release_movie");
        });
    }
}