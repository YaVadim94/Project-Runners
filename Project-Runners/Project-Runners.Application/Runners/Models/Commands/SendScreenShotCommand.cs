using MediatR;

namespace ProjectRunners.Application.Runners.Models.Commands
{
    /// <summary>
    /// Команда на отправку скирна на фронт
    /// </summary>
    public class SendScreenShotCommand : IRequest
    {
        /// <summary> Идентификатор раннера </summary>
        public long RunnerId { get; set; }

        /// <summary> Скриншот </summary>
        public string Payload { get; set; }
    }
}