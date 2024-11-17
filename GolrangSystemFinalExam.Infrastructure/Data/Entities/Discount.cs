using GolrangSystemFinalExam.Core.Domains.Common;
using GolrangSystemFinalExam.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace GolrangSystemFinalExam.Infrastructure.Entities
{
    public class Discount : BaseEntity
    {
        public int PreInvoiceHeaderId { get; set; }
        [RequiredIf("DiscountType", "DiscountType.AsRow")]
        public int? PreInvoiceDetailId { get; set; }
        public DiscountType? DiscountType { get; set; }
        [Range(1, int.MaxValue)]
        public double Value { get; set; }
        public PreInvoiceDetails? PreInvoiceDetails { get; set; }
        public PreInvoiceHeader PreInvoiceHeader { get; set; }
    }

    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discounts");

            builder.HasKey(x => x.Id);

            builder.Property(a => a.Value)
                   .IsRequired();

        }
    }
}
