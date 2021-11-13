using System.Linq;
using AutoMapper;
using Project_Runners.Application.Extensions;
using Project_Runners.Data.Models;
using Project_Runners.Web.Models;

namespace Project_Runners.Web.Mapping
{
    /// <summary>
    /// Профиль маппинга
    /// </summary>
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<Run, RunDto>()
                .MapMember(d => d.Cases, s => s.Cases.Select(c => c.Case));

            CreateMap<Case, CaseDto>();
        }
    }
}