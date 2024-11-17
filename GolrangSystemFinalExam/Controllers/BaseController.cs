using GolrangSystemFinalExam.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GolrangSystemFinalExam.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public IActionResult CustomOk(object? data, string message = "")
        {
            return Ok(new Result()
            {
                Message = message,
                Data = data,
                Status = Status.Success
            });
        }

        public IActionResult CustomError(string message, object data = null)
        {
            return Ok(new Result()
            {
                Message = message,
                Data = data,
                Status = Status.Failed
            });
        }

    }
}
