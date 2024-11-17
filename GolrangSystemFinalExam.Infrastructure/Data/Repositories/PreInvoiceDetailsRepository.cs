using GolrangSystemFinalExam.Core.Domains.Common;
using GolrangSystemFinalExam.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using PreInvoiceDetailsDomain = GolrangSystemFinalExam.Core.Domains.PreInvoiceDetails;
using PreInvoiceDetailsEntity = GolrangSystemFinalExam.Infrastructure.Entities.PreInvoiceDetails;
namespace GolrangSystemFinalExam.Infrastructure.Data.Repositories
{
    public class PreInvoiceDetailsRepository : IPreInvoiceDetailsRepository
    {
        private readonly GolrangSystemFinalExamDbContext _context;

        public PreInvoiceDetailsRepository(GolrangSystemFinalExamDbContext golrangSystemFinalExamDbContext)
        {
            _context = golrangSystemFinalExamDbContext;
        }

        public async Task<int> CreateAsync(PreInvoiceDetailsDomain preInvoiceDetails)
        {
            var dbModel = new PreInvoiceDetailsEntity()
            {
                PreInvoiceHeaderId = preInvoiceDetails.PreInvoiceHeaderId,
                ProductId = preInvoiceDetails.ProductId,
                Count = preInvoiceDetails.Count,
                Price = preInvoiceDetails.Price,
            };
            await _context.PreInvoiceDetails.AddAsync(dbModel);
            await _context.SaveChangesAsync();
            return dbModel.Id;
        }

