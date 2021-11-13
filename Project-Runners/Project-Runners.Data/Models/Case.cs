using System.Collections;
using System.Collections.Generic;
using Project_Runners.Data.Models.Base;

namespace Project_Runners.Data.Models
{
    /// <summary>
    /// Случай (задача, которую необходимо выполнить)
    /// </summary>
    public class Case : EntityBase
    {
        /// <summary> Прогоны </summary>
        public ICollection<RunCase> Runs { get; set; }
    }
}