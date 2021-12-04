using System;
using System.Threading.Tasks;
using Project_runners.Common.Models.Contracts;
using Project_runners.Common.Models.Dto;
using ProjectRunners.Common.Enums;

namespace ProjectRunners.Runner.Services
{
    /// <summary>
    /// Сервис для прогона тестов
    /// </summary>
    public class CasePlayer
    {
        public Task<CaseResultContract> Play(CaseForRunningDto dto)
        {
            var caseResult = new CaseResultContract
            {
                Id = dto.Id,
                RunId = dto.RunId,
                Status = CalculateStatus()
            };
            
            Console.WriteLine($"Run: {caseResult.RunId}, Case: {caseResult.Id}, Status: {caseResult.Status}");

            return Task.FromResult(caseResult);
        }
        
        private RunStatus CalculateStatus()
        {
            var value = DateTime.Now.Ticks % 10;
            return value switch
            {
                >= 5 => RunStatus.Successed,
                _ => RunStatus.Failed
            };
        }
    }
}