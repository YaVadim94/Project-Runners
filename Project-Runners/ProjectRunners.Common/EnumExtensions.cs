using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ProjectRunners.Common
{
    /// <summary>
    /// Расришения для енамов
    /// </summary>
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var descriptionAttribute = value.GetType().GetMember(value.ToString()).FirstOrDefault()?
                .GetCustomAttribute<DescriptionAttribute>();
            
            return descriptionAttribute?.Description ?? string.Empty;
        }
    }
}