using ProjectRunners.Common.Models.Dto;

namespace ProjectRunners.Application.Services.Publishing
{
    /// <summary>
    /// Сервис для публикации сообщения по шине для хаба
    /// </summary>
    public interface IHubPublishingService
    {
        void Publish(RunnerPublishDto dto);
    }
}