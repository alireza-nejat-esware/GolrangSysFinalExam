using GolrangSystemFinalExam.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using SellLineProductEntity = GolrangSystemFinalExam.Infrastructure.Entities.SellLineProduct;
namespace GolrangSystemFinalExam.Infrastructure.Data.Repositories
{
    public class SellLineProductRepository : ISellLineProductRepository
    {
        private readonly GolrangSystemFinalExamDbContext _context;
        public SellLineProductRepository(GolrangSystemFinalExamDbContext golrangSystemFinalExamDbContext)
        {
            _context = golrangSystemFinalExamDbContext;
        }

        public async Task<bool> IsProductExistAsync(int ProductId)
        {
            SellLineProductEntity? item = await _context
                .SellLinesProducts
                .FirstOrDefaultAsync(c => c.ProductId == ProductId);
            if (item is null)
                return false;
            else
                return true;
        }
    }
}
