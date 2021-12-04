using System.Threading.Tasks;
using Project_runners.Common.Models.Contracts;
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
        [Patch("/runners/set-state")]
        public Task SetState(RunnerStateContract contract);
    }
}