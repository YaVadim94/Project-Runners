﻿using System;

namespace ProjectRunners.Web.Models
{
    /// <summary>
    /// Дто кейса
    /// </summary>
    public class CaseContract
    {
        /// <summary> Идентификатор </summary>
        public long Id { get; set; }
        
        /// <summary> Наименование </summary>
        public string Name { get; set; }
    }
}