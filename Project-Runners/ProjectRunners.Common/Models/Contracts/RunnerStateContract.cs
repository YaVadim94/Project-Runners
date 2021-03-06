using ProjectRunners.Common.Enums;

namespace ProjectRunners.Common.Models.Contracts
{
    /// <summary>
    /// Контракт состояния раннера
    /// </summary>
    public class RunnerStateContract
    {
        /// <summary> Идентификатор раннера </summary>
        public long RunnerId { get; set; }

        /// <summary> Состояние раннера </summary>
        public RunnerState State { get; set; }
    }
}