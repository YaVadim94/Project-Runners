using ProjectRunners.Common.Enums;
using ProjectRunners.Data.Models.Base;

namespace ProjectRunners.Data.Models
{
    /// <summary>
    /// Раннер
    /// </summary>
    public class Runner : EntityBase
    {
        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Состояние </summary>
        public RunnerState State { get; set; } = RunnerState.Disconnected;
    }
}