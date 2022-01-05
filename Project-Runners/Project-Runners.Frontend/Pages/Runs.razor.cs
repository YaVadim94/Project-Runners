using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Project_Runners.Frontend.Models;

namespace Project_Runners.Frontend.Pages
{
    /// <summary>
    /// Страница прогонов
    /// </summary>
    public partial class Runs : ComponentBase
    {
        private ICollection<Run> _runList;

        protected override async Task OnInitializedAsync()
        {
            _runList = new List<Run>
            {
                new Run
                {
                    Id = 1,
                    Name = "First",
                    TestCases = new List<TestCase>
                    {
                        new TestCase
                        {
                            Id = 1,
                            Name = "First"
                        }
                    }
                }
            };

            await Task.CompletedTask;
        }
    }
}