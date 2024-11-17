using GolrangSystemFinalExam.Core.Domains.Common;

namespace GolrangSystemFinalExam.Core.Domains
{
    public class Product : BaseDomain
    {
        public string? Title { get; set; }

        public List<SellLineProduct> SellLineProducts { get; set; }

        public List<PreInvoiceDetails> PreInvoiceDetails { get; set; }
    }
}
