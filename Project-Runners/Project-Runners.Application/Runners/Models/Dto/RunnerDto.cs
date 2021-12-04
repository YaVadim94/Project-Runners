using ProjectRunners.Common.Enums;

namespace ProjectRunners.Application.Runners.Models.Dto
{
    /// <summary>
    /// Дто раннера
    /// </summary>
    public class RunnerDto
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }

        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Состояние </summary>
        public RunnerState State { get; set; }
    }
}