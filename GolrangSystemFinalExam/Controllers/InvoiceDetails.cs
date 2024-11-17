using DocumentFormat.OpenXml.Vml;
using GolrangSystemFinalExam.API.Models;
using GolrangSystemFinalExam.Core.Domains;
using GolrangSystemFinalExam.Core.Domains.Common;
using GolrangSystemFinalExam.Core.Interfaces;
using GolrangSystemFinalExam.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GolrangSystemFinalExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetails : BaseController
    {
        private readonly IPreInvoiceDetailsRepository _service;
        private readonly ISellLineProductRepository _sellLineProductRepository;
        private readonly IPreInvoiceHeaderRepository _preInvoiceHeaderRepository;
        private readonly IDiscountRepository _discountRepository;

        public InvoiceDetails(
            IPreInvoiceDetailsRepository service, 
            ISellLineProductRepository sellLineProductRepository,
            IPreInvoiceHeaderRepository preInvoiceHeaderRepository,
            IDiscountRepository discountRepositor)
        {
            _service = service;
            _sellLineProductRepository = sellLineProductRepository;
            _preInvoiceHeaderRepository = preInvoiceHeaderRepository;
            _discountRepository = discountRepositor;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GellAll(GetTotalAmountDto model)
        {
            var result = await _service.GetAllAsync();
            return CustomOk(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post(InvoiceDetailAddDto model)
        {
            if (await _service.IsRepetitive(model.ProductId))
                return CustomError("تکراری");

            if (!await _sellLineProductRepository.IsProductExistAsync(model.ProductId))
                return CustomError("عدم وجود کالا در لاین فروش"); ;

            var result = await _service.CreateAsync(new()
            {
                ProductId = model.ProductId,
                Count = model.Count,
                Price = model.Price,
                PreInvoiceHeaderId = model.PreInvoiceHeaderId
            });
            return CustomOk("با موفقیت درج شد.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(InvoiceDetailEditDto model)
        {
            var PreInvoiceHeader = await _preInvoiceHeaderRepository.GetByIdAsync(model.PreInvoiceHeaderId);
            if(PreInvoiceHeader is null)
                return CustomError("عدم وجود فاکتور");

            if (PreInvoiceHeader.Status == InvoiceStatus.Final)
                return CustomError("فاکتور نهایی شده");

            await _service.UpdateAsync(new()
            {
                Id = model.Id,
                ProductId = model.ProductId,
                Count = model.Count,
                Price = model.Price,
                PreInvoiceHeaderId = model.PreInvoiceHeaderId
            });
            return CustomOk("با موفقیت ویرایش شد.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return CustomOk("با موفقیت حذف شد.");
        }

        [HttpPost("InvoiceTotalAmount")]
        public async Task<IActionResult> InvoiceTotalAmountAsync(GetTotalAmountDto model)
        {
            var total = await _service.GetInvoiceTotalAmountAsync(model.customerId, model.invoiceStatus);
            if (model.discountIncluded)
                total -= await _discountRepository.GetTotalDiscountByCustomerIdAsync(model.customerId, model.invoiceStatus);

            return CustomOk(total);
        }

    }
}
