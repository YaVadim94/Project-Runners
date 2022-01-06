using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Project_Runners.Frontend.Models;
using Project_Runners.Frontend.ViewServices;

namespace Project_Runners.Frontend.Pages
{
    /// <summary>
    /// Страница прогона
    /// </summary>
    public partial class RunPage : ComponentBase
    {
        private Run _run;
        
        [Parameter] public long Id { get; set; }

        [Inject] public IRunsService RunsService { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            _run = await RunsService.GetById(Id);
        }
    }
}