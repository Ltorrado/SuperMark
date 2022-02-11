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

namespace SuperMark.View.Pages.Reports
{
    public partial class ReportView
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
            await viewmodel.LoadTopSales(true);
          

        }
        /// <summary>
        /// busca el mas vendido dependiendo al bool top para identificar el tipo de busqueda
        /// </summary>
        /// <returns></returns>
        public async Task TopSaleAsync(bool top)
        {
            await viewmodel.LoadTopSales(top);
        }


    }
}