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
            appstate.OnChange += StateHasChanged;
        }
        public void Dispose()
        {
            appstate.OnChange -= StateHasChanged;
        }

    }
}
