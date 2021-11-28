using System.Threading.Tasks;
using Project_runners.Common.Models.Contracts;
using Refit;

namespace Project_Runners.Runner.APIs
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