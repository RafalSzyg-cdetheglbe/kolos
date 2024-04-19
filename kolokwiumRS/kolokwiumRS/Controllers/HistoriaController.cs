using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        [Route("api/historia/bezskladowania")]
        public async Task<ActionResult<IEnumerable<Historia>>> GetHistoriaAleTakaBezSkladowania(
      [FromQuery] int pageNumber = 1,
      [FromQuery] int pageSize = 10)
        {
            var historia = await _context.Historie
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(historia);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historia>>> GetPaginatedHistoria(
     [FromQuery] int pageNumber = 1,
     [FromQuery] int pageSize = 10)
        {
            var offset = (pageNumber - 1) * pageSize;
            var pageSizeParam = new SqlParameter("@PageSize", pageSize);
            var pageNumberParam = new SqlParameter("@PageNumber", pageNumber);

            var historia = await _context.Historie.FromSqlRaw("EXEC PaginatedGetHistoria4 @PageNumber, @PageSize", pageNumberParam, pageSizeParam).ToListAsync();

            return historia;
        }

    }
}
