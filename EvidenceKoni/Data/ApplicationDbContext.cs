using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EvidenceKoni.Models;

namespace EvidenceKoni.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EvidenceKoni.Models.Horse> Horse { get; set; } = default!;
        public DbSet<EvidenceKoni.Models.Owner> Owner { get; set; } = default!;
        public DbSet<EvidenceKoni.Models.Procedure> Procedure { get; set; } = default!;
        public DbSet<EvidenceKoni.Models.Stable> Stable { get; set; } = default!;
        public DbSet<EvidenceKoni.Models.Worker> Worker { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Horse>()
                .HasOne<Owner>(h => h.Owners)
                .WithMany(o => o.Horses)
                .HasForeignKey(h => h.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Procedure>()
                .HasOne<Horse>(p => p.Horse)
                .WithMany(h => h.Procedures)
                .HasForeignKey(p => p.HorseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Procedure>()
                .HasOne<Worker>(p => p.Worker)
                .WithMany(w => w.Procedures)
                .HasForeignKey(p => p.WorkerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Stable>()
                .HasOne<Owner>(s => s.Owners)
                .WithMany(o => o.Stables)
                .HasForeignKey(s => s.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Worker>()
                .HasMany<Procedure>(w => w.Procedures)
                .WithOne(p => p.Worker)
                .HasForeignKey(p => p.WorkerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}