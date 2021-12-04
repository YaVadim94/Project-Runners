using System.Threading.Tasks;
using ProjectRunners.Protos;

namespace ProjectRunners.Runner.APIs.Grpc
{
    /// <summary>
    /// API результатов тестов
    /// </summary>
    public interface ICaseResultsApi
    {
        /// <summary>
        /// Создать результат прогона теста
        /// </summary>
        Task<NoResponseCaseResultsGrpc> Create(CaseResultContractGrpc contract);
    }
}