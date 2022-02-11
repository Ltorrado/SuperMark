using Microsoft.AspNetCore.Components;
using MudBlazor;
using SuperMark.Aplication.ViewModel;
using SuperMark.Common;
using SuperMark.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMark.View.Pages.Sales.Dialog
{
    public partial class CartDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        /// <summary>
        /// Servicio para llamar cajas de dialogo
        /// </summary>
        [Inject] IDialogService DialogService { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }
        [Inject] AppState appstate { get; set; }
        [Parameter]
        public AppViewModel viewModel { get; set; }
        public bool _processing { get; set; }

        public void Cancel()
        {
            ///Limpiar los valores


            MudDialog.Close(DialogResult.Cancel());
        }

        public void DeleteFromCart(Product product)
        {
            viewModel.ProductsCart.Remove(product);
            appstate.SetCounter(appstate._counter-1);
        }

            public async Task SaveAsync()
        {

            if (viewModel.ProductsCart.Count > 0)
            {
                await Processing(true);
                var result = await viewModel.SellMultipleProducts();

                if (!result)
                {
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopRight;
                    Snackbar.Add("Ha ocurrido un error", Severity.Error);
                }
                else
                {
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopRight;
                    Snackbar.Add("Compra Existosa, Estamos Preparando el envio", Severity.Success);
                    viewModel.NewProduct = new Common.Model.Product();

                    MudDialog.Close(DialogResult.Ok(true));
                }
                await Processing(false);
            }
            else
            {
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopRight;
                Snackbar.Add("Por Favor Agrege productos al carrito", Severity.Error);

            }
      

        }
        async Task Processing(bool state)
        {
            _processing = state;
            await Task.Delay(4);
            StateHasChanged();

        }

    }
}
