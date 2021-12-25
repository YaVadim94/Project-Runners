using System.Collections.Generic;
using System.Threading.Tasks;
using Project_Runners.Frontend.Models;

namespace Project_Runners.Frontend.ViewServices
{
    /// <summary>
    /// Сервис для работы с раннерами
    /// </summary>
    public interface IRunnersService
    {
        Task<IEnumerable<Runner>> GetAll();
    }
}