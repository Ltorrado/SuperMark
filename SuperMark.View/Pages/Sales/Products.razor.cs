using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MudBlazor;
using SuperMark.Aplication.Store.Interfaces;
using SuperMark.Aplication.ViewModel;
using SuperMark.Common;
using SuperMark.Common.Model;
using SuperMark.View.Pages.Sales.Dialog;

namespace SuperMark.View.Pages.Sales
{
    public partial class Products:IDisposable
    {
        [Inject] IAppStore appStore { get; set; }
        [Inject] AppState appContext { get; set; }
        public AppViewModel viewModel { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }
        [Inject] private IDialogService DialogService { get; set; }
        protected override async Task OnInitializedAsync()
        {
           
            viewModel = new AppViewModel(appStore, appContext);
            await viewModel.LoadProductsAsync();
            appContext.OnshowCart += ShowCartAsync;

        }


        public async void ShowCartAsync()
        {
            try
            {
             await   InvokeAsync(() =>
                {
                    var resultCreate =   DialogService.Show<CartDialog>("",
                             new DialogParameters { ["viewModel"] = viewModel },
                             new DialogOptions() { DisableBackdropClick = true, MaxWidth = MaxWidth.Small, FullWidth = true }).Result;
                });
          
            }
            catch (Exception)
            {

              
            }

      

        }


        public void addToCart(Product product)
        {

          var producctAlreadyAdded =  viewModel.ProductsCart.FirstOrDefault(x =>x.Id == product.Id );
            if(producctAlreadyAdded != null)
            {
                producctAlreadyAdded.Quantity = producctAlreadyAdded.Quantity + product.Quantity;
            }
            else
            {
                viewModel.ProductsCart.Add(new Product(product));
                appContext.SetCounter(appContext._counter+1);
            

            }
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopRight;
            Snackbar.Add("Producto agregado correctamente", Severity.Success);

        }

        public  string CheckImagenExist( string url)
        {
        

         
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "HEAD";
                request.GetResponse();
          
                return url;
            }
            catch(Exception ex)
            {
            
                return "https://www.digitallearning.es/wp-content/uploads/2017/03/Test_cuadrado.jpg";
            }
         
        }


        public async Task BuyAsync(Product pro) {

            var quantityString = pro.Quantity == 1 ? "unidad" : "unidades";

            bool? result = await DialogService.ShowMessageBox(
            "Advertencia",
            "¿Esta Seguro que desea comprar "+pro.Quantity+" "+ quantityString+ " de este producto?",
            yesText: "Si!", cancelText: "No");

            if (result != null)
            {
             var resultSell =   await viewModel.SellProduct(pro);

                if(resultSell)
                {
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopRight;
                    Snackbar.Add("Compra Exitosa, Estamos preparando su envio", Severity.Success);
                }
                else
                {
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopRight;
                    Snackbar.Add("Ha ocurrido un error, por favor vuelva intentarlo", Severity.Error);
                }
            }




        }


        public string numberpoints()
        {
            return "";
        }


        public void Add(bool value, Product pro)
        {
            if (value)
            {

                pro.Quantity++;
            }
            else
            {if (pro.Quantity > 0)
                {
                    pro.Quantity--;
                }
            
            }
        }

        public void Dispose()
        {
            appContext.OnChange -= ShowCartAsync;
        }
    }
}
