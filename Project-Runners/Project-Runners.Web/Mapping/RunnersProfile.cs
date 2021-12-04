﻿using AutoMapper;
using ProjectRunners.Application.Runners.Models.Commands;
using ProjectRunners.Application.Runners.Models.Dto;
using ProjectRunners.Web.Models;

namespace ProjectRunners.Web.Mapping
{
    /// <summary>
    /// Профиль маппинга раннеров
    /// </summary>
    public class RunnersProfile : Profile
    {
        public RunnersProfile()
        {
            CreateMap<RunnerStateContract, SetStateCommand>();
            CreateMap<RunnerDto, RunnerContract>();
        }
    }
}