        public async Task DeleteAsync(int id)
        {
            PreInvoiceDetailsEntity? item = await GetPreInvoiceDetailsAsync(id);
            if (item is not null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PreInvoiceDetailsDomain>?> GetAllAsync()
        {
            return await _context.PreInvoiceDetails
           .Select(x => new PreInvoiceDetailsDomain()
           {
               Id = x.Id,
               ProductId = x.ProductId,
               Count = x.Count,
               Price = x.Price,
               PreInvoiceHeaderId = x.PreInvoiceHeaderId,
               Product = new()
               {
                   Title = x.Product.Title,
               },
               PreInvoiceHeader = new()
               {
                   Id = x.PreInvoiceHeader.Id,
                   SellerId = x.PreInvoiceHeader.SellerId,
                   SellLineId = x.PreInvoiceHeader.SellLineId,
                   CustomerId = x.PreInvoiceHeader.CustomerId,
                   Status = x.PreInvoiceHeader.Status,
                   SellLine = new()
                   {
                       Title = x.PreInvoiceHeader.SellLine.Title,
                   },
                   Customer = new()
                   {
                       Firstname = x.PreInvoiceHeader.Customer.Firstname,
                       Lastname = x.PreInvoiceHeader.Customer.Lastname,
                   },
                   Seller = new()
                   {
                       Firstname = x.PreInvoiceHeader.Customer.Firstname,
                       Lastname = x.PreInvoiceHeader.Customer.Lastname,
                   },
               }
           })
           .Include(x => x.Product)
           .OrderByDescending(x => x.CreatedDate)
           .ToListAsync();
        }

        public async Task<List<PreInvoiceDetailsDomain>?> GetAllByInvoiceIdAsync(int preInvoiceHeaderId)
        {
            return await _context.PreInvoiceDetails
           .Select(x => new PreInvoiceDetailsDomain()
           {
               Id = x.Id,
               ProductId = x.ProductId,
               Count = x.Count,
               Price = x.Price,
               PreInvoiceHeaderId = x.PreInvoiceHeaderId,
               Product = new()
               {
                   Title = x.Product.Title,
               },
               PreInvoiceHeader = new()
               {
                   Id = x.PreInvoiceHeader.Id,
                   SellerId = x.PreInvoiceHeader.SellerId,
                   SellLineId = x.PreInvoiceHeader.SellLineId,
                   CustomerId = x.PreInvoiceHeader.CustomerId,
                   Status = x.PreInvoiceHeader.Status,
                   SellLine = new()
                   {
                       Title = x.PreInvoiceHeader.SellLine.Title,
                   },
                   Customer = new()
                   {
                       Firstname = x.PreInvoiceHeader.Customer.Firstname,
                       Lastname = x.PreInvoiceHeader.Customer.Lastname,
                   },
                   Seller = new()
                   {
                       Firstname = x.PreInvoiceHeader.Customer.Firstname,
                       Lastname = x.PreInvoiceHeader.Customer.Lastname,
                   },
               }
           })
           .Include(x => x.Product)
           .OrderByDescending(x => x.CreatedDate)
           .Where(x => x.PreInvoiceHeaderId == preInvoiceHeaderId)
           .ToListAsync();
        }

        public async Task<double> GetInvoiceTotalAmountAsync(int customerId, InvoiceStatus invoiceStatus)
        {
            double total = await _context
                .PreInvoiceDetails
                .Where(a =>
                    a.PreInvoiceHeader.CustomerId == customerId &&
                    a.PreInvoiceHeader.Status == invoiceStatus
                ).SumAsync(a => a.Price);

            return total;
        }

        public async Task<double> GetInvoiceTotalAmountByHeaderIdAsync(int invoiceId)
        {
            return await _context
                .PreInvoiceDetails
                .Where(a =>
                    a.PreInvoiceHeaderId == invoiceId
                ).SumAsync(a => a.Price);
        }

        public async Task<PreInvoiceDetailsDomain?> GetByIdAsync(int id)
        {
            return await _context.PreInvoiceDetails
           .Select(x => new PreInvoiceDetailsDomain()
           {
               Id = x.Id,
               ProductId = x.ProductId,
               Count = x.Count,
               Price = x.Price,
               PreInvoiceHeaderId = x.PreInvoiceHeaderId,
               Product = new()
               {
                   Title = x.Product.Title,
               },
               PreInvoiceHeader = new()
               {
                   Id = x.PreInvoiceHeader.Id,
                   SellerId = x.PreInvoiceHeader.SellerId,
                   SellLineId = x.PreInvoiceHeader.SellLineId,
                   CustomerId = x.PreInvoiceHeader.CustomerId,
                   Status = x.PreInvoiceHeader.Status,
                   SellLine = new()
                   {
                       Title = x.PreInvoiceHeader.SellLine.Title,
                   },
                   Customer = new()
                   {
                       Firstname = x.PreInvoiceHeader.Customer.Firstname,
                       Lastname = x.PreInvoiceHeader.Customer.Lastname,
                   },
                   Seller = new()
                   {
                       Firstname = x.PreInvoiceHeader.Customer.Firstname,
                       Lastname = x.PreInvoiceHeader.Customer.Lastname,
                   },
               }
           })
           .Include(x => x.Product)
           .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task UpdateAsync(PreInvoiceDetailsDomain preInvoiceDetails)
        {
            PreInvoiceDetailsEntity? item = await GetPreInvoiceDetailsAsync(preInvoiceDetails.Id);
            if (item is null)
                return;

            item.ProductId = preInvoiceDetails.ProductId;
            item.Count = preInvoiceDetails.Count;
            item.Price = preInvoiceDetails.Price;
            _context.PreInvoiceDetails.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<PreInvoiceDetailsEntity?> GetPreInvoiceDetailsAsync(int id)
        {
            PreInvoiceDetailsEntity? item = await _context.PreInvoiceDetails.FirstOrDefaultAsync(c => c.Id == id);
            if (item is null)
                throw new Exception("Not Found");

            return item;
        }

        public async Task<bool> IsRepetitive(int productId)
        {
            PreInvoiceDetailsEntity? item = await _context
                .PreInvoiceDetails
                .Include(x => x.PreInvoiceHeader)
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.PreInvoiceHeader.Status == InvoiceStatus.Draft);

            if (item is null)
                return false;
            else
                return true;
        }

    }
}
