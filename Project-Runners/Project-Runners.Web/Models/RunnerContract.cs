using System;
using ProjectRunners.Common.Enums;

namespace ProjectRunners.Web.Models
{
    /// <summary>
    /// Контракт раннера
    /// </summary>
    public class RunnerContract
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }

        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Состояние </summary>
        public RunnerState State { get; set; }
        
        /// <summary> Дата последнего изменения </summary>
        public DateTimeOffset ChangeDate { get; set; }
    }
}