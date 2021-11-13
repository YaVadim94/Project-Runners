using Project_Runners.Data.Enums;
using Project_Runners.Data.Models.Base;

namespace Project_Runners.Data.Models
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
    }
}