using MediatR;
using Project_Runners.Application.Runs.Models.Dto;

namespace Project_Runners.Application.Runs.Models.Queries
{
    /// <summary>
    /// Запрос прогона по идентифкатору
    /// </summary>
    public class GetRunByIdQuery : IRequest<RunDto>
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }
    }
}