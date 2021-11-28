using System.Threading.Tasks;
using Project_runners.Common.Models;
using Project_runners.Common.Models.Dto;

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