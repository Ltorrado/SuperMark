using Microsoft.AspNetCore.Components;
using MudBlazor;
using SuperMark.Aplication.Store.Interfaces;
using SuperMark.Aplication.ViewModel;
using SuperMark.View.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMark.View.Pages.Login
{
    public partial class LoginView
    {

        [Inject] IAppStore appStore { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }
        public AppViewModel viewmodel { get; set; }
        MudForm form;
        public string user { get; set; }
        public string psw { get; set; }
        public bool validForm { get; set; }
        public bool _processing { get; set; }
        [Inject] SuperMarketStateProvider TokenProvider { get; set; }
        [Inject]
        NavigationManager NavManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            viewmodel = new AppViewModel(appStore);
         

        }
        public async Task LoginAsync()
        {
        await    Processing(true);
           await form.Validate();
            if (form.IsValid)
            {
                var token = await viewmodel.Login(user, psw);
                if (!string.IsNullOrEmpty(token))
                {
                    var result = await TokenProvider.SetTokenAsync(token);
                    if (result)
                    {
                        var isAutenticated = await TokenProvider.IsAuthenticated();
                        if (isAutenticated)
                        {
                            NavManager.NavigateTo("/", true);
                            await InvokeAsync(StateHasChanged);
                        }
                    }
                }
                else
                {
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopRight;
                    Snackbar.Add("Usuario o contraseña incorrecto", Severity.Warning);
                }
              
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
