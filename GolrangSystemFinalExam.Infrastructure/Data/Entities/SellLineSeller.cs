using GolrangSystemFinalExam.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GolrangSystemFinalExam.Infrastructure.Entities
{
    public class SellLinesSellers : BaseEntity
    {
        public int SellLineId { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public SellLine SellLine { get; set; }
    }

    public class SellLinesSellersConfiguration : IEntityTypeConfiguration<SellLinesSellers>
    {
        public void Configure(EntityTypeBuilder<SellLinesSellers> builder)
        {
            builder.ToTable("SellLinesSellers");

            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.Seller)
                   .WithMany(a => a.SellLinesSellers)
                   .HasForeignKey(a => a.SellerId);

            builder.HasOne(a => a.SellLine)
                   .WithMany(a => a.SellLinesSellers)
                   .HasForeignKey(a => a.SellLineId);

        }
    }
}
