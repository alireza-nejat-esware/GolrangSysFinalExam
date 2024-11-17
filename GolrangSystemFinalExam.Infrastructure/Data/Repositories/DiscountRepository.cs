using GolrangSystemFinalExam.Core.Domains.Common;
using GolrangSystemFinalExam.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using DiscountDomain = GolrangSystemFinalExam.Core.Domains.Discount;
using DiscountEntity = GolrangSystemFinalExam.Infrastructure.Entities.Discount;
namespace GolrangSystemFinalExam.Infrastructure.Data.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly GolrangSystemFinalExamDbContext _context;
        //private readonly IPreInvoiceHeaderRepository _preInvoiceHeaderRepository;
        //private readonly IPreInvoiceDetailsRepository _preInvoiceDetailsRepository;

        public DiscountRepository(
            GolrangSystemFinalExamDbContext golrangSystemFinalExamDbContext)
            //IPreInvoiceHeaderRepository preInvoiceHeaderRepository,
            //IPreInvoiceDetailsRepository preInvoiceDetailsRepository)
        {
            _context = golrangSystemFinalExamDbContext;
            //_preInvoiceHeaderRepository = preInvoiceHeaderRepository;
            // _preInvoiceDetailsRepository = preInvoiceDetailsRepository;
        }

        public async Task<int> CreateAsync(DiscountDomain discount)
        {
            //double discountTotal = await GetTotalDiscountByInvoiceHeaderIdAsync(discount.PreInvoiceHeaderId);
            //double InvoiceTotal = await _preInvoiceDetailsRepository.GetInvoiceTotalAmountByHeaderIdAsync(discount.PreInvoiceHeaderId);
            //if ((discountTotal + discount.Value) > InvoiceTotal)
            //    return 0;

            var dbModel = new DiscountEntity()
            {
                Value = discount.Value,
                PreInvoiceDetailId = discount.DiscountType == DiscountType.AsRow ? discount.PreInvoiceDetailId : null,
                PreInvoiceHeaderId = discount.PreInvoiceHeaderId,
                DiscountType = discount.DiscountType,
                CreatedDate = DateTime.Now,
            };
            await _context.Discounts.AddAsync(dbModel);
            await _context.SaveChangesAsync();
            return dbModel.Id;
        }

        public async Task DeleteAsync(int id)
        {
            DiscountEntity? item = await GetDiscountAsync(id);
            if (item is null)
                return;

            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DiscountDomain>?> GetAllAsync()
        {
            return await _context.Discounts
           .Select(x => new DiscountDomain()
           {
               Id = x.Id,
               Value = x.Value,
               PreInvoiceHeaderId = x.PreInvoiceHeaderId,
               PreInvoiceDetailId = (int)x.PreInvoiceDetailId,
               PreInvoiceDetails = new()
               {
                   ProductId = x.PreInvoiceDetails.ProductId,
                   Count = x.PreInvoiceDetails.Count,
                   Price = x.PreInvoiceDetails.Price,
                   Product = new Core.Domains.Product()
                   {
                       Title = x.PreInvoiceDetails.Product.Title,
                   }
               },
               PreInvoiceHeader = new()
               {
                   SellLineId = x.PreInvoiceHeader.SellLineId,
                   SellerId = x.PreInvoiceHeader.SellerId,
                   Status = x.PreInvoiceHeader.Status,
                   SellLine = new Core.Domains.SellLine()
                   {
                       Title = x.PreInvoiceHeader.SellLine.Title,
                   },
                   Customer = new Core.Domains.Customer()
                   {
                       Firstname = x.PreInvoiceHeader.Customer.Firstname,
                       Lastname = x.PreInvoiceHeader.Customer.Lastname,
                   },
                   Seller = new Core.Domains.Seller()
                   {
                       Firstname = x.PreInvoiceHeader.Seller.Firstname,
                       Lastname = x.PreInvoiceHeader.Seller.Lastname,
                   },
               }
           })
           .Include(x => x.PreInvoiceDetails)
           .Include(x => x.PreInvoiceHeader)
           .OrderByDescending(x => x.CreatedDate)
           .ToListAsync();
        }

        public async Task<DiscountDomain?> GetByIdAsync(int id)
        {
            return await _context.Discounts
               .Select(x => new DiscountDomain()
               {
                   Id = x.Id,
                   Value = x.Value,
                   PreInvoiceHeaderId = x.PreInvoiceHeaderId,
                   PreInvoiceDetailId = (int)x.PreInvoiceDetailId,
                   PreInvoiceDetails = new()
                   {
                       ProductId = x.PreInvoiceDetails.ProductId,
                       Count = x.PreInvoiceDetails.Count,
                       Price = x.PreInvoiceDetails.Price,
                       Product = new Core.Domains.Product()
                       {
                           Title = x.PreInvoiceDetails.Product.Title,
                       }
                   },
                   PreInvoiceHeader = new()
                   {
                       SellLineId = x.PreInvoiceHeader.SellLineId,
                       SellerId = x.PreInvoiceHeader.SellerId,
                       Status = x.PreInvoiceHeader.Status,
                       SellLine = new Core.Domains.SellLine()
                       {
                           Title = x.PreInvoiceHeader.SellLine.Title,
                       },
                       Customer = new Core.Domains.Customer()
                       {
                           Firstname = x.PreInvoiceHeader.Customer.Firstname,
                           Lastname = x.PreInvoiceHeader.Customer.Lastname,
                       },
                       Seller = new Core.Domains.Seller()
                       {
                           Firstname = x.PreInvoiceHeader.Seller.Firstname,
                           Lastname = x.PreInvoiceHeader.Seller.Lastname,
                       },
                   }
               })
               .Include(x => x.PreInvoiceDetails)
               .Include(x => x.PreInvoiceHeader)
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(DiscountDomain discount)
        {
            DiscountEntity? item = await GetDiscountAsync(discount.Id);
            if (item is null)
                return;

            item.Value = discount.Value;
            item.PreInvoiceDetailId = discount.PreInvoiceDetailId;
            item.PreInvoiceHeaderId = discount.PreInvoiceHeaderId;
            item.DiscountType = discount.DiscountType;
            _context.Discounts.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<DiscountEntity?> GetDiscountAsync(int id)
        {
            DiscountEntity? item = await _context.Discounts.FirstOrDefaultAsync(c => c.Id == id);
            if (item is null)
                throw new Exception("Not Found");

            return item;
        }

        public async Task<double> GetTotalDiscountPreInvoice(int customerId, int preInvoiceId)
        {
            return await _context
                .Discounts
                .Where(a =>
                    a.PreInvoiceHeader.CustomerId == customerId &&
                    a.PreInvoiceHeader.Id == preInvoiceId &&
                    a.PreInvoiceHeader.Status == InvoiceStatus.Draft
                ).SumAsync(a => a.Value);
        }

        public async Task<double> GetTotalDiscountByCustomerIdAsync(int customerId, InvoiceStatus invoiceStatus)
        {
            return await _context
                .Discounts
                .Where(a =>
                    a.PreInvoiceHeader.CustomerId == customerId &&
                    a.PreInvoiceHeader.Status == invoiceStatus
                ).SumAsync(a => a.Value);
        }

        public async Task<double> GetTotalDiscountByInvoiceHeaderIdAsync(int preInvoiceHeaderId)
        {
            return await _context
                .Discounts
                .Where(a =>
                a.PreInvoiceHeaderId == preInvoiceHeaderId
                ).SumAsync(a => a.Value);
        }


    }
}
