﻿namespace AG.PaymentApp.Domain.tests.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using AutoMapper;
    using AG.PaymentApp.Domain.commands;
    using AG.PaymentApp.Domain.commands.Mapper;
    using AG.PaymentApp.Domain.commands.Merchants;
    using AG.PaymentApp.Domain.Entity.Merchants;
    using AG.PaymentApp.Domain.events;
    using AG.PaymentApp.Domain.ValueObject;
    using AG.PaymentApp.repository.commands.Interface;
    using FluentAssertions;
    using Moq;
    using Xunit;

    [ExcludeFromCodeCoverage]
    public class MerchantCommandHandlerTests
    {
        [Fact]
        public async Task ExecuteAsync_PersisteMongoDB()
        {
            //ARRANGE
            var merchantID = Guid.NewGuid();

            var merchantMongo = new MerchantMongo
            {
                Acronym = "Test",
                Country = "United Kingdom",
                Currency = "EUR",
                DateCreated = DateTime.Now,
                IsOnline = true,
                IsVisible = true,
                MerchantID = merchantID,
                Name = "Merchant Test"
            };

            var merchant = new Merchant
            {
                Acronym = "Test",
                Country = new Country.UnitedKingdom(),
                Currency = Currency.Default,
                DateCreated = DateTime.Now,
                IsOnline = true,
                IsVisible = true,
                ID = merchantID,
                Name = "Merchant Test"
            };

            var merchantDataCommand = new MerchantDataCommand(merchantMongo);

            var mockIMerchantEventRepository = new Mock<IMerchantEventRepository>();
            mockIMerchantEventRepository.Setup(r => r.SaveAsync(merchantDataCommand));

            var mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new MerchantProfile()));
            var mapper = mapperConfiguration.CreateMapper();

            var merchantCommandHandler = new MerchantCommandHandler(mockIMerchantEventRepository.Object, mapper);

            //ACT
            var result = merchantCommandHandler.ExecuteAsync(merchant);

            //ASSERT
            result.Exception.Should().BeNull();
        }
    }
}
