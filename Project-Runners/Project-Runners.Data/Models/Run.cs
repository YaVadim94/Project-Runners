using System;
using System.Collections.Generic;
using ProjectRunners.Common.Enums;
using ProjectRunners.Data.Models.Bases;

namespace ProjectRunners.Data.Models
{
    /// <summary>
    /// Прогон
    /// </summary>
    public class Run : NamedEntityBase
    {
        /// <summary> Статус </summary>
        public RunStatus Status { get; set; }

        /// <summary> Дата создания </summary>
        public DateTimeOffset CreationDate { get; set; }

        /// <summary> Дата запуска </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary> Дата завершения </summary>
        public DateTimeOffset EndDate { get; set; }

        /// <summary> Кейсы </summary>
        public ICollection<RunCase> Cases { get; set; }

        /// <summary> Результаты прохождения кейсов </summary>
        public ICollection<CaseResult> CaseResults { get; set; }

        /// <summary> Идентификатор очереди </summary>
        public Guid QueueId { get; set; }
    }
}