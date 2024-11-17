using GolrangSystemFinalExam.Core.Domains.Common;

namespace GolrangSystemFinalExam.Core.Domains
{
    public class SellLineProduct : BaseDomain
    {
        public int SellLineId { get; set; }
        public int ProductId { get; set; }
        public Seller Seller { get; set; }
        public Product Product { get; set; }
    }
}
