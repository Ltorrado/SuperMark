using Microsoft.AspNetCore.Components;
using MudBlazor;
using SuperMark.Aplication.Store.Interfaces;
using SuperMark.Aplication.ViewModel;
using SuperMark.Common;
using SuperMark.Common.Model;
using SuperMark.View.Pages.Master.Dialog;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMark.View.Pages.Master.View
{
    public partial class MasterView
    {
        [Inject] IAppStore appStore { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }
        public AppViewModel viewmodel { get; set; }
        /// <summary>
        /// Servicio para llamar cajas de dialogo
        /// </summary>
        [Inject] public IDialogService DialogService { get; set; }
        [Inject] AppState appstate { get; set; }
        /// <summary>
        /// Inicializar asincronico
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            viewmodel = new AppViewModel(appStore);
               await viewmodel.LoadProductsAsync();
         
          

        }



        public async Task ShowDialog()
        {
            viewmodel.NewProduct = new Product();
            var resultCreate = await DialogService.Show<CreateProductDialog>("",
                      new DialogParameters { ["viewModel"] = viewmodel },
                      new DialogOptions() { DisableBackdropClick = true, MaxWidth = MaxWidth.Small, FullWidth = true }).Result;

            if(resultCreate.Cancelled == false)
            {
                await viewmodel.LoadProductsAsync();
            
            }
        }
        public async Task ShowDialogModify(Product pro)
        {
            viewmodel.NewProduct = new Product(pro) ;
            var resultCreate = await DialogService.Show<CreateProductDialog>("",
                      new DialogParameters { ["viewModel"] = viewmodel },
                      new DialogOptions() { DisableBackdropClick = true, MaxWidth = MaxWidth.Small, FullWidth = true }).Result;

            if (resultCreate.Cancelled == false)
            {
                await viewmodel.LoadProductsAsync();
           
            }
        }




        public async Task Delete(Product pro)
        {

            bool? resultQuestion = await DialogService.ShowMessageBox(
      "Advertencia",
      "¿Esta seguro que desea Eliminar este producto?",
      yesText: "Si!", cancelText: "No");

            if(resultQuestion  != null)
            {
                var result = await viewmodel.DeleteProduct(pro.Id);

                if (result)
                {
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopRight;
                    Snackbar.Add("Borrado Correctamente", Severity.Success);
                    await viewmodel.LoadProductsAsync();
                }
                else
                {
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopRight;
                    Snackbar.Add("Producto no eliminado, Ya existe una venta con este producto", Severity.Warning);

                }
            }
        
        }
   
    }
}
