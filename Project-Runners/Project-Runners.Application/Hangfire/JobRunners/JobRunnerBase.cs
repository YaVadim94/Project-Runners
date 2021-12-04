using System;
using System.Reflection;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Common;
using ProjectRunners.Application.Hangfire.Attributes;

namespace ProjectRunners.Application.Hangfire.JobRunners
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
            var methodInfo = GetType().GetMethod(nameof(Execute), BindingFlags.Instance | BindingFlags.Public)
                             ?? throw new ArgumentException();
            
            var frequencyAttribute = Attribute.GetCustomAttribute(methodInfo, typeof(FrequencyAttribute))
                as FrequencyAttribute;

            var frequency = frequencyAttribute switch
            {
                null => Cron.Minutely(),
                _ => frequencyAttribute.Value
            };
                
            var manager = new RecurringJobManager();
            var job = new Job(GetType(), methodInfo);
            var jobId = Guid.NewGuid().ToString();

            manager.AddOrUpdate(jobId, job, frequency);
        }

        /// <summary>
        /// Задача для выполнения. Этот метод создан для того, чтобы раннеры удобно пользовались медиатором.
        /// Не использовать явно!
        /// </summary>
        public abstract Task Execute();
    }
}