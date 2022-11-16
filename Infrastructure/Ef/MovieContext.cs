using Domain;
using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using DbRatingMovie = Infrastructure.Ef.DbEntities.DbRatingMovie;

namespace Infrastructure.Ef;

public class MovieContext : DbContext
{
    private readonly IConnectionStringProvider _connectionStringProvider;
    
    public MovieContext(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }
    
    public DbSet<DbMovie> Movie { get; set; }
    public DbSet<DbUser> User { get; set; }
    public DbSet<DbSerie> Serie { get; set; }
    public DbSet<DbRatingMovie> RatingMovie { get; set; }


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
        
        modelBuilder.Entity<DbUser>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(m => m.IdUser);
            entity.Property(m => m.IdUser).HasColumnName("IdUser");
            entity.Property(m => m.last_name).HasColumnName("last_name");
            entity.Property(m => m.first_name).HasColumnName("first_name");
            entity.Property(m => m.mail).HasColumnName("mail");
            entity.Property(m => m.nickname).HasColumnName("nickname");
            entity.Property(m => m.password).HasColumnName("password");
            entity.Property(m => m.role).HasColumnName("role");
            entity.Property(m => m.profil_picture).HasColumnName("profil_picture");
        });
        
        modelBuilder.Entity<DbSerie>(entity =>
        {
            entity.ToTable("SERIE");
            entity.HasKey(m => m.IdSerie);
            entity.Property(m => m.IdSerie).HasColumnName("idSerie");
            entity.Property(m => m.NameSerie).HasColumnName("nameSerie");
            entity.Property(m => m.SerieType).HasColumnName("seriesType");
            entity.Property(m => m.DescriptionSerie).HasColumnName("descriptionSerie");
            entity.Property(m => m.ImageSerie).HasColumnName("imageSeries");
            entity.Property(m => m.NbSeason).HasColumnName("nbSeason");

        });
        
        modelBuilder.Entity<DbRatingMovie>(entity =>
        {
            entity.ToTable("RATINGMOVIE");
            entity.HasKey(m => m.MovieRefId);
            entity.Property(m => m.MovieRefId).HasColumnName("idmovie");
            entity.Property(m => m.Average_rating).HasColumnName("average_rating");
            entity.Property(m => m.NumVote).HasColumnName("numVote");
        });
    }
    
}