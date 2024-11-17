using GolrangSystemFinalExam.Core.Domains;

namespace GolrangSystemFinalExam.Core.Interfaces
{
    public interface IProduct
    {
        Task<int> CreateAsync(Product discount);
        Task UpdateAsync(Product discount);
        Task DeleteAsync(int id);
    }
}
