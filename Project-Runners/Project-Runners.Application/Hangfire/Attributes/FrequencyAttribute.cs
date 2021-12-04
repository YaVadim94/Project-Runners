using System;

namespace ProjectRunners.Application.Hangfire.Attributes
{
    /// <summary>
    /// Аттрибут, указывающий на частоту выполнения задачи
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class FrequencyAttribute : Attribute
    {
        /// <summary> Значение Cron </summary>
        public string Value { get; }
        
        public FrequencyAttribute(string value)
        {
            Value = value;
        }
    }
}