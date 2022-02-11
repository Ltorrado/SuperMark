using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SuperMark.Common.Model;
using SuperMark.Repository.Repositories;
using SuperMarket.WebServices.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SuperMark.Test.Services
{
   public class ProductTest
    {

        ProductController _controller;
        public ProductTest()
        {
            var connectionstring = "Server=DESKTOP-1A79BR9\\SQLEXPRESS;Database=Supermark;UID=sa;PWD=12345678;";
            var mock = new Mock<ILogger<ProductController>>();
            ILogger<ProductController> logger = mock.Object;

            //or use this short equivalent 
            logger = Mock.Of<ILogger<ProductController>>();
            _controller = new ProductController(new ProductRepository(connectionstring), logger);
        }


        [Fact]
        public async Task GetAll()
        {

            var result = await _controller.GetAll();

            Assert.True(Utility.CheckService(result));


        }
        [Fact]
        public async Task TestPostError()
        {

            Product product = null;
       
            var result = await _controller.Post(product);

            Assert.True(Utility.CheckService(result));


        }

        [Fact]
        public async Task Post()
        {

            Product product = new Product();
            product.Code = "Test";
            product.Description = "testDesc";
            product.Name = "Nombre producto";
            product.Price = 100;
            product.Img = "https://www.digitallearning.es/wp-content/uploads/2017/03/Test_cuadrado.jpg";
            var result = await _controller.Post(product);

            Assert.True(Utility.CheckService(result));


        }

        [Fact]
        public async Task Put()
        {


            var resultFirst = await _controller.GetAll();
            var resultobjectfirst = resultFirst as ObjectResult;
            var value = resultobjectfirst.Value as List<Product>;
            var first = value.FirstOrDefault();
            first.Name = "modify";
            var result = await _controller.Put(first);
            Assert.True(Utility.CheckService(result));


        }
    }
}
