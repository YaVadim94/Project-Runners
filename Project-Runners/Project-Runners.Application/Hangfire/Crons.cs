namespace ProjectRunners.Application.Hangfire
{
    /// <summary>
    /// Класс дял констант, олицетворяющих кроны
    /// </summary>
    public static class Crons
    {
        public const string EveryMinute = "* * * * *";
        public const string EveryFifteenSec = "*/10 * * * * *";
    }
}