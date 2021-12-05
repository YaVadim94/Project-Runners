using ProjectRunners.Common.Enums;
using ProjectRunners.Data.Models.Bases;

namespace ProjectRunners.Data.Models
{
    /// <summary>
    /// Результат прохождения кейса
    /// </summary>
    public class CaseResult : EntityBase
    {
        /// <summary> Статус </summary>
        public RunStatus Status { get; set; }

        /// <summary> Идентификатор прогона </summary>
        public long RunId { get; set; }

        /// <summary> Прогон </summary>
        public Run Run { get; set; }

        /// <summary> Идентификатор кейса </summary>
        public long CaseId { get; set; }

        /// <summary> Кейс </summary>
        public Case Case { get; set; }
    }
}