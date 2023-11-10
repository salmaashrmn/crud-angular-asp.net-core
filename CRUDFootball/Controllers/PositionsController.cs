using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDFootball.Services;
using CRUDFootball.Models;

namespace CRUDFootball.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionsService _positionService;

        public PositionsController(IPositionsService positionService)
        {
            _positionService = positionService;
        }

        // GET: api/Positions
        [HttpGet]
        public async Task<IEnumerable<Positions>> Get()
        {
            return await _positionService.GetPositionsList();
        }
    }
}
