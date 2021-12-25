using ProjectRunners.Common.Enums;

namespace Project_Runners.Frontend.Models
{
    /// <summary>
    /// Раннер
    /// </summary>
    public class Runner
    {
        /// <summary> Идентификатор </summary>
        public long? Id { get; set; }

        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Состояние </summary>
        public RunnerState State { get; set; }
    }
}