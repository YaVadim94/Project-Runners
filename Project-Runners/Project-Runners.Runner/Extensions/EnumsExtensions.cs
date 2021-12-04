using System;
using System.Linq;
using ProjectRunners.Common.Enums;
using ProjectRunners.Protos;
using ProjectRunners.Runner.Services;

namespace ProjectRunners.Runner.Extensions
{
    /// <summary>
    /// Методы расширений для <see cref="Enum"/>
    /// </summary>
    public static class EnumsExtensions
    {
        public static RunnerStateGrpc MapToGrpc(this RunnerState state)
        {
            return state switch
            {
                RunnerState.Disconnected => RunnerStateGrpc.Disconnected,
                RunnerState.Running => RunnerStateGrpc.Running,
                RunnerState.Waiting => RunnerStateGrpc.Waiting,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }

        public static TOut MapToGrpc<TIn, TOut>(this TIn valueIn)
            where TIn : Enum 
            where TOut : Enum
        {
            var outNames = Enum.GetNames(typeof(TOut));
            
            if (outNames.Contains(valueIn.ToString()))
                return (TOut)Enum.Parse(typeof(TOut), valueIn.ToString());

            throw new ArgumentOutOfRangeException(nameof(valueIn), $"Could not parse enum value {valueIn} to Grpc analog");
        }
    }
}