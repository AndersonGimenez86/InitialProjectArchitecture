namespace AG.PaymentApp.Controllers.Authentication
{
    using AG.PaymentApp.application.services.Authentication;

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