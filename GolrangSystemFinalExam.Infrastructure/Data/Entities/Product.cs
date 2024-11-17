using GolrangSystemFinalExam.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GolrangSystemFinalExam.Infrastructure.Entities
{
    public class Product : BaseEntity
    {
        public string? Title { get; set; }

        public List<SellLineProduct> SellLineProducts { get; set; }

        public List<PreInvoiceDetails> PreInvoiceDetails { get; set; }
    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

        }
    }
}
