using System.Collections.Generic;
using ProjectRunners.Data.Models;

namespace ProjectRunners.Application.Runs.Models
{
    /// <summary>
    /// Тест кейс с результатами прогона
    /// </summary>
    public class CaseWithResults
    {
        /// <summary> Тест кейс </summary>
        public Case Case { get; set; }

        /// <summary> Результаты прогонов </summary>
        public IEnumerable<CaseResult> CaseResults { get; set; }
    }
}