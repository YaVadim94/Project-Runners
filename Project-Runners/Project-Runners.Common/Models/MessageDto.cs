using Project_runners.Common.Enums;

namespace Project_runners.Common.Models
{
    /// <summary>
    /// Дто для взаимодействия раннера и сервера
    /// </summary>
    public class MessageDto
    {
        /// <summary> Команда раннеру </summary>
        public Command? Command { get; set; }
        
        /// <summary> Кейс для прогона </summary>
        public CaseForRunningDto Case { get; set; }
    }
}