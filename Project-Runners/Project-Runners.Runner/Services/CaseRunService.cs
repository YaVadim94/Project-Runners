using System;
using Project_runners.Common.Models;
using Project_Runners.Data.Enums;

namespace Project_Runners.Runner.Services
{
    /// <summary>
    /// Сервис для прогона тестов
    /// </summary>
    public class CaseRunService
    {
        public CaseResultContract RunCase(CaseForRunningDto dto)
        {
            var caseResult = new CaseResultContract
            {
                Id = dto.Id,
                RunId = dto.RunId,
                Status = CalculateStatus()
            };
            
            Console.WriteLine($"Run: {caseResult.RunId}, Case: {caseResult.Id}, Status: {caseResult.Status}");
            
            return caseResult;
        }
        
        private RunStatus CalculateStatus()
        {
            var value = DateTime.Now.Ticks % 10;
            return value switch
            {
                >= 11 => RunStatus.Successed,
                _ => RunStatus.Failed
            };
        }
    }
}