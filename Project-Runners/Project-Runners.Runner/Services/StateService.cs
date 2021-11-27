using Project_Runners.Runner.Models.Enums;

namespace Project_Runners.Runner.Services
{
    /// <summary>
    /// Сервис для работы с состоянием раннера
    /// </summary>
    public class StateService
    {
        private object _locker = new();
        private RunnerState _runnerState;
        
        /// <summary> Состояние </summary>
        public RunnerState RunnerState {
            get => _runnerState;
            set
            {
                lock (_locker)
                    _runnerState = value;
            }
        }
    }
}