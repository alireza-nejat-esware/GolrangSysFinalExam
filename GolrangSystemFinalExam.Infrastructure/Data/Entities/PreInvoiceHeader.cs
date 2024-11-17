using GolrangSystemFinalExam.Core.Domains.Common;
using GolrangSystemFinalExam.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace GolrangSystemFinalExam.Infrastructure.Entities
{
    public class PreInvoiceHeader : BaseEntity
    {
        public int SellLineId { get; set; }
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
        public InvoiceStatus Status { get; set; }
        public SellLine SellLine { get; set; }
        public Customer Customer { get; set; }
        public Seller Seller { get; set; }
        public IEnumerable<PreInvoiceDetails> PreInvoiceDetails { get; set; }
    }

    public class PreInvoiceHeaderConfiguration : IEntityTypeConfiguration<PreInvoiceHeader>
    {
        public void Configure(EntityTypeBuilder<PreInvoiceHeader> builder)
        {
            builder.ToTable("PreInvoiceHeaders");

            builder.HasKey(x => x.Id);

            builder.Property(a => a.SellLineId)
                   .IsRequired();

            builder.Property(a => a.CustomerId)
                   .IsRequired();

            builder.Property(a => a.SellerId)
                   .IsRequired();

            builder.HasOne(a => a.SellLine)
                   .WithMany(a => a.PreInvoiceHeaders)
                   .HasForeignKey(a => a.SellLineId);

            builder.HasOne(a => a.Customer)
                   .WithMany(a => a.PreInvoiceHeaders)
                   .HasForeignKey(a => a.CustomerId);

            builder.HasOne(a => a.Seller)
                   .WithMany(a => a.PreInvoiceHeaders)
                   .HasForeignKey(a => a.SellerId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
