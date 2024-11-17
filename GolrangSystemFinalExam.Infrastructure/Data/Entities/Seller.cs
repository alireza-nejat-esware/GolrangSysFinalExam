using GolrangSystemFinalExam.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GolrangSystemFinalExam.Infrastructure.Entities
{
    public class Seller : BaseEntity
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public IEnumerable<PreInvoiceHeader> PreInvoiceHeaders { get; set; }

        public IEnumerable<SellLinesSellers> SellLinesSellers { get; set; }
    }

    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Firstname)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(p => p.Lastname)
                   .IsRequired()
                   .HasMaxLength(80);

        }
    }
}
