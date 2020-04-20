namespace AG.PaymentApp.Application.Services.Authentication
{
    using AG.PaymentApp.Application.Services.DTO.Login;
    using AG.PaymentApp.Domain.Entity.Shoppers;

    public class LoginControllerService : ILoginControllerService
    {
        //private readonly ShopperRepository _customerRepository;
        //private readonly IHashingService _hashingService;

        //public LoginControllerService(IShopperRepository customerRepository, IHashingService hashingService)
        //{
        //    _customerRepository = customerRepository;
        //    _hashingService = hashingService;
        //}

        public Shopper ValidateAndReturn(LoginInputModel model)
        {
            return null;
        }
        public Shopper GetShopper(string userName)
        {
            return null;
        }
        //public Customer ValidateAndReturn(LoginInputModel model)
        //{
        //    var customer = _customerRepository.FindById(model.UserName);
        //    if (customer != null)
        //    {
        //        if (model.Password.IsNullOrEmpty())
        //            return customer;
        //        if (_hashingService.Validate(model.Password, customer.PasswordHash))
        //            return customer;
        //    } 
        //    return null;
        //}

        //public Customer GetCustomer(string userName)
        //{
        //    return _customerRepository.FindById(userName);
        //}

        //public bool Register(RegisterInputModel model)
        //{
        //    if (model.IsValid())
        //        return false;

        //    var customer = Customer.CreateNew(model.Gender, model.UserName, model.FirstName, model.LastName, model.Email);
        //    customer.SetAvatar(model.Avatar);
        //    var hash = _hashingService.Hash(model.Password);
        //    customer.SetPasswordHash(hash);
        //    return _customerRepository.Add(customer);
        //}
    }
}