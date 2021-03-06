using AutoMapper;
using ProjectRunners.Application.CaseResults.Models.Commands;
using ProjectRunners.Common.Models.Contracts;
using ProjectRunners.Common.Protos;

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
            CreateMap<CaseResultContractGrpc, CreateCaseResultCommand>();
        }
    }
}