using GolrangSystemFinalExam.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using SellLinesSellersEntity = GolrangSystemFinalExam.Infrastructure.Entities.SellLinesSellers;
namespace GolrangSystemFinalExam.Infrastructure.Data.Repositories
{
    public class SellLineSellerRepository : ISellLineSellerRepository
    {

        private readonly GolrangSystemFinalExamDbContext _context;

        public SellLineSellerRepository(GolrangSystemFinalExamDbContext golrangSystemFinalExamDbContext)
        {
            _context = golrangSystemFinalExamDbContext;
        }

        public async Task<bool> IsExistAsync(int sellLineId, int sellerId)
        {
            SellLinesSellersEntity? item = await _context
                .SellLinesSellers
                .FirstOrDefaultAsync(c => c.SellLineId == sellLineId && c.SellerId == sellerId);
            if (item is null)
                return false;
            else
                return true;
        }
    }
}
