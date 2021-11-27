namespace Project_Runners.Runner.Services
{
    /// <summary>
    /// Сервис для работы с состоянием раннера
    /// </summary>
    public class StateService
    {
        private object _locker = new();
        
        /// <summary> Состояние </summary>
        public bool State { get; set; }

        /// <summary>
        /// Выставить состояние
        /// </summary>
        public void SetState(bool state)
        {
            lock (_locker)
                State = state;
        }
    }
}