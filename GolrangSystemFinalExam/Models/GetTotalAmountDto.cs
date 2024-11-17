using GolrangSystemFinalExam.Core.Domains.Common;

namespace GolrangSystemFinalExam.API.Models
{
    public class GetTotalAmountDto
    {
        public int customerId { get; set; }
        public InvoiceStatus invoiceStatus { get; set; }
        public bool discountIncluded { get; set; } = true;
    }
}
