using System.Linq;
using AutoMapper;
using Project_Runners.Application.Extensions;
using Project_Runners.Application.Runs.Models.Dto;
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
        }
    }
}