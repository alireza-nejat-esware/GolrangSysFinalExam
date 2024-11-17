using GolrangSystemFinalExam.API.Models;
using GolrangSystemFinalExam.Core.Domains.Common;
using GolrangSystemFinalExam.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GolrangSystemFinalExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceHeader : ControllerBase
    {
        private readonly IPreInvoiceHeaderRepository _service;
        private readonly ISellLineSellerRepository _sellLineSellerRepository;
        private readonly IPreInvoiceDetailsRepository _preInvoiceDetailsRepository;

        public InvoiceHeader(
            IPreInvoiceHeaderRepository service,
            ISellLineSellerRepository sellLineProductRepository,
            IPreInvoiceDetailsRepository preInvoiceDetailsRepository)
        {
            _service = service;
            _sellLineSellerRepository = sellLineProductRepository;
            _preInvoiceDetailsRepository = preInvoiceDetailsRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GellAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> Post(int id)
        {
            var item = await _service.GetByIdAsync(id);
            double currentFinaledAmount = await _preInvoiceDetailsRepository.GetInvoiceTotalAmountAsync(item.CustomerId, item.Status);
            if (currentFinaledAmount > 1000000)
                return BadRequest("خطای زیاد بودن مبلغ فاکتور");

            await _service.ChangeStatus(id);
            return Ok("با موفقیت درج شد.");
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post(AddInvoiceHeaderDto model)
        {
            bool iIsExist = await _sellLineSellerRepository.IsExistAsync(model.SellLineId, model.SellerId);
            if (!iIsExist)
                return BadRequest("عدم وجود فروشنده ");

            var result = await _service.CreateAsync(new()
            {
                SellerId = model.SellerId,
                SellLineId = model.SellLineId,
                CustomerId = model.CustomerId,
            });
            return Ok("با موفقیت درج شد.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(EditInvoiceHeaderDto model)
        {

            var item = await _service.GetByIdAsync(model.Id);
            if (item is null)
                return BadRequest("عدم وجود فاکتور");

            if (item.Status == InvoiceStatus.Final)
                return BadRequest("فاکتور نهایی شده است.");

            await _service.UpdateAsync(new()
            {
                Id = model.Id,
                SellerId = model.SellerId,
                SellLineId = model.SellLineId,
                CustomerId = model.CustomerId,
            });
            return Ok("با موفقیت ویرایش شد.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("با موفقیت حذف شد.");
        }

    }
}
