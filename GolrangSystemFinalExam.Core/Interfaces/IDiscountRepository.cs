using GolrangSystemFinalExam.Core.Domains;
using GolrangSystemFinalExam.Core.Domains.Common;
namespace GolrangSystemFinalExam.Core.Interfaces
{
    public interface IDiscountRepository
    {
        Task<Discount?> GetByIdAsync(int id);
        Task<List<Discount>?> GetAllAsync();
        Task<int> CreateAsync(Discount discount);
        Task UpdateAsync(Discount discount);
        Task DeleteAsync(int id);
        Task<double> GetTotalDiscountByCustomerIdAsync(int customerId, InvoiceStatus invoiceStatus);
        Task<double> GetTotalDiscountByInvoiceHeaderIdAsync(int preInvoiceHeaderId);
    }
}
