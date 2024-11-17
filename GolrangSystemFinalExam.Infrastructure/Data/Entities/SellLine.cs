    using GolrangSystemFinalExam.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GolrangSystemFinalExam.Core.Domains;

namespace GolrangSystemFinalExam.Infrastructure.Entities
{
    public class SellLine : BaseEntity
    {
        public string? Title { get; set; }

        public IEnumerable<PreInvoiceHeader> PreInvoiceHeaders { get; set; }

        public IEnumerable<SellLinesSellers> SellLinesSellers { get; set; }

        public IEnumerable<SellLineProduct> SellLineProducts { get; set; }
    }

    public class SellLinesConfiguration : IEntityTypeConfiguration<SellLine>
    {
        public void Configure(EntityTypeBuilder<SellLine> builder)
        {
            builder.ToTable("SellLines");

            builder.HasKey(x => x.Id);

        }
    }
}
