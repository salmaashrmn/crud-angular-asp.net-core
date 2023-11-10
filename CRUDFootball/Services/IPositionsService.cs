using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDFootball.Services
{
    public interface IPositionsService
    {
        Task<IEnumerable<Models.Positions>> GetPositionsList();
    }
}
