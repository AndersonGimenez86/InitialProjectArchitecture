﻿namespace AG.PaymentApp.Domain.tests.Query
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using AutoMapper;
    using AG.PaymentApp.application.services.Adapter;
    using AG.PaymentApp.Domain.Entity.Payments;
    using AG.PaymentApp.Domain.Enum;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.queries.Interface;
    using AG.PaymentApp.Domain.Query.Mapper;
    using AG.PaymentApp.Domain.Query.Payments;
    using AG.PaymentApp.Domain.ValueObject;
    using FluentAssertions;
    using Moq;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class FindPaymentQueryTests
    {
        [Fact]
        public async Task ExecuteAsync_GetFromMongoDB()
        {
            //ARRANGE
            var merchantID = Guid.NewGuid();
            var creditCardID = Guid.NewGuid();
            var shopperID = Guid.NewGuid();
            var paymentID = Guid.NewGuid();

            var paymentMongo = new PaymentMongo
            {
                Amount = Money.Zero,
                CreditCard = default(CreditCardProtected),
                EventName = "Total Payment",
                PaymentID = paymentID,
                Reference = "test",
                ShopperID = shopperID,
                Status = PaymentStatus.Approved,
                DateCreated = DateTime.Now,
                MerchantID = merchantID
            };

            var expectedPayment = new PaymentMongo
            {
                Amount = Money.Zero,
                CreditCard = default(CreditCardProtected),
                EventName = "Total Payment",
                PaymentID = paymentID,
                Reference = "test",
                ShopperID = shopperID,
                Status = PaymentStatus.Approved,
                DateCreated = DateTime.Now,
                MerchantID = merchantID
            };

            var mockIFindPaymentEventRepository = new Mock<IFindPaymentEventRepository>();
            mockIFindPaymentEventRepository.Setup(r => r.GetAsync(paymentID))
                .ReturnsAsync(paymentMongo);

            var findPaymenttQuery = new FindPaymentQuery(paymentID);

            var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new PaymentProfile()));
            var mapper = mapperConfiguration.CreateMapper();

            var mockIAdaptMongoEntityToEntity = new Mock<IAdaptMongoEntityToEntity<PaymentMongo, Payment>>();
            mockIAdaptMongoEntityToEntity.Setup(a => a.Adapt(paymentMongo, mapper));

            var findPaymenttQueryHandler = new FindPaymentQueryHandler(mockIFindPaymentEventRepository.Object, mockIAdaptMongoEntityToEntity.Object, mapper);

            //ACT
            var result = findPaymenttQueryHandler.GetAsync(findPaymenttQuery);

            //ASSERT
            result.Result.Should().NotBeNull();
            result.Result.DateCreated.Should().HaveDay(DateTime.Now.Day);
            result.Result.Reference.Should().BeEquivalentTo(expectedPayment.Reference);
            result.Result.Status.Should().BeEquivalentTo(expectedPayment.Status);
            result.Result.ID.Should().Equals(expectedPayment.PaymentID);
            result.Result.ShopperID.Should().Equals(expectedPayment.ShopperID);
            result.Result.MerchantID.Should().Equals(expectedPayment.MerchantID);
            result.Result.Amount.Should().NotBeNull();
            result.Result.Amount.Currency.Should().NotBeNull();
        }
    }
}

