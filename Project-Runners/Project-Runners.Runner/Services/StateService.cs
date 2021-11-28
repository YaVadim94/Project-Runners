using System;
using System.Text;
using Project_Runners.Runner.Models.Enums;

namespace Project_Runners.Runner.Services
{
    /// <summary>
    /// Сервис для работы с состоянием раннера
    /// </summary>
    public class StateService
    {
        private object _locker = new();

        /// <summary> Состояние раннера </summary>
        public RunnerState RunnerState { get; private set; }
        
        public StateService()
        {
            RunnerState = RunnerState.Waiting;
        }

        public void SetState(RunnerState state)
        {
            if(RunnerState == state)
                return;

            var stringBuilder = new StringBuilder($"Runner has changed state from \"{RunnerState}\"");
            
            RunnerState = state;
            
            stringBuilder.Append($" to \"{RunnerState}\"");
            
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}