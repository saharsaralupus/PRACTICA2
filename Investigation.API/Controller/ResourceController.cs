using Investigation.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigation.Shared.Entities;
using System.Threading.Tasks;
using System.Linq;
using System.Resources;


namespace Investigation.API.Controllers
{

    [ApiController]
    [Route("/api/Resources")]
    public class ResourceController : ControllerBase
    {

        private readonly DataContext _context;

        public ResourceController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Resources.ToListAsync());
        }


        [HttpPost]

        public async Task<ActionResult> Post(Resource resource)
        {
            _context.Add(resource);
            await _context.SaveChangesAsync();
            return Ok(resource);
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)
        {

            var resource = await _context.Resources.FirstOrDefaultAsync(x => x.Id == id);
            if (resource == null)
            {


                return NotFound();  //404
            }

            return Ok(resource);//200


        }


        [HttpPut]

        public async Task<ActionResult> Put(Resource resource)
        {

            _context.Update(resource);
            await _context.SaveChangesAsync();
            return Ok(resource);
        }


        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.Resources
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