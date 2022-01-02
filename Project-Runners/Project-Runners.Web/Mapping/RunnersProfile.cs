using AutoMapper;
using ProjectRunners.Application.Extensions;
using ProjectRunners.Application.Runners.Models.Commands;
using ProjectRunners.Application.Runners.Models.Dto;
using ProjectRunners.Common.Models.Contracts;
using ProjectRunners.Common.Protos;
using ProjectRunners.Web.Models;

namespace ProjectRunners.Web.Mapping
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
            CreateMap<RunnerStateContractGrpc, SetStateCommand>();
            CreateMap<ScreenshotContract, SendScreenShotCommand>()
                .MapMember(d => d.Payload, s => s.Payload.ToBase64());
        }
    }
}