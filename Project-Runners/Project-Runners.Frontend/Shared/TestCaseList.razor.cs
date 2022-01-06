using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using OneOf.Types;
using Project_Runners.Frontend.Models;

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
    }
}