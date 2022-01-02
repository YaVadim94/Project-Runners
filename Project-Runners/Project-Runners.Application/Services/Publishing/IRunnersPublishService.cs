using ProjectRunners.Common.MessageBroker.Models;
using ProjectRunners.Common.Models.Dto;

namespace ProjectRunners.Application.Services.Publishing
{
    /// <summary>
    /// Сервис для публикации сообщений раннерам
    /// </summary>
    public interface IRunnersPublishService
    {
        /// <summary>
        /// Опубликовать сообщение раннеру
        /// </summary>
        void Publish(RunnerCommandDto dto, long runnerId);
    }
}