using Investigation.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigation.Shared.Entities;
using System.Threading.Tasks;
using System.Linq;


namespace Investigation.API.Controllers
{

    [ApiController]
    [Route("/api/Investigators")]
    public class InvestigatorController : ControllerBase
    {

        private readonly DataContext _context;

        public InvestigatorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.Investigators.ToListAsync());
        }

        [HttpPost]

        public async Task<ActionResult> Post(Investigator investigator)
        {

            _context.Add(investigator);
            await _context.SaveChangesAsync();
            return Ok(investigator);
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)
        {

            var investigator = await _context.Investigators.FirstOrDefaultAsync(x => x.Id == id);
            if (investigator == null)
            {


                return NotFound();  //404
            }

            return Ok(investigator);//200


        }

        [HttpPut]

        public async Task<ActionResult> Put(Investigator investigator)
        {

            _context.Update(investigator);
            await _context.SaveChangesAsync();
            return Ok(investigator);
        }


        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.Investigators
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