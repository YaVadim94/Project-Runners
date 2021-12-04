using MediatR;
using ProjectRunners.Application.Runs.Models.Dto;

namespace ProjectRunners.Application.Runs.Models.Queries
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