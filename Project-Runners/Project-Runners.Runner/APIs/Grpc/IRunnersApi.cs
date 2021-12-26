using System.Threading.Tasks;
using ProjectRunners.Common.Protos;

namespace ProjectRunners.Runner.APIs.Grpc
{
    /// <summary>
    /// API раннеров grpc
    /// </summary>
    public interface IRunnersApi
    {
        /// <summary>
        /// Отправить состояние
        /// </summary>
        Task<NoResponseGrpc> SetState(RunnerStateContractGrpc contract);

        /// <summary>
        /// Отправить скриншот
        /// </summary>
        Task<NoResponseGrpc> HandleScreenshot(ScreenshotContract contract);
    }
}