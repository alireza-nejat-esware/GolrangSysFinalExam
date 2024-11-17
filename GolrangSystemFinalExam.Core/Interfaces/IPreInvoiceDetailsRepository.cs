using GolrangSystemFinalExam.Core.Domains;
using GolrangSystemFinalExam.Core.Domains.Common;
namespace GolrangSystemFinalExam.Core.Interfaces
{
    public interface IPreInvoiceDetailsRepository
    {
        Task<PreInvoiceDetails?> GetByIdAsync(int id);
        Task<List<PreInvoiceDetails>?> GetAllAsync();
        Task<List<PreInvoiceDetails>?> GetAllByInvoiceIdAsync(int preInvoiceHeaderId);
        Task<int> CreateAsync(PreInvoiceDetails preInvoiceDetails);
        Task UpdateAsync(PreInvoiceDetails preInvoiceDetails);
        Task DeleteAsync(int id);
        Task<double> GetInvoiceTotalAmountAsync(int customerId, InvoiceStatus invoiceStatus);
        Task<double> GetInvoiceTotalAmountByHeaderIdAsync(int headerId);
        Task<bool> IsRepetitive(int productId);
    }
}
