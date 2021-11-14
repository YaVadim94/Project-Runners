using System.Collections.Generic;
using Project_Runners.Data.Enums;

namespace Project_Runners.Web.Models
{
    /// <summary>
    /// Дто прогона
    /// </summary>
    public class RunContract
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }

        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Статус </summary>
        public RunStatus Status { get; set; }

        /// <summary> Кейсы прогона </summary>
        public IEnumerable<CaseContract> Cases { get; set; }
    }
}