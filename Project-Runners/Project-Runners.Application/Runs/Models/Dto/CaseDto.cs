namespace ProjectRunners.Application.Runs.Models.Dto
{
    /// <summary>
    /// Дто кейса
    /// </summary>
    public class CaseDto
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }
        
        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Описание </summary>
        public string Description { get; set; }
    }
}