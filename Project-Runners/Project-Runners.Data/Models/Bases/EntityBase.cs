using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectRunners.Data.Models.Bases
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary> Идентификатор </summary>
        [Key]
        public long Id { get; set; }

        /// <summary> Дата последнего изменения </summary>
        public DateTimeOffset ChangeDate { get; set; }
    }
}