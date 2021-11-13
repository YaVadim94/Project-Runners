using System.ComponentModel.DataAnnotations;

namespace Project_Runners.Data.Models.Base
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary> Идентификатор </summary>
        [Key]
        public long Id { get; set; }
    }
}