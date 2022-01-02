using ProjectRunners.Common.Enums;

namespace ProjectRunners.Common.Models.Dto
{
    /// <summary>
    /// Дто для взаимодействия раннера и сервера
    /// </summary>
    public class RunnerCommandDto
    {
        /// <summary> Команда раннеру </summary>
        public Command? Command { get; set; }
        
        /// <summary> Данные сообщения </summary>
        public CaseForRunningDto Case { get; set; }
    }
}