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
        public async Task<ActionResult> Post(InvestigatorProject investigatorProject)
        {
            _context.InvestigatorProyects.Add(investigatorProject);
            await _context.SaveChangesAsync();
            return Ok(investigatorProject);
        }

        [HttpPut]
        public async Task<ActionResult> Put(InvestigatorProject investigatorProject)
        {

            _context.Update(investigatorProject);
            await _context.SaveChangesAsync();
            return Ok(investigatorProject);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InvestigatorProject>> Get(int id)
        {
            var investigatorProyect = await _context.InvestigatorProyects.FindAsync(id);

            if (investigatorProyect == null)
            {
                return NotFound();
            }

            return investigatorProyect;
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.InvestigatorProyects
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (filasafectadas == 0)
            {


                return NotFound();  //404
            }

            return NoContent();//204


        }
    }
}
