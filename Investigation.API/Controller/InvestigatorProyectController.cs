using Investigation.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigation.Shared.Entities;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Investigation.API.Controllers
{
    [ApiController]
    [Route("/api/InvestigatorProyect")]
    public class InvestigatorProyectController : ControllerBase
    {
        private readonly DataContext _context;

        public InvestigatorProyectController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ActivityResources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvestigatorProyect>>> GetInvestigatorProyect()
        {
            return await _context.InvestigatorProyects.ToListAsync();
        }

        // GET: api/ActivityResources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvestigatorProyect>> GetInvestigatorProyect(int id)
        {
            var investigatorProyect = await _context.InvestigatorProyects.FindAsync(id);

            if (investigatorProyect == null)
            {
                return NotFound();
            }

            return investigatorProyect;
        }



        // DELETE: api/ActivityResources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityResource(int id)
        {
            var investigatorProyect = await _context.InvestigatorProyects.FindAsync(id);
            if (investigatorProyect == null)
            {
                return NotFound();
            }

            _context.InvestigatorProyects.Remove(investigatorProyect);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvestigatorProyectExists(int id)
        {
            return _context.InvestigatorProyects.Any(e => e.Id == id);
        }
    }
}
