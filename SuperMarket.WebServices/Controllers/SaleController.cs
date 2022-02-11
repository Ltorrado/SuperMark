using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SuperMark.Common.Model;
using SuperMark.Managers;
using SuperMark.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {

        SaleManager Manager;


        public SaleController(ISaleRepository repository)
        {

            Manager = new SaleManager(repository);
        }


        [HttpGet("topsales")]
        public async Task<IActionResult> TopSales(bool top)
        {
            try
            {

                var result = await Manager.TopSales(top);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Sale sal)
        {
            try
            {

                var result = await Manager.Post(sal);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }





    }
}
