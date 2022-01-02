using System;
using ProjectRunners.Common;
using ProjectRunners.Common.MessageBroker.Models;
using ProjectRunners.Common.MessageBroker.Publising;
using ProjectRunners.Common.Models.Dto;

namespace ProjectRunners.Application.Services.Publishing
{
    /// <summary>
    /// Сервис для публикации сообщений раннерам по шине
    /// </summary>
    public class RunnersPublishService : IRunnersPublishService
    {
        private readonly IMessagePublisher _messagePublisher;


        public RunnersPublishService(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        public void Publish(RunnerCommandDto dto, long runnerId)
        {
            if (dto.Command is null)
                throw new ArgumentOutOfRangeException(nameof(dto.Command));
            
            _messagePublisher
                .Publish(dto, new DeliveringAddress(CommonConstants.RUNNERS_EXCHANGE, $"runner_{runnerId}"));
        }
    }
}