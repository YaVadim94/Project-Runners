using Project_runners.Common.Enums;
using Project_Runners.Data.Models.Base;

namespace Project_Runners.Data.Models
{
    /// <summary>
    /// Раннер
    /// </summary>
    public class Runner : EntityBase
    {
        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Состояние </summary>
        public RunnerState? State { get; set; }
    }
}