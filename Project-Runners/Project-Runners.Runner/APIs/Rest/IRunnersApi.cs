using System.Threading.Tasks;
using ProjectRunners.Common.Models.Contracts;
using Refit;

namespace ProjectRunners.Runner.APIs.Rest
{
    /// <summary>
    /// API раннеров
    /// </summary>
    public interface IRunnersApi
    {
        /// <summary>
        /// Отправить состоние
        /// </summary>
        [Patch("/api/runners/set-state")]
        public Task SetState(RunnerStateContract contract);
    }
}