using GolrangSystemFinalExam.Core.Domains.Common;
using GolrangSystemFinalExam.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using PreInvoiceHeaderDomain = GolrangSystemFinalExam.Core.Domains.PreInvoiceHeader;
using PreInvoiceHeaderEntity = GolrangSystemFinalExam.Infrastructure.Entities.PreInvoiceHeader;
namespace GolrangSystemFinalExam.Infrastructure.Data.Repositories
{
    public class PreInvoiceHeaderRepository : IPreInvoiceHeaderRepository
    {
        private readonly GolrangSystemFinalExamDbContext _context;

        public PreInvoiceHeaderRepository(GolrangSystemFinalExamDbContext golrangSystemFinalExamDbContext)
        {
            _context = golrangSystemFinalExamDbContext;
        }

        public async Task<int> CreateAsync(PreInvoiceHeaderDomain preInvoiceHeader)
        {
            var dbModel = new PreInvoiceHeaderEntity()
            {
                SellLineId = preInvoiceHeader.SellLineId,
                CustomerId = preInvoiceHeader.CustomerId,
                SellerId = preInvoiceHeader.SellerId,
                Status = InvoiceStatus.Draft,
            };
            await _context.PreInvoiceHeaders.AddAsync(dbModel);
            await _context.SaveChangesAsync();
            return dbModel.Id;
        }

        public async Task DeleteAsync(int id)
        {
            PreInvoiceHeaderEntity? item = await GetPreInvoiceHeaderAsync(id);
            if (item is null)
                return;

            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PreInvoiceHeaderDomain>?> GetAllAsync()
        {
            return await _context.PreInvoiceHeaders
           .Select(x => new PreInvoiceHeaderDomain()
           {
               Id = x.Id,
               SellerId = x.SellerId,
               SellLineId = x.SellLineId,
               CustomerId = x.CustomerId,
               Status = x.Status,
               SellLine = new()
               {
                   Title = x.SellLine.Title,
               },
               Customer = new()
               {
                   Firstname = x.Customer.Firstname,
                   Lastname = x.Customer.Lastname,
               },
               Seller = new()
               {
                   Firstname = x.Customer.Firstname,
                   Lastname = x.Customer.Lastname,
               },
           })
           .Include(x => x.SellLine)
           .Include(x => x.Customer)
           .Include(x => x.Seller)
           .OrderByDescending(x => x.CreatedDate)
           .ToListAsync();
        }

        public async Task<PreInvoiceHeaderDomain?> GetByIdAsync(int id)
        {
            return await _context.PreInvoiceHeaders
           .Select(x => new PreInvoiceHeaderDomain()
           {
               Id = x.Id,
               SellerId = x.SellerId,
               SellLineId = x.SellLineId,
               CustomerId = x.CustomerId,
               Status = x.Status,
               SellLine = new()
               {
                   Title = x.SellLine.Title,
               },
               Customer = new()
               {
                   Firstname = x.Customer.Firstname,
                   Lastname = x.Customer.Lastname,
               },
               Seller = new()
               {
                   Firstname = x.Customer.Firstname,
                   Lastname = x.Customer.Lastname,
               },
           })
           .Include(x => x.SellLine)
           .Include(x => x.Customer)
           .Include(x => x.Seller)
           .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(PreInvoiceHeaderDomain preInvoiceHeader)
        {
            PreInvoiceHeaderEntity? item = await GetPreInvoiceHeaderAsync(preInvoiceHeader.Id);
            if (item is null)
                return;

            item.SellLineId = preInvoiceHeader.SellLineId;
            item.CustomerId = preInvoiceHeader.CustomerId;
            _context.PreInvoiceHeaders.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeStatus(int id)
        {
            PreInvoiceHeaderEntity? item = await GetPreInvoiceHeaderAsync(id);
            if (item is null)
                return;

            if (item.Status == InvoiceStatus.Final)
                return;

            item.Status = InvoiceStatus.Final;
            _context.PreInvoiceHeaders.Update(item);
            await _context.SaveChangesAsync();
        }

        private async Task<PreInvoiceHeaderEntity?> GetPreInvoiceHeaderAsync(int id)
        {
            PreInvoiceHeaderEntity? item = await _context.PreInvoiceHeaders.FirstOrDefaultAsync(c => c.Id == id);
            if (item is null)
                throw new Exception("Not Found");

            return item;
        }
    }
}
