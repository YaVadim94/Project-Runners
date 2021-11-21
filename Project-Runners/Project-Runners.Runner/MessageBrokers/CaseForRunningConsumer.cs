using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Project_runners.Common.Models;
using Project_Runners.Data.Enums;
using Project_Runners.Runner.APIs;
using Project_Runners.Runner.Services;
using RabbitMQ.Client.Events;
using Refit;

namespace Project_Runners.Runner.MessageBrokers
{
    /// <summary>
    /// Брокер для работы с RabbitMq
    /// </summary>
    public class CaseForRunningConsumer : MessageBrokerBase
    {
        private readonly CaseRunService _caseRunService;
        private readonly ICaseResultsApi _caseResultsApi;

        public CaseForRunningConsumer(IConfiguration configuration, CaseRunService caseRunService) : base(configuration)
        {
            _caseRunService = caseRunService;
            _caseResultsApi = RestService.For<ICaseResultsApi>(configuration.GetSection("Project-Runners.Api").Value);
        }

        /// <summary>
        /// Обработать сообщение
        /// </summary>
        protected override void Consume(object obj, BasicDeliverEventArgs args)
        {
            try
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var testCaseDto = JsonConvert.DeserializeObject<CaseForRunningDto>(message);

                var result = _caseRunService.RunCase(testCaseDto);
                _caseResultsApi.SendResult(result);
                
                Task.Delay(1000).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}