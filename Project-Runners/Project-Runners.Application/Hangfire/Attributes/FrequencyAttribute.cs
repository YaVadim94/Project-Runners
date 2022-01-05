using System;

namespace ProjectRunners.Application.Hangfire.Attributes
{
    /// <summary>
    /// Аттрибут, указывающий на частоту выполнения задачи
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class FrequencyAttribute : Attribute
    {
        public FrequencyAttribute(string value)
        {
            Value = value;
        }

        /// <summary> Значение Cron </summary>
        public string Value { get; }
    }
}