using AutoMapper;
using Project_Runners.Application.Runners.Models.Dto;
using Project_Runners.Data.Models;

namespace Project_Runners.Application.Runners.Mapping
{
    /// <summary>
    /// Маппинг раннеров
    /// </summary>
    public class RunnersProfile : Profile
    {
        public RunnersProfile()
        {
            CreateMap<Runner, RunnerDto>();
        }   
    }
}