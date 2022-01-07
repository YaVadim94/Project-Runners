using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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
        private ICollection<TestCase> _testCases = new List<TestCase>();
        private int _testCasesPerRequest = 5;
        private int _nextPage => 1 + _testCases.Count / _testCasesPerRequest;
        [Parameter] public long RunId { get; set; }
        [Parameter] public int MaxTestCaseCount { get; set; }
        
        [Inject] public IRunsService RunsService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _testCases = (await RunsService.GetTestCases(RunId, _testCasesPerRequest, _nextPage)).ToList();
        }

        private async Task LoadMore(MouseEventArgs arg)
        {
            if (arg.Button != 0)
                return;
            
            _loading = true;
            
            var loadedTestCases = (await RunsService
                .GetTestCases(RunId, _testCasesPerRequest, _nextPage)).ToList();
            
            loadedTestCases.ForEach(x =>
            {
                if(!_testCases.Select(tc => tc.Id).Contains(x.Id))
                    _testCases.Add(x);
            });

            _loading = false;
        }
    }
}