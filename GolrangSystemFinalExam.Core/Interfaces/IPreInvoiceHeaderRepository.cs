using GolrangSystemFinalExam.Core.Domains;
namespace GolrangSystemFinalExam.Core.Interfaces
{
    public interface IPreInvoiceHeaderRepository
    {
        Task<PreInvoiceHeader?> GetByIdAsync(int id);
        Task<List<PreInvoiceHeader>?> GetAllAsync();
        Task<int> CreateAsync(PreInvoiceHeader preInvoiceHeader);
        Task UpdateAsync(PreInvoiceHeader preInvoiceHeader);
        Task DeleteAsync(int id);
    }
}
