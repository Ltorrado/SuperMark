using SuperMark.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Repository.Repositories.Interface
{
  public  interface IProductRepository : IRepository<Product,object>
    {


        List<Product> GetTopProducts();
        int Put(Product parameters);

        int Delete(int id);


    }
}
