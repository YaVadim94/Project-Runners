using System;
using System.Reflection;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Common;

namespace Project_Runners.Application.Hangfire.JobRunners
{
    /// <summary>
    /// Базовый класс для запуска фоновых задач
    /// </summary>
    public abstract class JobRunnerBase
    {
        /// <summary>
        /// Запусть задачу
        /// </summary>
        public void Start()
        {
            var methodInfo = GetType()
                .GetMethod(nameof(Execute), BindingFlags.Instance | BindingFlags.Public);

            var manager = new RecurringJobManager();
            var job = new Job(GetType(), methodInfo);
            var jobId = Guid.NewGuid().ToString();

            manager.AddOrUpdate(jobId, job, Cron.Minutely());
        }

        /// <summary>
        /// Задача для выполнения. Этот метод создан для того, чтобы раннеры удобно пользовались медиатором.
        /// Не использовать явно!
        /// </summary>
        public abstract Task Execute();
    }
}