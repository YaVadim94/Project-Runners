using System.Collections.Generic;
using MediatR;
using Project_Runners.Application.Runs.Models.Dto;

namespace Project_Runners.Application.Runs.Models.Commands
{
    /// <summary>
    /// Комманда для создания прогона
    /// </summary>
    public class CreateRunCommand : IRequest<long>
    {
        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Кейсы, которые должны войти в прогон </summary>
        public IEnumerable<long> CaseIds { get; set; }
    }
}