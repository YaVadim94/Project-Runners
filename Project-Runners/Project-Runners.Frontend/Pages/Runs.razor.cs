using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign.TableModels;
using Microsoft.AspNetCore.Components;
using Project_Runners.Frontend.Models;
using Project_Runners.Frontend.ViewServices;

namespace Project_Runners.Frontend.Pages
{
    /// <summary>
    /// Страница прогонов
    /// </summary>
    public partial class Runs : ComponentBase
    {
        private ICollection<Run> _runList;

        [Inject] public IRunsService RunsService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            _runList = (await RunsService.GetAll()).ToList();
        }

        private Dictionary<string, object> OpenRunPage(RowData<Run> row) => new()
        {
            ["id"] = row.Data.Id.ToString(),
            ["onclick"] = new Action(() => NavigationManager.NavigateTo($"{Routes.RUNPAGE}/{row.Data.Id}"))
        };
    }
}