using Assignment.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Assignment.Models.ViewModels;

namespace Assignment.DBContextManager
{
    public class ProductAppContext:DbContext
    {
        public ProductAppContext(DbContextOptions<ProductAppContext> cxt) : base(cxt)
        {
            
            
            
        }
        public DbSet<ProductDataModel> Products { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDataModel>().HasIndex(p => new { p.Name }).IsUnique();
            
        }
        public DbSet<Assignment.Models.ViewModels.AuditViewModel> AuditViewModel { get; set; }
    }
}
