namespace ProjectRunners.Common.MessageBroker.Models
{
    /// <summary>
    /// Адрес доставки сообщения
    /// </summary>
    public record DeliveringAddress(string Exchange, string Queue);
}