using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccess.Domains
{
    public partial class RabbitMqDbContext : DbContext
    {
        public RabbitMqDbContext()
        {
        }

        public RabbitMqDbContext(DbContextOptions<RabbitMqDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=db;database=RabbitMqDb;user id=sa;password=Mohammad1250633672");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}