using GolrangSystemFinalExam.Core.Domains;
namespace GolrangSystemFinalExam.Core.Interfaces
{
    public interface ISellLineSellerRepository
    {
        Task<bool> IsExistAsync(int sellLineId, int sellerId);
    }
}
