using MediatR;

namespace ProjectRunners.Application.Runs.Models.Commands
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