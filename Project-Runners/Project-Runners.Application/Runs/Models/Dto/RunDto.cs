﻿using System;
using System.Collections.Generic;
using ProjectRunners.Common.Enums;

namespace ProjectRunners.Application.Runs.Models.Dto
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

        /// <summary> Статус </summary>
        public RunStatus Status { get; set; }

        /// <summary> Кейсы прогона </summary>
        public IEnumerable<CaseDto> Cases { get; set; }
    }
}