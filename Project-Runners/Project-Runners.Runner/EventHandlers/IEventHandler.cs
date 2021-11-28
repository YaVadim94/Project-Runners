using System.Threading.Tasks;
using Project_runners.Common.Models;

namespace Project_Runners.Runner.EventHandlers
{
    /// <summary>
    /// Базовый класс для обрабочки событий
    /// </summary>
    public interface IEventHandler
    {
        public Task Handle(MessageDto dto);
    }
}