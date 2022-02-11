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
            appstate.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            appstate.OnChange -= StateHasChanged;
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
