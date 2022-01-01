using ProjectRunners.Common.Enums;

namespace ProjectRunners.Common.Models.Dto
{
    /// <summary>
    /// Дто раннера
    /// </summary>
    public class RunnerPublishDto
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }

        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Состояние </summary>
        public RunnerState State { get; set; }

        /// <summary> Скрин </summary>
        public string Screenshot { get; set; }
    }
}