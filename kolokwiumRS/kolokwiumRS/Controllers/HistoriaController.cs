using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace kolokwiumRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoriaController : ControllerBase
    {
        private readonly KolokwiumContext _context;

        public HistoriaController(KolokwiumContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historia>>> GetHistoria(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var historia = await _context.Historie
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(historia);
        }
    }
}
