using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Project_Runners.Web.Models
{
    /// <summary>
    /// Дто прогона
    /// </summary>
    public class RunDto
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }

        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Кейсы прогона </summary>
        public IEnumerable<CaseDto> Cases { get; set; }
    }
}