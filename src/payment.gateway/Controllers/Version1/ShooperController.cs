namespace AG.PaymentApp.gateway.Controllers.Version1
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.Application.Services.DTO.Shoppers;
    using AG.PaymentApp.Application.Services.Interface;
    using AG.PaymentApp.gateway.Extensions;
    using AG.PaymentApp.Infrastructure.Crosscutting.Logging.Interface;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    //[Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShopperController : ControllerBase
    {
        private readonly IHostingEnvironment environment;
        private readonly IShopperApplicationService shopperService;

        public ShopperController(
            IHostingEnvironment environment,
            IShopperApplicationService shopperService)
        {
            this.environment = environment;
            this.shopperService = shopperService;
        }

        /// <summary>
        /// Create a new shopper
        /// </summary>
        /// <param name="order">The object to create the shopper from.</param>        
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody]ShopperViewModel shopperDTO, [FromServices]ILogger logger)
        {
            try
            {
                if (this.environment.AllowPost())
                {
                    await this.shopperService.CreateAsync(shopperDTO);
                    logger.WriteLog<string>(null);

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
        /// Return a shopper
        /// </summary>
        /// <param name="shopperID">The shopper id object .</param>
        /// <returns>A task to get the shopper by order id.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("Get/{shopperID}")]
        public async Task<IActionResult> Get(Guid shopperID)
        {
            try
            {
                var shopper = await this.shopperService.GetAsync(shopperID);

                if (shopper is null)
                    return NotFound();

                return Ok(shopper);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Return all payments
        /// </summary>
        /// <returns>A task to get all payments.</returns>
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
                var shoppers = await this.shopperService.GetAllAsync();

                if (shoppers is null)
                    return NotFound();

                return Ok(shoppers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        ///// <summary>
        ///// Return the last payment
        ///// </summary>
        ///// <returns>A task to get last payment.</returns>
        //[HttpGet]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(500)]
        //[Route("GetShoppersByGender")]
        //public async Task<IActionResult> GetShoppersByGender(Gender gender)
        //{
        //    try
        //    {
        //        var shopper = await this.shopperService.GetShoppersByGender(gender);

        //        if (shopper is null)
        //            return NotFound();

        //        return Ok(shopper);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}
    }
}