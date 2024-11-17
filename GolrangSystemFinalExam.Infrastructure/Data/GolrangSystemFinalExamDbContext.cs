using GolrangSystemFinalExam.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace GolrangSystemFinalExam.Infrastructure.Data
{

    public class GolrangSystemFinalExamDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<PreInvoiceDetails> PreInvoiceDetails { get; set; }
        public DbSet<PreInvoiceHeader> PreInvoiceHeaders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SellLineProduct> SellLinesProducts { get; set; }
        public DbSet<SellLinesSellers> SellLinesSellers { get; set; }
        public DbSet<SellLine> SellLines { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        public GolrangSystemFinalExamDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GolrangSystemFinalExamDbContext).Assembly);
            //modelBuilder.ApplyConfiguration(new Customers());
        }

    }

    public class FinalExamContextFactory : IDesignTimeDbContextFactory<GolrangSystemFinalExamDbContext>
    {
        public GolrangSystemFinalExamDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GolrangSystemFinalExamDbContext>();
            optionsBuilder.UseSqlServer(@"Server=ALIREZA-PC\MSSQL;Database=GolrangExamDb;persist security info=False;user id=sa;password=Sdc221saz;Integrated Security=True;Persist Security Info=False;Pooling=False;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            return new GolrangSystemFinalExamDbContext(optionsBuilder.Options);
        }
    }

}
