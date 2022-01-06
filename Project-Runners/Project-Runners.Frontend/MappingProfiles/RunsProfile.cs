using AutoMapper;
using Project_Runners.Frontend.Models;
using ProjectRunners.Application.Extensions;
using ProjectRunners.Common.Models.Contracts;

namespace Project_Runners.Frontend.MappingProfiles
{
    /// <summary>
    /// Маппинг прогонов
    /// </summary>
    public class RunsProfile : Profile
    {
        public RunsProfile()
        {
            CreateMap<RunContract, Run>();

            CreateMap<CaseContract, TestCase>();
        }
    }
}