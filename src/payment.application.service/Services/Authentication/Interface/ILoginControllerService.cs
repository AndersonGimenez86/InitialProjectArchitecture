namespace AG.PaymentApp.Application.Services.Authentication
{
    using AG.PaymentApp.Application.Services.DTO.Login;
    using AG.PaymentApp.Domain.Entity.Shoppers;

    public interface ILoginControllerService
    {
        Shopper ValidateAndReturn(LoginInputModel model);
        Shopper GetShopper(string userName);
    }
}