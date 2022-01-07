using System.ComponentModel;

namespace ProjectRunners.Common.Enums
{
    /// <summary>
    /// Статус прохождения
    /// </summary>
    public enum RunStatus
    {
        [Description("Not started")]
        NotStarted,
        
        [Description("In progress")]
        InProgress,
        
        [Description("Succeeded")]
        Succeeded,
        
        [Description("Failed")]
        Failed
    }
}