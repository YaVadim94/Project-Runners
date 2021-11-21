using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Project_runners.Common.Models;
using Project_Runners.Data.Enums;
using RabbitMQ.Client.Events;

namespace Project_Runners.Runner.MessageBrokers
{
    /// <summary>
    /// Брокер для работы с RabbitMq
    /// </summary>
    public class CaseForRunningConsumer : MessageBrokerBase
    {
        public CaseForRunningConsumer(IConfiguration configuration) : base(configuration)
        {
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

                var caseResult = new CaseResultContract
                {
                    Id = testCaseDto.Id,
                    RunId = testCaseDto.RunId,
                    Status = CalculateStatus()
                };
                Console.WriteLine($"Run: {caseResult.RunId}, Case: {caseResult.Id}, Status: {caseResult.Status}");
                
                Task.Delay(1000).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        private RunStatus CalculateStatus()
        {
            var value = DateTime.Now.Ticks % 10;
            return value switch
            {
                >= 5 => RunStatus.Successed,
                _ => RunStatus.Failed
            };
        }
    }
}