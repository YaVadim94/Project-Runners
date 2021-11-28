namespace Project_runners.Common.Models.Dto
{
    /// <summary>
    /// Дто кейса
    /// </summary>
    public class CaseForRunningDto
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }
        
        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Идентификатор прогона </summary>
        public long RunId { get; set; }
    }
}