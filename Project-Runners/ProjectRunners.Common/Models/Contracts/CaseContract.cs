namespace ProjectRunners.Common.Models.Contracts
{
    /// <summary>
    /// Дто кейса
    /// </summary>
    public class CaseContract
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }
        
        /// <summary> Наименование </summary>
        public string Name { get; set; }
        
        /// <summary> Описание </summary>
        public string Description { get; set; }
    }
}