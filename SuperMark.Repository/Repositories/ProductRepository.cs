using SuperMark.Common.Model;
using SuperMark.Repository.DbContexts;
using SuperMark.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {

            _connectionString = connectionString;
        }

        public int Delete(int id)
        {

      
            var result = new Product();
            if (id != 0)
            {
                using (var context = new SupermakDbcontext(_connectionString))
                {


                    result = context.Products.Where(data => data.Id == id)?.FirstOrDefault();
                    if(result == null)
                    {
                        return 0;
                    }
                    else
                    {
                        context.Products.Remove(result);
                        context.SaveChanges();
                        return 1;
                    }

                }
            }
            return 0;

        }

        public Product Get(object parameters)
        {
            int.TryParse(((Dictionary<string, object>)parameters)?["id"]?.ToString(), out int id);
            var result = new Product();
            if (id != 0)
            {
                using (var context = new SupermakDbcontext(_connectionString))
                {


                    result = context.Products.Where(data => data.Id == id)?.FirstOrDefault();


                }
            }
            return result;
        }

        public List<Product> GetAll()
        {
            using (var context = new SupermakDbcontext(_connectionString))
            {
                var query = (from cause in context.Products
                             select cause);
                var result = query.ToList();

                return result;
            }

        }

        public List<Product> GetTopProducts()
        {
            throw new NotImplementedException();
        }

        public Product Post(object parameters)
        {
            if (!(parameters is Product entity))
                throw new InvalidCastException("objeto incorrecto, se esperaba de tipo Product");

            using (var context = new SupermakDbcontext(_connectionString))
            {

                context.Products.Add(entity);
                if (context.SaveChanges() > 0)
                    return entity;

            }
            return null;
        }

        public int Put(Product parameters)
        {
            using (var context = new SupermakDbcontext(_connectionString))
            {

                context.Products.Update(parameters);
                return context.SaveChanges();

            }
      
        }
    }
}
