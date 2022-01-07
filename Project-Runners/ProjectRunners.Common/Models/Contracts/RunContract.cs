using System;
using System.Collections.Generic;
using ProjectRunners.Common.Enums;

namespace ProjectRunners.Common.Models.Contracts
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

        /// <summary> Количество тестов в прогоне </summary>
        public int TestCaseCount { get; set; }
        
        /// <summary> Дата создания </summary>
        public DateTimeOffset CreationDate { get; set; }

        /// <summary> Дата запуска </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary> Дата завершения </summary>
        public DateTimeOffset EndDate { get; set; }
    }
}