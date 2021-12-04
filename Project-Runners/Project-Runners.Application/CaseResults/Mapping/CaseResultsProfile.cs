using AutoMapper;
using ProjectRunners.Application.CaseResults.Models.Commands;
using ProjectRunners.Application.Extensions;
using ProjectRunners.Data.Models;

namespace ProjectRunners.Application.CaseResults.Mapping
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