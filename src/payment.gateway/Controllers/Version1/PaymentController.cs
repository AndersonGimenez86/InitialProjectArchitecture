namespace AG.PaymentApp.gateway.Controllers.Version1
{
    using System;
    using System.Threading.Tasks;
    using AG.PaymentApp.application.services.DTO.Payments;
    using AG.PaymentApp.application.services.Interface;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    //[Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IHostingEnvironment environment;
        private readonly IPaymentApplicationService paymentApplicationService;

        //private readonly ILogger logger;

        public PaymentController(
            IHostingEnvironment environment,
            IPaymentApplicationService paymentApplicationService)
        //ILogger logger)
        {
            this.environment = environment;
            this.paymentApplicationService = paymentApplicationService;
            //this.logger = logger;
        }

        /// <summary>
        /// Create a new payment
        /// </summary>
        /// <param name="paymentProcessingDTO">The object to create the payment from.</param>        
        [HttpPost]
        [ProducesResponseType(typeof(PaymentResponseViewModel), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody]PaymentProcessingViewModel paymentProcessingDTO)
        {
            try
            {
                await this.paymentApplicationService.CreateAsync(paymentProcessingDTO);

                return Ok(new PaymentResponseViewModel());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Return a payment
        /// </summary>
        /// <param name="paymentID">The payment id object .</param>
        /// <returns>A task to get the payment by order id.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("Get/{paymentID}")]
        public async Task<IActionResult> Get(Guid paymentID)
        {
            try
            {
                var payment = await this.paymentApplicationService.GetAsync(paymentID);

                if (payment is null)
                    return NotFound();

                return Ok(payment);
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
                var payments = await this.paymentApplicationService.GetAllAsync();

                if (payments is null)
                    return NotFound();

                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Return the last payment
        /// </summary>
        /// <returns>A task to get last payment.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetLastPayment")]
        public async Task<IActionResult> GetLastPaymentReceivedAsync(Guid shopperID)
        {
            try
            {
                var payment = await this.paymentApplicationService.GetLastPaymentReceivedAsync(shopperID);

                if (payment is null)
                    return NotFound();

                return Ok(payment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
