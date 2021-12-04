using System.Collections.Generic;
using ProjectRunners.Data.Models.Base;

namespace ProjectRunners.Data.Models
{
    /// <summary>
    /// Случай (задача, которую необходимо выполнить)
    /// </summary>
    public class Case : NamedEntityBase
    {
        /// <summary> Прогоны </summary>
        public ICollection<RunCase> Runs { get; set; }

        /// <summary> Результаты прогонов данного кейса </summary>
        public ICollection<CaseResult> CaseResults { get; set; }
    }
}