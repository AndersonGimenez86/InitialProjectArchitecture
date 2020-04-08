namespace AG.PaymentApp.application.services.Authentication
{
    using AG.PaymentApp.application.services.DTO.Login;
    using AG.PaymentApp.Domain.Entity.Shoppers;

    public interface ILoginControllerService
    {
        Shopper ValidateAndReturn(LoginInputModel model);
        Shopper GetShopper(string userName);
    }
}