using System.Threading.Tasks;
using ProjectRunners.Protos;

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
    }
}