using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Project_Runners.Frontend.Models;
using ProjectRunners.Common.Enums;

namespace Project_Runners.Frontend.Pages
{
    /// <summary>
    /// Страница раннеров
    /// </summary>
    public partial class Runners : ComponentBase
    {
        public Runners()
        {
            DataSource = new List<Runner>
            {
                new () {Id = 1, Name = "First", State = RunnerState.Running},
                new () {Id = 2, Name = "Second", State = RunnerState.Waiting},
                new () {Id = 3, Name = "Third", State = RunnerState.Disconnected}
            };
        }

        /// <summary> Раннеры </summary>
        private ICollection<Runner> DataSource { get; set; }
    }
}