namespace Project_Runners.Frontend.Models
{
    /// <summary>
    /// Тест-кейс
    /// </summary>
    public class TestCase
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }

        /// <summary> Наименование </summary>
        public string Name { get; set; }
        
        /// <summary> Описание </summary>
        public string Description { get; set; }
    }
}