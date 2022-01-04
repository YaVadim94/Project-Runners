using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign.TableModels;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Project_Runners.Frontend.Models;
using Project_Runners.Frontend.ViewServices;
using ProjectRunners.Common;
using ProjectRunners.Common.Enums;
using ProjectRunners.Common.Models.Dto;

namespace Project_Runners.Frontend.Pages
{
    /// <summary>
    /// Страница раннеров
    /// </summary>
    public partial class Runners : ComponentBase
    {
        private ICollection<Runner> RunnerList { get; set; }
        private HubConnection HubConnection { get; set; }
        
        [Inject] public IConfiguration Configuration { get; set; }
        [Inject] public IRunnersService RunnersService { get; set; }
        [Inject] public IMapper Mapper { get; set; }

        /// <summary>
        /// Действия при загрузке страници
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            RunnerList = (await RunnersService.GetAll()).ToList();

            HubConnection = new HubConnectionBuilder()
                .WithUrl($"{Configuration["ProjectRunners.Hub"]}/runners-hub")
                .Build();

            HubConnection.On<RunnerPublishDto>(CommonConstants.RUNNER_UPDATE, UpdateRunner);
            HubConnection.Closed += async _ => await HubConnection.StartAsync();
            
            await HubConnection.StartAsync();
        }

        private void UpdateRunner(RunnerPublishDto dto)
        {
            var runner = RunnerList.SingleOrDefault(r => r.Id == dto.Id);
            
            if(runner is null)
                return;

            Mapper.Map(dto, runner);
            StateHasChanged();
        }

        private async Task OnRowExpand(RowData<Runner> runner)
        {
            if(runner.Data.State == RunnerState.Disconnected)
                return;
            
            await RunnersService.RequestForScreenshot(runner.Data.Id.GetValueOrDefault());
        }
            
    }
}