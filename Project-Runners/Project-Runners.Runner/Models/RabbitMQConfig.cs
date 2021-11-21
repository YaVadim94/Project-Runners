namespace Project_Runners.Runner.Models
{
    /// <summary>
    /// Конфигурации для RabbitMQ
    /// </summary>
    public class RabbitMQConfig
    {
        /// <summary> Наименование хоста </summary>
        public string HostName { get; set; }

        /// <summary> Порт </summary>
        public int Port { get; set; }

        /// <summary> Наименование админки </summary>
        public string UserName { get; set; }

        /// <summary> Пароль админки </summary>
        public string Password { get; set; }
    }
}