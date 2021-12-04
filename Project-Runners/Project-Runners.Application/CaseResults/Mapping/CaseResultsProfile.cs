using AutoMapper;
using Project_Runners.Application.CaseResults.Models.Commands;
using Project_Runners.Application.Extensions;
using Project_Runners.Data.Models;

namespace Project_Runners.Application.CaseResults.Mapping
{
    /// <summary>
    /// Мапинг для результатов тестов
    /// </summary>
    public class CaseResultsProfile : Profile
    {
        public CaseResultsProfile()
        {
            CreateMap<CreateCaseResultCommand, CaseResult>()
                .IgnoreMember(d => d.Id)
                .MapMember(d => d.CaseId, s => s.Id);
        }
    }
}