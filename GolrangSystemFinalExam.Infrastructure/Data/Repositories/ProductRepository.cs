using GolrangSystemFinalExam.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProductDomain = GolrangSystemFinalExam.Core.Domains.Product;
using ProductEntity = GolrangSystemFinalExam.Infrastructure.Entities.Product;
namespace GolrangSystemFinalExam.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProduct
    {

        private readonly GolrangSystemFinalExamDbContext _context;

        public ProductRepository(GolrangSystemFinalExamDbContext golrangSystemFinalExamDbContext)
        {
            _context = golrangSystemFinalExamDbContext;
        }

        public async Task<int> CreateAsync(ProductDomain product)
        {
            var dbModel = new ProductEntity()
            {
                Title = product.Title,
                CreatedDate = DateTime.Now,
            };
            await _context.Products.AddAsync(dbModel);
            await _context.SaveChangesAsync();
            return dbModel.Id;
        }

        public async Task DeleteAsync(int id)
        {
            ProductEntity? item = await GetProductAsync(id);
            if (item is null)
                return;

            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDomain product)
        {
            ProductEntity? item = await GetProductAsync(product.Id);
            if (item is null)
                return;

            item.Title = product.Title;
            _context.Products.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductEntity?> GetProductAsync(int id)
        {
            ProductEntity? item = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (item is null)
                throw new Exception("Not Found");

            return item;
        }

    }
}
