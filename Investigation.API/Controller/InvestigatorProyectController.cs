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
        public async Task<ActionResult<IEnumerable<InvestigatorProyect>>> Get()
        {
            // Incluye los datos del investigador y del proyecto en la consulta
            var atributosInvestigatorProyects = await _context.InvestigatorProyects
                .Include(x => x.Investigators)
                .Include(x => x.Proyects)
                .ToListAsync();

            return Ok(atributosInvestigatorProyects);
        }

        [HttpPost]
        public async Task<ActionResult> Post(int projectId, int investigatorId)
        {
            // Verifica si el proyecto y el investigador existen
            var project = await _context.Proyects.FindAsync(projectId);
            var investigator = await _context.Investigators.FindAsync(investigatorId);

            if (project == null)
            {
                return NotFound("Proyecto no encontrado");
            }
            if (investigator == null)
            {
                return NotFound("Investigador no encontrado");
            }

            // Crea una nueva instancia de InvestigatorProyect con las llaves foráneas proporcionadas
            var idInvestigatorProyect = new InvestigatorProyect
            {
                ProyectId = projectId,
                InvestigatorId = investigatorId
            };

            // Agrega la nueva instancia a la base de datos
            _context.InvestigatorProyects.Add(idInvestigatorProyect);
            await _context.SaveChangesAsync();

            return Ok(idInvestigatorProyect);
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
