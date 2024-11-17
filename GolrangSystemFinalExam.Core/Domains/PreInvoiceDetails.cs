using GolrangSystemFinalExam.Core.Domains.Common;
using System.ComponentModel.DataAnnotations;
namespace GolrangSystemFinalExam.Core.Domains
{
    public class PreInvoiceDetails : BaseDomain
    {
        public int ProductId { get; set; }
        [Range(1, int.MaxValue)]
        public int Count { get; set; }
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
        public Product Product { get; set; }
        public int PreInvoiceHeaderId { get; set; }
        public PreInvoiceHeader PreInvoiceHeader { get; set; }
    }
}
