﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Common;
using Hangfire.Storage;
using MediatR;
using Project_Runners.Application.Runs.Models.Commands;
using Cron = Hangfire.Cron;
using RecurringJob = Hangfire.RecurringJob;

namespace Project_Runners.Application.Hangfire.JobRunners
{
    /// <summary>
    /// Класс, отвечающий за запуск задачи на создание прогона
    /// </summary>
    public class RunCreateJobRunner : IRunCreateJobRunner
    {
        private readonly IMediator _mediator;

        public RunCreateJobRunner(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Запусть задачу
        /// </summary>
        public void Start()
        {
            //TODO: написать обёртку на раннеры, которые будут разруливать добавление новой джобы, если такая уже крутится
            
            var methodInfo = GetType()
                .GetMethod(nameof(Execute), BindingFlags.Instance | BindingFlags.Public);

            var manager = new RecurringJobManager();
            var job = new Job(GetType(), methodInfo);
            var jobId = Guid.NewGuid().ToString();

            manager.AddOrUpdate(jobId, job, Cron.Minutely());
        }

        public async Task Execute()
        {
            var command = new StartRunCommand();

            await _mediator.Send(command);
        }
    }
}