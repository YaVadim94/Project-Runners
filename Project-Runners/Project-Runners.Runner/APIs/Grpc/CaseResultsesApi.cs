using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using ProjectRunners.Protos;

namespace ProjectRunners.Runner.APIs.Grpc
{
    /// <summary>
    /// API результатов тестов
    /// </summary>
    public class CaseResultsesApi : ICaseResultsApi
    {
        private readonly IConfiguration _configuration;

        public CaseResultsesApi(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Создать результат прогона теста
        /// </summary>
        public async Task<NoResponseCaseResultsGrpc> Create(CaseResultContractGrpc contract)
        {
            var channel = GrpcChannel.ForAddress(_configuration.GetSection("ProjectRunners").Value);

            var client = new CaseResultControllerGrpc.CaseResultControllerGrpcClient(channel);

            try
            {
                return await client.CreateAsync(contract);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"---> Could not call Grpc server {ex.Message}");
                throw;
            }
        }
    }
}