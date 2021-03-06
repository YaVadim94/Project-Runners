using System.Collections.Generic;
using ProjectRunners.Data.Models.Bases;

namespace ProjectRunners.Data.Models
{
    /// <summary>
    /// Случай (задача, которую необходимо выполнить)
    /// </summary>
    public class Case : NamedEntityBase
    {
        /// <summary> Описание </summary>
        public string Description { get; set; }
        
        /// <summary> Прогоны </summary>
        public ICollection<RunCase> Runs { get; set; }

        /// <summary> Результаты прогонов данного кейса </summary>
        public ICollection<CaseResult> CaseResults { get; set; }
    }
}