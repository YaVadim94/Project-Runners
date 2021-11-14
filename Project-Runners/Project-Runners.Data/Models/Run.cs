using System.Collections.Generic;
using Project_Runners.Data.Enums;
using Project_Runners.Data.Models.Base;

namespace Project_Runners.Data.Models
{
    /// <summary>
    /// Прогон
    /// </summary>
    public class Run : NamedEntityBase
    {
        /// <summary> Статус </summary>
        public RunStatus Status { get; set; }
        
        /// <summary> Кейсы </summary>
        public ICollection<RunCase> Cases { get; set; }

        /// <summary> Результаты прохождения кейсов </summary>
        public ICollection<CaseResult> CaseResults { get; set; }
    }
}