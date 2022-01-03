using AutoMapper;
using ProjectRunners.Application.Extensions;
using ProjectRunners.Application.Runners.Models.Dto;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Data.Models;

namespace ProjectRunners.Application.Runners.Mapping
{
    /// <summary>
    /// Маппинг раннеров
    /// </summary>
    public class RunnersProfile : Profile
    {
        public RunnersProfile()
        {
            CreateMap<Runner, RunnerDto>();
            
            CreateMap<Runner, RunnerPublishDto>()
                .IgnoreMember(d => d.Screenshot);
        }
    }
}