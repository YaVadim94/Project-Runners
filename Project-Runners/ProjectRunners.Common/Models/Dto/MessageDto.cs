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
        
        /// <summary> Данные сообщения </summary>
        public object AddedData { get; set; }
    }
}