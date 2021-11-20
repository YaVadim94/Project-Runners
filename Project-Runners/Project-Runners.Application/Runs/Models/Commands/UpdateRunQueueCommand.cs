using MediatR;

namespace Project_Runners.Application.Runs.Models.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateRunQueueCommand : IRequest
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }
    }
}