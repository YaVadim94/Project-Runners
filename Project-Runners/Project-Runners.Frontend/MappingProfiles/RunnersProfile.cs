using AutoMapper;
using Project_Runners.Frontend.Models;
using ProjectRunners.Web.Models;

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
        }
    }
}