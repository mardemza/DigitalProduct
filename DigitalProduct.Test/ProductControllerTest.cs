using DigitalProduct.Api.Controllers;
using DigitalProduct.Application.Clients;
using DigitalProduct.Application.Generic;
using DigitalProduct.Application.Products;
using DigitalProduct.Application.Products.Dto;
using DigitalProduct.Core.Domain;
using LazyCache;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DigitalProduct.Test;

public class ProductControllerTest
{
    [Test]
    public async Task GetResponseTest()
    {
        // -- Logger
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<ProductController>();

        // -- Product Repository
        var dataResponse = new List<Product>();
        dataResponse.Add(new Product()
        {
            Id = 1,
            Name = "Durazno",
            Description = "Durazno"
        });
        var productRepository = new Mock<IGenericRepository<Product>>();
        productRepository.Setup(x => x.GetAll()).Returns(dataResponse.AsEnumerable());

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

        // -- Controller
        var controller = new ProductController(logger, productService);
        Assert.NotNull(controller);

        var response = await controller.Get();
        Assert.NotNull(response);

        Assert.AreEqual(1, response.Count());
    }

    [Test]
    public async Task GetIdResponseTest()
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<ProductController>();

        // -- Product Repository
        var dataResponse = new Product()
        {
            Id = 1,
            Name = "Durazno",
            Description = "Durazno"
        };
        var productRepository = new Mock<IGenericRepository<Product>>();
        productRepository.Setup(x => x.Get(It.IsAny<long>())).Returns(dataResponse);


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

        var controller = new ProductController(logger, productService);
        Assert.NotNull(controller);

        var response = await controller.Get(1);
        Assert.NotNull(response);

        Assert.AreEqual(1, response.Id);
        Assert.AreEqual("Durazno", response.Name);
        Assert.AreEqual("Durazno", response.Description);
    }

    [Test]
    public async Task InsertResponseTest()
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<ProductController>();

        // -- Product Repository
        var listresponse = new List<Product>();
        listresponse.Add(new Product()
        {
            Id = 1,
            Name = "Durazno",
            Description = "Durazno"
        });
        var productRepository = new Mock<IGenericRepository<Product>>();

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

        var controller = new ProductController(logger, productService);
        Assert.NotNull(controller);

        var input = new ProductInsertDto
        {
            Name = "Pera",
            Description = "Pera"
        };
        var response = controller.Post(input);
        Assert.NotNull(response);
        Assert.IsFalse(response.IsFaulted);
    }

    [Test]
    public async Task UpdateResponseTest()
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<ProductController>();

        // -- Product Repository
        var dataResponse = new Product()
        {
            Id = 1,
            Name = "Durazno",
            Description = "Durazno"
        };
        var productRepository = new Mock<IGenericRepository<Product>>();
        productRepository.Setup(x => x.Get(It.IsAny<long>())).Returns(dataResponse);


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

        var controller = new ProductController(logger, productService);
        Assert.NotNull(controller);

        var input = new ProductUpdateDto
        {
            Name = "Pera",
            Description = "Pera"
        };
        var response = controller.Put(1,input);
        Assert.NotNull(response);
        Assert.IsFalse(response.IsFaulted);
    }

    [Test]
    public async Task DeleteResponseTest()
    {
        // -- Logger
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<ProductController>();

        // -- Product Repository
        var productRepository = new Mock<IGenericRepository<Product>>();

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

        var controller = new ProductController(logger, productService);
        Assert.NotNull(controller);

        var response = controller.Delete(1);

        Assert.NotNull(response);
        Assert.IsFalse(response.IsFaulted);
    }
}
