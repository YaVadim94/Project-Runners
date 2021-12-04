using AutoMapper;
using Project_Runners.Application.CaseResults.Models.Commands;
using Project_runners.Common.Models.Contracts;

namespace Project_Runners.Web.Mapping
{
    /// <summary>
    /// Мапинг для результатов тестов
    /// </summary>
    public class CaseResultsProfile : Profile
    {
        public CaseResultsProfile()
        {
            CreateMap<CaseResultContract, CreateCaseResultCommand>();
        }
    }
}