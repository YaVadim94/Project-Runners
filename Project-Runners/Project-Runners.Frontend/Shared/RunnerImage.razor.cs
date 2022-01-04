using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Project_Runners.Frontend.Shared
{
    public partial class RunnerImage : ComponentBase
    {
        [Parameter]
        public string ImageSrc { get; set; }

        [Inject] public IJSRuntime JsRuntime { get; set; }
        
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime.InvokeVoidAsync("showPreview");
        }
    }
}