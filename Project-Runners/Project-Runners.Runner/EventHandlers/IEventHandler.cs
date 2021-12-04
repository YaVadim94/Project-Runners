using System.Threading.Tasks;
using ProjectRunners.Common.Models.Dto;

namespace ProjectRunners.Runner.EventHandlers
{
    /// <summary>
    /// Базовый класс для обрабочки событий
    /// </summary>
    public interface IEventHandler
    {
        public Task Handle(MessageDto dto);
    }
}