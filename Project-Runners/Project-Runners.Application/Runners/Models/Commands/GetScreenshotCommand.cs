using MediatR;

namespace ProjectRunners.Application.Runners.Models.Commands
{
    /// <summary>
    /// Команда на скриншот
    /// </summary>
    public class GetScreenshotCommand : IRequest
    {
        /// <summary> Идентификатор раннера </summary>
        public long RunnerId { get; set; }
    }
}