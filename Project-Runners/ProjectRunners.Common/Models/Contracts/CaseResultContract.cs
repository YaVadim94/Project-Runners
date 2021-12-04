using ProjectRunners.Common.Enums;

namespace Project_runners.Common.Models.Contracts
{
    /// <summary>
    /// Дто результата прогона теста
    /// </summary>
    public class CaseResultContract
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }
        
        /// <summary> Идентификатор прогона </summary>
        public long RunId { get; set; }

        /// <summary> Статус прогона </summary>
        public RunStatus Status { get; set; }
    }
}