using SuperMark.Common.Model;
using SuperMark.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Aplication.Store.Interfaces
{
  public interface  IAppStore
    {

        Task<List<Product>> GetAllProducts();
        Task<Product> SaveProduct(Product product);
        Task<Sale> SellProduct(Sale product);
        Task<int> ModifyProduct(Product product);
        Task<int> DeleteProduct(int deleteCode);
        Task<string> Login(string usr,string psw);
        Task<List<TopSale>> TopSale(bool top);
    }
}
