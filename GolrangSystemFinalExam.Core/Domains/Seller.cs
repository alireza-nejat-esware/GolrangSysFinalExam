using GolrangSystemFinalExam.Core.Domains.Common;

namespace GolrangSystemFinalExam.Core.Domains
{
    public class Seller : BaseDomain
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public int SellLineId { get; set; }

        public SellLine SalesLine { get; set; }

        public List<PreInvoiceHeader> PreInvoiceHeaders { get; set; }
    }
}
