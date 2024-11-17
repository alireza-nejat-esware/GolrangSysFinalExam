using GolrangSystemFinalExam.Core.Domains;
namespace GolrangSystemFinalExam.Core.Interfaces
{
    public interface ISellLineProductRepository
    {
        Task<bool> IsProductExistAsync(int productId);
    }
}
