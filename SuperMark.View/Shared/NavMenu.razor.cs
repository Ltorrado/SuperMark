using Microsoft.AspNetCore.Components;
using SuperMark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMark.View.Shared
{
    public partial class NavMenu:IDisposable
    {
        [Inject] AppState appstate { get; set; }
        protected override void OnInitialized()
        {
            appstate.OnChange += OnMyChangeHandler;
        }
        public void Dispose()
        {
            appstate.OnChange -= OnMyChangeHandler;
        }
        private async void OnMyChangeHandler()
        {
            // InvokeAsync is inherited, it syncs the call back to the render thread
            try
            {
                await InvokeAsync(StateHasChanged);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
