using AutoMapper;
using Project_Runners.Application.CaseResults.Models.Commands;
using Project_runners.Common.Models;

namespace Project_Runners.Application.CaseResults.Mapping
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