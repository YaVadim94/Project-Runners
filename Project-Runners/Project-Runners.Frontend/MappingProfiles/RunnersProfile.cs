using AutoMapper;
using Project_Runners.Frontend.Models;
using ProjectRunners.Common.Models.Contracts;
using ProjectRunners.Common.Models.Dto;

namespace Project_Runners.Frontend.MappingProfiles
{
    /// <summary>
    /// Маппинг раннеров
    /// </summary>
    public class RunnersProfile : Profile
    {
        public RunnersProfile()
        {
            CreateMap<RunnerContract, Runner>();

            CreateMap<RunnerPublishDto, Runner>()
                .ForMember(d => d.Screenshot, opt => opt.Condition(dto => !string.IsNullOrEmpty(dto.Screenshot)));
        }
    }
}