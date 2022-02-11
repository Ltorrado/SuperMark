using SuperMark.Common.Model;
using SuperMark.Common.ViewModel;
using SuperMark.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Managers
{
  public  class SaleManager
    {
        private readonly ISaleRepository _repository;

        public SaleManager(ISaleRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// metodo que devuleve productos vendidos ordenados 
        /// </summary>
        public async Task<List<TopSale>> TopSales(bool top)
        {
            var TopSales = _repository.TopSales(top);
   

            return TopSales;
        }

        /// <summary>
        /// Agregar venta
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        public async Task<Sale> Post(Sale Product)
        {
            return await Task.Run(() =>
            {
                return _repository.Post(Product);
            });
        }

    }
}
