using GolrangSystemFinalExam.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GolrangSystemFinalExam.Infrastructure.Entities
{
    public class PreInvoiceDetails : BaseEntity
    {
        public int ProductId { get; set; }
        [Range(1, int.MaxValue)]
        public int Count { get; set; }
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
        public Product Product { get; set; }
        public int PreInvoiceHeaderId { get; set; }
        public PreInvoiceHeader PreInvoiceHeader { get; set; }
    }

    public class PreInvoiceDetailsConfiguration : IEntityTypeConfiguration<PreInvoiceDetails>
    {
        public void Configure(EntityTypeBuilder<PreInvoiceDetails> builder)
        {
            builder.ToTable("PreInvoiceDetails");

            builder.HasKey(x => x.Id);

            builder.Property(a => a.Count)
                   .IsRequired();

            builder.Property(a => a.Price)
                   .IsRequired();

            builder.Property(a => a.PreInvoiceHeaderId)
                   .IsRequired();

        }
    }
}
