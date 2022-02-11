using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using SuperMark.Aplication.ViewModel;
using SuperMark.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMark.View.Pages.Master.Dialog
{
    public  partial class CreateProductDialog
    {

        bool success;
        string[] errors = { };
        MudTextField<string> pwField1;
        MudForm form;
        /// <summary>
        /// MudDialog
        /// </summary>
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

        public async Task SaveAsync()
        {
            var mensaje = viewModel.NewProduct.Id == 0 ? "Guardado" : "Modificado";
                await Processing(true);
                var result = await viewModel.SaveNewProduct();

                if (!result )
                {
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopRight;
                    Snackbar.Add("Ha ocurrido un error", Severity.Error);
                }
                else
                {
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopRight;
                Snackbar.Add(mensaje +" Correctamente", Severity.Success);
                viewModel.NewProduct = new Common.Model.Product();
              
                MudDialog.Close(DialogResult.Ok(true));
                }
                await Processing(false);
          
        }
        /// <summary>
        /// loading del boton
        /// </summary>
        /// <returns></returns>
        async Task Processing(bool state)
        {
            _processing = state;
            await Task.Delay(4);
            StateHasChanged();

        }
 


    }
}
