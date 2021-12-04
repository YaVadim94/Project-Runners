using ProjectRunners.Common.Enums;

namespace ProjectRunners.Common.Models.Dto
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