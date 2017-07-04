using BankLocator.Api.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankLocator.Api.Models
{
    public class BankLocatorContext : DbContext
    {
        public BankLocatorContext(DbContextOptions<BankLocatorContext> options) : base(options) { }

        public virtual DbSet<Bankoffice> Bankoffices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bankoffice>().ToTable("Bankoffice");
        }
    }
}
