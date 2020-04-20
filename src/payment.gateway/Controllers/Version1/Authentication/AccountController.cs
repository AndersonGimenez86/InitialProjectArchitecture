namespace AG.PaymentApp.Controllers.Authentication
{
    using AG.PaymentApp.Application.Services.Authentication;

    public class AccountController
    {
        private readonly ILoginControllerService _service;

        public AccountController()
            : this(new LoginControllerService())
        {
        }
        public AccountController(ILoginControllerService service)
        {
            _service = service;
        }
    }
}