namespace AG.PaymentApp.Data.Mapper
{
    using AG.PaymentApp.Domain.Entity.Shoppers;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.ValueObject;
    using AutoMapper;
    public class ShopperProfile : Profile
    {
        public ShopperProfile()
        {
            this.CreateMap<Shopper, ShopperMongo>()
                .ConstructUsing(s => ShopperMongo.CreateNew(s.Gender, s.Id, s.FirstName, s.LastName, s.Email, null));

            this.CreateMap<Address, AddressMongo>()
                .ConstructUsing(a => AddressMongo.Create(a.ID, a.Street, a.Number, a.City, a.Zip, a.Country, a.DateCreated));
        }
    }
}
