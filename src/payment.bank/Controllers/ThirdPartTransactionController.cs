using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AG.PaymentApp.bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirdPartTransactionController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }


    }
}
