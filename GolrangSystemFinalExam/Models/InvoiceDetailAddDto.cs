using System.ComponentModel.DataAnnotations;

namespace GolrangSystemFinalExam.API.Models
{
    public class InvoiceDetailAddDto
    {
        public int ProductId { get; set; }
        [Range(1, int.MaxValue)]
        public int Count { get; set; }
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
        public int PreInvoiceHeaderId { get; set; }
    }
}
