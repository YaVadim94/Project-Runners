using ProjectRunners.Common.MessageBroker.Models;

namespace ProjectRunners.Common.MessageBroker.Publising
{
    /// <summary>
    /// Отправитель сообщений по шине
    /// </summary>
    public interface IMessagePublisher
    {
        void Publish<T>(T messageDto, DeliveringAddress address);
    }
}