namespace Project_Runners.Application.Hangfire.JobRunners
{
    /// <summary>
    /// Класс, отвечающий за запуск задачи на создание прогона
    /// </summary>
    public interface IRunCreateJobRunner
    {
        /// <summary>
        /// Запусть задачу
        /// </summary>
        void Start();
    }
}