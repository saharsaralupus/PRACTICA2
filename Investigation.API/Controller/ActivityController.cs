using Investigation.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigation.Shared.Entities;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Investigation.API.Controllers
{

    [ApiController]
    [Route("/api/Activities")]
    public class ActivityController : ControllerBase
    {

        private readonly DataContext _context;

        public ActivityController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Activities.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Activity activity)
        {
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
            return Ok(activity);
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)
        {

            var activity = await _context.Activities.FirstOrDefaultAsync(x => x.Id == id);
            if (activity == null)
            {


                return NotFound();  //404
            }

            return Ok(activity);//200


        }

        [HttpPut]

        public async Task<ActionResult> Put(Activity activity)
        {

            _context.Update(activity);
            await _context.SaveChangesAsync();
            return Ok(activity);
        }


        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.Activities
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