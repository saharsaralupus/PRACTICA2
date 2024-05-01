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
    [Route("/api/InvestigatorsProjects")]
    public class InvestigatorProjectController : ControllerBase
    {
        private readonly DataContext _context;

        public InvestigatorProjectController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var atributosInvestigatorProyects = await _context.InvestigatorProyects
                .Include(x => x.Investigators)
                .Include(x => x.Projects)
                .ToListAsync();

            return Ok(atributosInvestigatorProyects);
        }

        [HttpPost]
        public async Task<ActionResult> Post(int projectId, int investigatorId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            var investigator = await _context.Investigators.FindAsync(investigatorId);

            if (project == null)
            {
                return NotFound("Proyecto no encontrado");
            }
            if (investigator == null)
            {
                return NotFound("Investigador no encontrado");
            }

            var idInvestigatorProyect = new InvestigatorProject
            {
                Projects = project,
                Investigators = investigator
            };

            _context.InvestigatorProyects.Add(idInvestigatorProyect);
            await _context.SaveChangesAsync();

            return Ok(idInvestigatorProyect);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InvestigatorProject>> GetInvestigatorProyect(int id)
        {
            var investigatorProyect = await _context.InvestigatorProyects.FindAsync(id);

            if (investigatorProyect == null)
            {
                return NotFound();
            }

            return investigatorProyect;
        }


        [HttpDelete("{id:int}")]
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
    }
}
