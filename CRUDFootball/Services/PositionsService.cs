using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDFootball.Data;

namespace CRUDFootball.Services
{
    public class PositionsService : IPositionsService
    {
        private readonly FootballDbContext _context;

        public PositionsService(FootballDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Positions>> GetPositionsList()
        {
            return await _context.Positions
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
        }
    }
}
