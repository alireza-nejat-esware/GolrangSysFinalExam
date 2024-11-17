using GolrangSystemFinalExam.Core.Domains.Common;
using System.ComponentModel.DataAnnotations;
namespace GolrangSystemFinalExam.Core.Domains
{
    public class Discount : BaseDomain
    {
        public int PreInvoiceHeaderId { get; set; }
        public int PreInvoiceDetailId { get; set; }
        public DiscountType DiscountType { get; set; }
        [Range(1, int.MaxValue)]
        public double Value { get; set; }
        public PreInvoiceDetails PreInvoiceDetails { get; set; }
        public PreInvoiceHeader PreInvoiceHeader { get; set; }
    }
}
