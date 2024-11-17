using GolrangSystemFinalExam.Core.Domains.Common;

namespace GolrangSystemFinalExam.Core.Domains
{
    public class SellLine : BaseDomain
    {
        public string? Title { get; set; }

        public IEnumerable<PreInvoiceHeader>? PreInvoiceHeaders { get; set; }

        public IEnumerable<SellLineProduct>? SellLineProduct { get; set; }
    }
}