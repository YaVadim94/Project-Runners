using System.Linq;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Project_Runners.Application.Extensions;
using Project_Runners.Application.Runs.Models.Commands;
using Project_Runners.Application.Runs.Models.Dto;
using Project_Runners.Data.Enums;
using Project_Runners.Data.Models;

namespace Project_Runners.Application.Runs.Mapping
{
    /// <summary>
    /// Профиль маппинга
    /// </summary>
    public class RunsProfile : Profile
    {
        public RunsProfile()
        {
            CreateMap<Run, RunDto>()
                .MapMember(d => d.Cases, s => s.Cases.Select(c => c.Case));

            CreateMap<Case, CaseDto>();

            CreateMap<CreateRunCommand, Run>()
                .MapMember(d => d.Cases, s => s.CaseIds)
                .MapMember(d => d.Status, s => RunStatus.NotStarted)
                .PreserveReferences();

            CreateMap<long, RunCase>()
                .MapMember(d => d.CaseId, s => s)
                .EqualityComparison((s, d) => d.CaseId == s);

        }
    }
}