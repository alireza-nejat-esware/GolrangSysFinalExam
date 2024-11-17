using GolrangSystemFinalExam.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GolrangSystemFinalExam.Infrastructure.Entities
{
    public class SellLineProduct : BaseEntity
    {
        public int SellLineId { get; set; }
        public int ProductId { get; set; }
        public SellLine SellLine { get; set; }
        public Product Product { get; set; }
    }

    public class SellLineProductConfiguration : IEntityTypeConfiguration<SellLineProduct>
    {
        public void Configure(EntityTypeBuilder<SellLineProduct> builder)
        {
            builder.ToTable("SellLinesProducts");

            builder.HasKey(a => new { a.ProductId, a.SellLineId });

            builder.HasOne(a => a.Product)
                   .WithMany(a => a.SellLineProducts)
                   .HasForeignKey(a => a.ProductId);

            builder.HasOne(a => a.SellLine)
                   .WithMany(a => a.SellLineProducts)
                   .HasForeignKey(a => a.SellLineId);

        }
    }
}
