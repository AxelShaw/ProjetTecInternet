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
    public DbSet<DbRatingMovie> RatingMovie { get; set; }
    public DbSet<DbCommentMovie> CommentMovie { get; set; }
    
    public DbSet<DbFavorie> Favorie { get; set; }
    
    public DbSet<DbActu> Actu { get; set; }


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
        
        
        modelBuilder.Entity<DbRatingMovie>(entity =>
        {
            entity.ToTable("RATINGMOVIE");
            entity.HasKey(m => m.MovieRefId);
            entity.Property(m => m.MovieRefId).HasColumnName("idmovie");
            entity.Property(m => m.Average_rating).HasColumnName("average_rating");
            entity.Property(m => m.NumVote).HasColumnName("numVote");
        });
        
        
        modelBuilder.Entity<DbCommentMovie>(entity =>
        {
            entity.ToTable("COMMENTMOVIE");
            entity.HasKey(m => m.IdComMovie);
            entity.Property(m => m.IdComMovie).HasColumnName("idComMovie");
            entity.Property(m => m.Rating).HasColumnName("rating");
            entity.Property(m => m.CommentText).HasColumnName("commentText");
            entity.Property(m => m.IdMovieRef).HasColumnName("idmovie");
            entity.Property(m => m.IdUserRef).HasColumnName("idUser");
        });
        
        modelBuilder.Entity<DbFavorie>(entity =>
        {
            entity.ToTable("FAVORIE");
            entity.HasKey(m => m.IdFav);
            entity.Property(m => m.IdFav).HasColumnName("idFav");
            entity.Property(m => m.IdMovieRef).HasColumnName("idmovie");
            entity.Property(m => m.IdUserRef).HasColumnName("iduser");
            
        });
        
        modelBuilder.Entity<DbActu>(entity =>
        {
            entity.ToTable("ACTU");
            entity.HasKey(m => m.IdActu);
            entity.Property(m => m.IdActu).HasColumnName("idActu");
            entity.Property(m => m.IdMovieRef).HasColumnName("idmovie");
            entity.Property(m => m.NewsActu).HasColumnName("news");
            entity.Property(m => m.Release_actu).HasColumnName("Release_actu");
        });
    }
    
}