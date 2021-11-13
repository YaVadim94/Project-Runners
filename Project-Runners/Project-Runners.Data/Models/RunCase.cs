﻿using Project_Runners.Data.Models.Base;

namespace Project_Runners.Data.Models
{
    /// <summary>
    /// Связывающая таблица для <see cref="Run"/> и <see cref="Case"/>
    /// </summary>
    public class RunCase : EntityBase
    {
        /// <summary> Идентификатор кейса </summary>
        public long CaseId { get; set; }

        /// <summary> Кейс </summary>
        public Case Case { get; set; }

        /// <summary> Идентификатор прогона </summary>
        public long RunId { get; set; }

        /// <summary> Прогон </summary>
        public Run Run { get; set; }
    }
}