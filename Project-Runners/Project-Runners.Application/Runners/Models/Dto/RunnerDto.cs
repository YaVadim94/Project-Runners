using Project_runners.Common.Enums;

namespace Project_Runners.Application.Runners.Models.Dto
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