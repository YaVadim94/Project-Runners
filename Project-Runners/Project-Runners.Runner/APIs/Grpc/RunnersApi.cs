using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using ProjectRunners.Common.Protos;

namespace ProjectRunners.Runner.APIs.Grpc
{
    /// <summary>
    /// API раннеров grpc
    /// </summary>
    public class RunnersApi : IRunnersApi
    {
        private readonly IConfiguration _configuration;

        public RunnersApi(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Отправить состояние
        /// </summary>
        public async Task<NoResponseGrpc> SetState(RunnerStateContractGrpc contract)
        {
            var channel = GrpcChannel.ForAddress(_configuration.GetSection("ProjectRunners").Value);

            var client = new RunnersControllerGrpc.RunnersControllerGrpcClient(channel);

            try
            {
                return await client.SetStateAsync(contract);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"---> Could not call Grpc server {ex.Message}");
                throw;
            }
        }

        public async Task<NoResponseGrpc> HandleScreenshot(ScreenshotContract contract)
        {
            var channel = GrpcChannel.ForAddress(_configuration.GetSection("ProjectRunners").Value);
            
            var client = new RunnersControllerGrpc.RunnersControllerGrpcClient(channel);
            
            try
            {
                return await client.HandleScreenshotAsync(contract);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"---> Could not call Grpc server {ex.Message}");
                throw;
            }
        }
    }
}