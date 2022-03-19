using DigitalProduct.Api.Controllers;
using DigitalProduct.Application.Clients;
using DigitalProduct.Application.Generic;
using DigitalProduct.Application.Notifications;
using DigitalProduct.Application.Products;
using DigitalProduct.Application.Products.Dto;
using DigitalProduct.Application.Shoppings;
using DigitalProduct.Core.Domain;
using LazyCache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace DigitalProduct.Test;

public class ShoppingControllerTest
{
    [Test]
    public async Task AddToBasketResponseTest()
    {
        // -- Logger
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<ShoppingController>();

        // -- Repository Product
        var dataResponse = new List<Product>{ new Product()
        {
            Id = 1,
            Name = "Durazno",
            Description = "Durazno"
        } };
        var dataResponse1 = dataResponse.First();
        var productRepository = new Mock<IGenericRepository<Product>>();
        productRepository.Setup(x => x.GetAll()).Returns(dataResponse.AsEnumerable());
        productRepository.Setup(x => x.Get(It.IsAny<long>())).Returns(dataResponse1);

        // -- Repository Notification
        var notificationRepository = new Mock<IGenericRepository<Notification>>();

        // -- Repository Shopping
        var shoppingRepository = new Mock<IGenericRepository<Shopping>>();

        // -- Repository ShoppingProduct
        var shoppingProductRepository = new Mock<IGenericRepository<ShoppingProduct>>();


        // -- Client
        var dataJson = JsonSerializer.Serialize(new MaestroDto
        {
            Id = 2421,
            Name = "Gov. Mayoor Embranthiri",
            Email = "gov_embranthiri_mayoor@wuckert.com",
            Gender = "male",
            Status = "active"
        });
        var client = new Mock<IClient>();
        client.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(dataJson);

        // -- Product Service
        var productService = new ProductService(productRepository.Object, client.Object);

        // -- Notification Service
        var notificationService = new NotificationService(notificationRepository.Object);

        // -- Shopping Service
        var shoppingService = new ShoppingService(shoppingRepository.Object, shoppingProductRepository.Object);

        // -- Mediator
        var mediator = new ShoppingMediator(productService, notificationService, shoppingService);

        var controller = new ShoppingController(logger, mediator, productService);
        Assert.NotNull(controller);

        var response = await controller.AddToBasket(1);
                                
        Assert.NotNull(response);

        Assert.AreEqual((int)HttpStatusCode.OK, (response as OkResult).StatusCode);

    }

    [Test]
    public async Task GetByIdResponseTest()
    {
        // -- Logger
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<ShoppingController>();

        // -- Repository Product
        var dataResponse = new List<Product>{ new Product()
        {
            Id = 1,
            Name = "Durazno",
            Description = "Durazno"
        } };
        var dataResponse1 = dataResponse.First();
        var productRepository = new Mock<IGenericRepository<Product>>();
        productRepository.Setup(x => x.GetAll()).Returns(dataResponse.AsEnumerable());
        productRepository.Setup(x => x.Get(It.IsAny<long>())).Returns(dataResponse1);

        // -- Repository Notification
        var notificationRepository = new Mock<IGenericRepository<Notification>>();

        // -- Repository Shopping
        var shoppingRepository = new Mock<IGenericRepository<Shopping>>();

        // -- Repository ShoppingProduct
        var shoppingProductRepository = new Mock<IGenericRepository<ShoppingProduct>>();


        // -- Client
        var dataJson = JsonSerializer.Serialize(new MaestroDto
        {
            Id = 2421,
            Name = "Gov. Mayoor Embranthiri",
            Email = "gov_embranthiri_mayoor@wuckert.com",
            Gender = "male",
            Status = "active"
        });
        var client = new Mock<IClient>();
        client.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(dataJson);

        // -- Product Service
        var productService = new ProductService(productRepository.Object, client.Object);

        // -- Notification Service
        var notificationService = new NotificationService(notificationRepository.Object);

        // -- Shopping Service
        var shoppingService = new ShoppingService(shoppingRepository.Object, shoppingProductRepository.Object);

        // -- Mediator
        var mediator = new ShoppingMediator(productService, notificationService, shoppingService);

        var controller = new ShoppingController(logger, mediator, productService);
        Assert.NotNull(controller);

        var response = await controller.GetById(1);
        var result = response.Result as OkObjectResult;
        var value = result.Value as MaestroDetalleDto;

        Assert.NotNull(response);
        Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);

        // -- Check object from external and cache
        Assert.AreEqual(2421, value.Maestro.Id);
        Assert.AreEqual("Gov. Mayoor Embranthiri", value.Maestro.Name);
        Assert.AreEqual("gov_embranthiri_mayoor@wuckert.com", value.Maestro.Email);
        Assert.AreEqual("male", value.Maestro.Gender);
        Assert.AreEqual("active", value.Maestro.Status);

        // -- Check object from database
        Assert.AreEqual(1, value.Detalle.Id);
        Assert.AreEqual("Durazno", value.Detalle.Name);
        Assert.AreEqual("Durazno", value.Detalle.Description);

    }


}
