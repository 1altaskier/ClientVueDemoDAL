using Microsoft.EntityFrameworkCore;
using PorchFinal.Models;

namespace PorchFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Phone> Phones { get; set; } = null!;
        public DbSet<PhoneType> PhoneTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Clients
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientId);
                entity.ToTable("Clients");

                entity.Property(e => e.ClientId).HasColumnName("client_id");
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.LastName).HasColumnName("last_name");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.IsArchived).HasColumnName("is_archived");
                //entity.Property(e => e.Offender).HasColumnName("offender");
                //entity.Property(e => e.RepeatOffender).HasColumnName("repeat_offender");

                entity.HasMany(e => e.Phones)
                      .WithOne(p => p.Client)
                      .HasForeignKey(p => p.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Phones
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(p => p.PhoneId);
                entity.ToTable("Phones");

                entity.Property(p => p.PhoneId).HasColumnName("phone_id");
                entity.Property(p => p.ClientId).HasColumnName("client_id");
                entity.Property(p => p.PhoneNumber).HasColumnName("phone_number");
                entity.Property(p => p.PhoneTypeId).HasColumnName("phone_type_id");

                entity.HasOne(p => p.Client)
                      .WithMany(c => c.Phones)
                      .HasForeignKey(p => p.ClientId);

                entity.HasOne(p => p.PhoneType)
                      .WithMany()
                      .HasForeignKey(p => p.PhoneTypeId);
            });

            // PhoneTypes
            modelBuilder.Entity<PhoneType>(entity =>
            {
                entity.HasKey(pt => pt.PhoneTypeId);
                entity.ToTable("PhoneType");

                entity.Property(pt => pt.PhoneTypeId).HasColumnName("phone_type_id");
                entity.Property(pt => pt.Type).HasColumnName("phone_type");
            });
        }
    }
}
