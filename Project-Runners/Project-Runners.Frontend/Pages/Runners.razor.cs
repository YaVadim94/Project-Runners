using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Project_Runners.Frontend.Models;
using Project_Runners.Frontend.ViewServices;

namespace Project_Runners.Frontend.Pages
{
    /// <summary>
    /// Страница раннеров
    /// </summary>
    public partial class Runners : ComponentBase
    {
        /// <summary> Раннеры </summary>
        private ICollection<Runner> DataSource { get; set; }

        [Inject] public IRunnersService RunnersService { get; set; }

        /// <summary>
        /// Действия при загрузке страници
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            DataSource = (await RunnersService.GetAll()).ToList();
        }
    }
}