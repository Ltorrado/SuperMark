using Microsoft.AspNetCore.Components;
using SuperMark.Common;
using SuperMark.View.Auth;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMark.View.Shared
{
    public partial class MainLayout:IDisposable
    {
        [Parameter] public int counter { get; set; }
        [Inject] AppState appstate { get; set; }
        [Inject] NavigationManager navigation { get; set; }
        [Inject] SuperMarketStateProvider authenticationStateProvider { get; set; }
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
            try
            {
                await InvokeAsync(StateHasChanged);
            }
            catch (Exception)
            {

                throw;
            }
            // InvokeAsync is inherited, it syncs the call back to the render thread
          
        }
    

    public async Task logout()
        {
            await authenticationStateProvider.SetTokenAsync(null);
            navigation.NavigateTo("/", true);
            await InvokeAsync(StateHasChanged);
        }

        public void ShowCart() {

            appstate.ShowCart();
        }

    }
}
