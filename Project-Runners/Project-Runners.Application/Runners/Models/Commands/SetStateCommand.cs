﻿using MediatR;
using Project_runners.Common.Enums;

namespace Project_Runners.Application.Runners.Models.Commands
{
    /// <summary>
    /// Команда на проставление состояния раннера
    /// </summary>
    public class SetStateCommand : IRequest
    {
        /// <summary> Идентификатор раннера </summary>
        public long RunnerId { get; set; }
        
        /// <summary> Состояние раннера </summary>
        public RunnerState State { get; set; }
    }
}