using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RestSharp;
using SuperMark.Common.Model;
using SuperMark.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Aplication.Store.Interfaces
{
    public class AppStore : IAppStore
    {


   

        public async Task<int> DeleteProduct(int deleteCode)
        {
            Uri baseUrl = new Uri("http://localhost:49410/");
            var client = new RestClient(baseUrl);
            var request = new RestRequest("api/Product?id="+deleteCode, Method.Delete).AddBody(deleteCode);

            request.RequestFormat = DataFormat.Json;
            var response = (await client.DeleteAsync<int>(request));
            return response;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            Uri baseUrl = new Uri("http://localhost:49410/");
            var client = new RestClient(baseUrl);
            var request = new RestRequest("api/Product/getall", Method.Get) ;

           var response = (await client.ExecuteGetAsync<List<Product>>(request))?.Data;
            return response;
        }

        public async Task<string> Login(string usr, string psw)
        {
            Uri baseUrl = new Uri("http://localhost:49410/");
            var client = new RestClient(baseUrl);
         
            var request = new RestRequest("api/user/login?user="+ usr + "&psw="+psw, Method.Get);

            var response = (await client.ExecuteGetAsync<string>(request))?.Data;
            return response;
        }

        public async Task<int> ModifyProduct(Product product)
        {
            Uri baseUrl = new Uri("http://localhost:49410/");
            var client = new RestClient(baseUrl);
            var request = new RestRequest("api/Product", Method.Put).AddBody(product);

            request.RequestFormat = DataFormat.Json;
            var response = (await client.ExecutePutAsync<int>(request)).Data;
            return response;
        }

        public async Task<Product> SaveProduct(Product product)
        {
            try
            {
                Uri baseUrl = new Uri("http://localhost:49410/");
                var client = new RestClient(baseUrl);
                var request = new RestRequest("api/Product", Method.Post).AddBody(product);

                request.RequestFormat = DataFormat.Json;
                var response = (await client.ExecutePostAsync<Product>(request)).Data;
                return response;

            }
            catch (Exception ex)
            {

                throw;
            }
    
        }

        public async Task<Sale> SellProduct(Sale sale)
        {
            Uri baseUrl = new Uri("http://localhost:49410/");
            var client = new RestClient(baseUrl);
            var request = new RestRequest("api/sale", Method.Post).AddBody(sale);

            request.RequestFormat = DataFormat.Json;
            var response = (await client.ExecutePostAsync<Sale>(request)).Data;
            return response;
        }

        public async Task<List<TopSale>> TopSale(bool top)
        {
            Uri baseUrl = new Uri("http://localhost:49410/");
            var client = new RestClient(baseUrl);

            var request = new RestRequest("api/sale/topsales?top=" + top , Method.Get);

            var response = (await client.ExecuteGetAsync<List<TopSale>>(request))?.Data;
            return response;
        }
    }
}
