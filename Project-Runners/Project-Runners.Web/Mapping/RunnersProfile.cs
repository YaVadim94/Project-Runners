using AutoMapper;
using Project_Runners.Application.Extensions;
using Project_Runners.Application.Runners.Models.Commands;
using Project_Runners.Application.Runners.Models.Dto;
using Project_runners.Common.Models.Contracts;
using Project_Runners.Web.Models;

namespace Project_Runners.Web.Mapping
{
    /// <summary>
    /// Профиль маппинга раннеров
    /// </summary>
    public class RunnersProfile : Profile
    {
        public RunnersProfile()
        {
            CreateMap<RunnerStateContract, SetStateCommand>();
            CreateMap<RunnerDto, RunnerContract>();
        }
    }
}