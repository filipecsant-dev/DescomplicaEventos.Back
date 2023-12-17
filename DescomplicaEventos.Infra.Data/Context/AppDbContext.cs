using DescomplicaEventos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DescomplicaEventos.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<UserEntity> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}