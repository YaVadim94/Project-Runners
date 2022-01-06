using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OneOf.Types;
using Project_Runners.Frontend.Api;
using Project_Runners.Frontend.Models;
using Project_Runners.Frontend.ViewServices;

namespace Project_Runners.Frontend.Shared
{
    /// <summary>
    /// Список тест кейсов
    /// </summary>
    public partial class TestCaseList : ComponentBase
    {
        private bool _loading = false;
        private ICollection<TestCase> _testCases;

        [Parameter] public long RunId { get; set; }
        
        [Inject] public IRunsService RunsService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _testCases = (await RunsService.GetTestCases(RunId, 10, 1)).ToList();
        }
    }
}