using System.Collections;
using System.Collections.Generic;
using Project_Runners.Data.Models.Base;

namespace Project_Runners.Data.Models
{
    /// <summary>
    /// Прогон
    /// </summary>
    public class Run : EntityBase
    {
        /// <summary> Кейсы </summary>
        public ICollection<RunCase> Cases { get; set; }
    }
}