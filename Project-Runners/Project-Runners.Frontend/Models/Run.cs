﻿using System.Collections.Generic;

namespace Project_Runners.Frontend.Models
{
    /// <summary>
    /// Прогон
    /// </summary>
    public class Run
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }

        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Тeсты </summary>
        public ICollection<TestCase> TestCases { get; set; }
    }
}