using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SuperMark.Common.Model;
using SuperMark.Managers;
using SuperMark.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        ProductManager Manager;

        private readonly ILogger _logger;
        private static string className = new StackFrame().GetMethod().ReflectedType.Name;
        public ProductController(IProductRepository repository, ILogger<ProductController> logger) {

            Manager = new ProductManager(repository);
            _logger = logger;

        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var result = await Manager.GetAll();
             
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.GetBaseException()}", className, new StackFrame().GetMethod().Name, string.Empty);
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product pro)
        {
            try
            {

                var result = await Manager.Post(pro);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.GetBaseException()}", className, new StackFrame().GetMethod().Name, string.Empty);
                return StatusCode(500, ex);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var result = await Manager.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.GetBaseException()}", className, new StackFrame().GetMethod().Name, string.Empty);
                return StatusCode(500, ex);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(Product pro)
        {
            try
            {

                var result = await Manager.Put(pro);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex?.GetBaseException()}", className, new StackFrame().GetMethod().Name, string.Empty);
                return StatusCode(500, ex);
            }
        }

    }
}
