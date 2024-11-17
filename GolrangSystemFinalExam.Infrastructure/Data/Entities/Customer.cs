using GolrangSystemFinalExam.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GolrangSystemFinalExam.Infrastructure.Entities
{
    public class Customer : BaseEntity
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public IEnumerable<PreInvoiceHeader> PreInvoiceHeaders { get; set; }
    }

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);

            builder.Property(a => a.Firstname)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(a => a.Lastname)
                 .IsRequired()
                 .HasMaxLength(80);

        }
    }
}
