using System.Linq;
using AutoMapper;
using Project_Runners.Application.Extensions;
using Project_Runners.Application.Runs.Models.Dto;
using Project_Runners.Data.Models;
using Project_Runners.Web.Models;

namespace Project_Runners.Web.Mapping
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
        }
    }
}