using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRunners.Web.Models
{
    /// <summary>
    /// Контракт дял создание прогона
    /// </summary>
    public class CreateRunContract
    {
        /// <summary> Наименование </summary>
        [Required]
        public string Name { get; set; }

        /// <summary> Идентификаторы кейсов </summary>
        [Required]
        public IEnumerable<long> CaseIds { get; set; }
    }
}