using GolrangSystemFinalExam.Core.Domains.Common;
namespace GolrangSystemFinalExam.Core.Domains
{
    public class SellLineSeller : BaseDomain
    {
        public int SellLineId { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public SellLine SellLine { get; set; }
    }
}
