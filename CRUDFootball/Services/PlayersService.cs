using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDFootball.Data;
using CRUDFootball.Models;

namespace CRUDFootball.Services
{
    public class PlayersService : Services.IPlayersService
    {
        private readonly FootballDbContext _context;

        public PlayersService(FootballDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Players>> GetPlayersList()
        {
            return await _context.Players
                .Include(x => x.Position)
                .ToListAsync();
        }

        public async Task<Models.Players> GetPlayerById(int id)
        {
            return await _context.Players
                .Include(x => x.Position)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.Players> CreatePlayer(Models.Players player)
        {
            var lastPlayer = _context.Players.OrderByDescending(p => p.Id).FirstOrDefault();

            // Menghitung ID baru
            int newID = (lastPlayer != null) ? lastPlayer.Id + 1 : 1;

            var newPlayer = new Players
            {
                Id = newID,
                ShirtNo = player.ShirtNo,
                Name = player.Name,
                PositionId = player.PositionId,
                Appearances = player.Appearances,
                Goals = player.Goals,
                Position = player.Position,
                // Isi properti-properti lain sesuai data player
                // ...
            };

            _context.Players.Add(newPlayer);
            await _context.SaveChangesAsync();
            return player;
        }
        public async Task UpdatePlayer(Models.Players player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlayer(Models.Players player)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
    }
}
