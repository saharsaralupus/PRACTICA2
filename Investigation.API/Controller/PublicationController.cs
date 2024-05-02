using Investigation.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigation.Shared.Entities;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;


namespace Investigation.API.Controllers
{

    [ApiController]
    [Route("/api/Publications")]
    public class PublicationController : ControllerBase
    {

        private readonly DataContext _context;

        public PublicationController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Publications.ToListAsync());
        }


        [HttpPost]

        public async Task<ActionResult> Post(Publication publication)
        {
            _context.Publications.Add(publication);
            await _context.SaveChangesAsync();
            return Ok(publication);
        }


        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)
        {

            var publication = await _context.Publications.FirstOrDefaultAsync(x => x.Id == id);
            if (publication == null)
            {


                return NotFound();  //404
            }

            return Ok(publication);//200


        }


        [HttpPut]
        public async Task<ActionResult> Put(Publication publication)
        {
            _context.Update(publication);
            await _context.SaveChangesAsync();
            return Ok(publication);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.Publications
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
