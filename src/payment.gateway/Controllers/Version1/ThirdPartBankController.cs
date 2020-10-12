using Microsoft.AspNetCore.Mvc;
using Payment.Application.Services.ExternalClient.Interface;
using System;
using System.Threading.Tasks;

namespace Payment.Gateway.Controllers.Version1
{
    public class ThirdPartBankController : Controller
    {
        protected readonly IBankService bankService;

        public ThirdPartBankController(IBankService bankService)
        {
            this.bankService = bankService;
        }

        public async Task<IActionResult> Index()
        {
            var operationResult = await bankService.GetOperationAsync(Guid.NewGuid());

            if(operationResult.IsSuccess)
                return Ok(operationResult.response);

            return NotFound();
        }
    }
}
