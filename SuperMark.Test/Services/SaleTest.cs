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
  public  class SaleTest
    {

        SaleController _controller;
        public SaleTest()
        {
            var connectionstring = "Server=DESKTOP-1A79BR9\\SQLEXPRESS;Database=Supermark;UID=sa;PWD=12345678;";
            _controller = new SaleController(new SaleRepository(connectionstring));
        }


        [Fact]
        public async Task GetAll()
        {

            var result = await _controller.TopSales(true);

            Assert.True(Utility.CheckService(result));


        }

        [Fact]
        public async Task Post()
        {

            Sale sal = new Sale();
            sal.ProductId = 7;
            sal.Quantity = 4;
            sal.UserId = 1;
            
            var result = await _controller.Post(sal);

            Assert.True(Utility.CheckService(result));


        }
    }
}
