using AutoMapper;
using ProjectRunners.Application.Runs.Models.Commands;
using ProjectRunners.Application.Runs.Models.Dto;
using ProjectRunners.Common.Models.Contracts;

namespace ProjectRunners.Web.Mapping
{
    /// <summary>
    /// Профиль маппинга
    /// </summary>
    public class RunsProfile : Profile
    {
        public RunsProfile()
        {
            CreateMap<RunDto, RunContract>();

            CreateMap<CaseDto, CaseContract>();

            CreateMap<CreateRunContract, CreateRunCommand>();
        }
    }
}