using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDFootball.Services
{
    public interface IPlayersService
    {
        Task<IEnumerable<Models.Players>> GetPlayersList();
        Task<Models.Players> GetPlayerById(int id);
        Task<Models.Players> CreatePlayer(Models.Players player);
        Task UpdatePlayer(Models.Players player);
        Task DeletePlayer(Models.Players player);
    }
}
