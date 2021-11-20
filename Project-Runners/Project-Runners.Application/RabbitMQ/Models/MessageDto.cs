namespace Project_Runners.Application.RabbitMQ.Models
{
    /// <summary>
    /// Дто сообщения RabbitMQ
    /// </summary>
    public class MessageDto
    {
        /// <summary> Тело сообщения </summary>
        public object Body { get; set; }
    }
}