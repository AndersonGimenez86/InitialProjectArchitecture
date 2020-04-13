namespace AG.PaymentApp.gateway.Controllers.Version1
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.application.services.DTO.Merchants;
    using AG.PaymentApp.application.services.Interface;
    using AG.PaymentApp.gateway.Extensions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/[controller]/")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IHostingEnvironment environment;
        private readonly IMerchantApplicationService merchantService;
        //private readonly ILogger logger;

        public MerchantController(
            IHostingEnvironment environment,
            IMerchantApplicationService merchantService)
        //ILogger logger)
        {
            this.environment = environment;
            this.merchantService = merchantService;
            //this.logger = logger;
        }

        /// <summary>
        /// Create a new merchant
        /// </summary>
        /// <param name="merchantDTO">The object to create the merchant from.</param>        
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody]MerchantViewModel merchantDTO)
        {
            try
            {
                if (this.environment.AllowPost())
                {
                    await this.merchantService.CreateAsync(merchantDTO);

                    return Ok();
                }
                return this.Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>        
        /// </summary>
        /// <param name="merchantID">The merchant object id.</param>
        /// <returns>A task to get the merchant by order id.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("Get/{merchantID}")]
        public async Task<IActionResult> Get(Guid merchantID)
        {
            try
            {
                var merchant = await this.merchantService.GetAsync(merchantID);

                if (merchant is null)
                    return NotFound();

                return Ok(merchant);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>        
        /// </summary>
        /// <returns>A task to get all merchants.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var merchants = await this.merchantService.GetAllAsync();
                return Ok(merchants);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
