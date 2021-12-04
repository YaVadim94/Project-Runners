namespace ProjectRunners.Data.Models.Base
{
    /// <summary>
    /// Базовая сущность с наименованием
    /// </summary>
    public class NamedEntityBase : EntityBase
    {
        /// <summary> Наименование </summary>
        public string Name { get; set; }
    }
}