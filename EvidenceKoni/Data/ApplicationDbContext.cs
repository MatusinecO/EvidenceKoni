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
    }
}