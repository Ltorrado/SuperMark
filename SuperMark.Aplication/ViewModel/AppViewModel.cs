using SuperMark.Aplication.Store.Interfaces;
using SuperMark.Common;
using SuperMark.Common.Model;
using SuperMark.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Aplication.ViewModel
{
    public class AppViewModel
    {
        IAppStore _appStore;
        AppState appContext;
        public AppViewModel(IAppStore appStore,AppState context)
        {
            _appStore = appStore;
            appContext = context;
        }
        public AppViewModel(IAppStore appStore)
        {
            _appStore = appStore;
        
        }
        public List<Product> ProductsList { get; set; } = new List<Product>();
        public List<Product> ProducFilter { get; set; } = new List<Product>();
        public List<Product> ProductsCart { get; set; } = new List<Product>();

        public List<TopSale> TopSales { get; set; } = new List<TopSale>();
        public Product NewProduct { get; set; } = new Product();
        public async Task LoadProductsAsync()
        {
            ProductsList = await _appStore.GetAllProducts();
            ProducFilter = ProductsList.ToList();

        }
        public async Task LoadTopSales(bool top)
        {
            TopSales = await _appStore.TopSale(top);

        }
        public async Task<string> Login(string user,string psw)
        {
            try
            {

                    var tockem = await _appStore.Login(user, psw);

                return tockem;

            }
            catch (Exception ex)
            {

                return "";
            }

        }

        public async Task<bool> SellMultipleProducts()
        {
            foreach (var item in ProductsCart)
            {
              await  SellProduct(item);
            }
            ProductsCart = new List<Product>();
            return true;

        }


        public async Task<bool> SellProduct(Product pro)
        {

            Sale sale = new Sale() {
                ProductId = pro.Id,
                Quantity= pro.Quantity,
                UserId= appContext.User.Id
            };

            

         var result =   await _appStore.SellProduct(sale);

            if(result == null)
            {
                return false;
            }
            else
            {
                return true;
            }

          
        }
        


            public async Task<bool> SaveNewProduct()
        {
            try
            {
             
                if(NewProduct?.Id != 0)
                {
                    var newProduct = await _appStore.ModifyProduct(NewProduct);
                    return newProduct == 0 ? false : true;
                }
                else
                {
                    var newProduct = await _appStore.SaveProduct(NewProduct);
                    
                    return newProduct?.Id == 0 ? false : true;
                }
           
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var newProduct = await _appStore.DeleteProduct(id);
                return newProduct == 0 ? false : true;

            }
            catch (Exception ex)
            {

                return false;
            }

        }


    }
}
