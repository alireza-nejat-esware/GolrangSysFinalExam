using GolrangSystemFinalExam.Core.Domains.Common;
namespace GolrangSystemFinalExam.Core.Domains
{
    public class PreInvoiceHeader : BaseDomain
    {
        public int SellLineId { get; set; }
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
        public InvoiceStatus Status { get; set; }
        public SellLine SellLine { get; set; }
        public Customer Customer { get; set; }
        public Seller Seller { get; set; }
    }
}
