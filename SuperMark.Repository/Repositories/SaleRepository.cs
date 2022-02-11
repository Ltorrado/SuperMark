using SuperMark.Common.Model;
using SuperMark.Common.ViewModel;
using SuperMark.Repository.DbContexts;
using SuperMark.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Repository.Repositories
{
    public class SaleRepository : ISaleRepository
    {

        private readonly string _connectionString;

        public SaleRepository(string connectionString)
        {
    
            _connectionString = connectionString;
        }


        public Sale Get(object parameters)
        {
            int.TryParse(((Dictionary<string, object>)parameters)?["id"]?.ToString(), out int id);
            var result = new Sale();
            if (id != 0)
            {
                using (var context = new SupermakDbcontext(_connectionString))
                {
             
              
                        result = context.Sales.Where(data => data.Id == id)?.FirstOrDefault();
              
                
                }
            }
            return result;
        }

        public List<Sale> GetAll()
        {
            using (var context = new SupermakDbcontext(_connectionString))
            {
                var query = (from cause in context.Sales
                             select cause);
                var result = query.ToList();

                return result;
            }
      
        }

        public Sale Post(object parameters)
        {
            if (!(parameters is Sale entity))
                throw new InvalidCastException("objeto incorrecto, se esperaba de tipo Sale");

            using (var context = new SupermakDbcontext(_connectionString))
            {

                    context.Sales.Add(entity);
                    if (context.SaveChanges() > 0)
                        return entity;
         
            }
            return null;
        }

        public List<TopSale> TopSales(bool top)
        {
            using (var context = new SupermakDbcontext(_connectionString))
            {
                var query = (from cause in context.Sales
                             select cause);
                var result =   new List<TopSale>();
                var results = from sal in context.Sales
                              join pro in context.Products
                              on sal.ProductId equals pro.Id
                              group new { pro, sal } by new { pro.Name} into g
                              select new TopSale { Product = g.Key.Name, Quantity = g.Sum(x => x.sal.Quantity) };

                if (top)
                {

                    result = results.OrderByDescending(x => x.Quantity).ToList();

                }
                else
                {
                    result = results.OrderBy(x => x.Quantity).ToList();
                 
                }

                return result;
            }

        }
    }
}
