using AG.PaymentApp.Domain.Entity.Mongo;
using AG.PaymentApp.Domain.Entity.Shoppers;
using AG.PaymentApp.Domain.Core.ValueObject;
using AutoMapper;

namespace AG.PaymentApp.Domain.Query.Mapper
{
    public class ShopperProfile : Profile
    {
        public ShopperProfile()
        {
            this.CreateMap<ShopperMongo, Shopper>()
                .ConstructUsing(s => Shopper.CreateNew(s.Gender, s.ShopperID, s.FirstName, s.LastName, s.Email))
                .ForMember(m => m.Id, opt => opt.MapFrom(mm => mm.ShopperID))
                .ForMember(s => s.Address, opt => opt.MapFrom(mm => mm.Address));

            this.CreateMap<AddressMongo, Address>()
                .ConstructUsing(a => Address.Create(a.AddressID, a.Street, a.Number, a.City, a.Zip, a.Country));
        }
    }
}
