using System;
using System.Linq;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using ProjectRunners.Application.Extensions;
using ProjectRunners.Application.Runs.Models.Commands;
using ProjectRunners.Application.Runs.Models.Dto;
using ProjectRunners.Common.Enums;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Data.Models;

namespace ProjectRunners.Application.Runs.Mapping
{
    /// <summary>
    /// Профиль маппинга
    /// </summary>
    public class RunsProfile : Profile
    {
        public RunsProfile()
        {
            CreateMap<Run, RunDto>()
                .MapMember(d => d.TestCaseCount, s => s.Cases.Count);

            CreateMap<Case, CaseDto>();

            CreateMap<CreateRunCommand, Run>()
                .MapMember(d => d.Cases, s => s.CaseIds)
                .MapMember(d => d.Status, s => RunStatus.NotStarted)
                .MapMember(d => d.QueueId, s => Guid.NewGuid())
                .PreserveReferences();

            CreateMap<long, RunCase>()
                .MapMember(d => d.CaseId, s => s)
                .EqualityComparison((s, d) => d.CaseId == s);

            CreateMap<Case, CaseForRunningDto>()
                .IgnoreMember(d => d.RunId);
        }
    }
}