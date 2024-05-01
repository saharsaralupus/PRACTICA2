using Investigation.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigation.Shared.Entities;
using System.Threading.Tasks;
using System.Linq;


namespace Investigation.API.Controllers
{

    [ApiController]
    [Route("/api/Projects")]
    public class ProjectController : ControllerBase
    {

        private readonly DataContext _context;

        public ProjectController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.Projects.ToListAsync());
        }


        [HttpPost]

        public async Task<ActionResult> Post(Project proyect)
        {

            _context.Add(proyect);
            await _context.SaveChangesAsync();
            return Ok(proyect);
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)
        {

            var proyect = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (proyect == null)
            {


                return NotFound();  //404
            }

            return Ok(proyect);//200


        }


        [HttpPut]

        public async Task<ActionResult> Put(Project proyect)
        {

            _context.Update(proyect);
            await _context.SaveChangesAsync();
            return Ok(proyect);
        }


        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.Projects
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