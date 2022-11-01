using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class UserContext : DbContext
{
    private readonly IConnectionStringProvider _connectionStringProvider;
    
    public UserContext(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }
    
    public DbSet<DbUser> User { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionStringProvider.Get("db"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
    }
}
