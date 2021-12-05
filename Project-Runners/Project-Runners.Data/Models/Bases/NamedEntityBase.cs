namespace ProjectRunners.Data.Models.Bases
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