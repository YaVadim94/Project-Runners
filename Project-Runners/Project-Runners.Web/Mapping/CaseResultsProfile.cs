using AutoMapper;
using Project_runners.Common.Models.Contracts;
using ProjectRunners.Application.CaseResults.Models.Commands;

namespace ProjectRunners.Web.Mapping
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