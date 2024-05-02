using Investigation.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigation.Shared.Entities;
using System.Threading.Tasks;

namespace Investigation.API.Controllers
{
    [ApiController]
    [Route("/api/ActivitiesResources")]
    public class ActivityResourceController : ControllerBase
    {
        private readonly DataContext _context;

        public ActivityResourceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var activityResources = await _context.ActivityResources
                .Include(ar => ar.Activities)
                .Include(ar => ar.Resources)
                .ToListAsync();
            return Ok(activityResources);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActivityResource activitiesResource)
        {
            _context.ActivityResources.Add(activitiesResource);
            await _context.SaveChangesAsync();
            return Ok(activitiesResource);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ActivityResource activityResource)
        {

            _context.Update(activityResource);
            await _context.SaveChangesAsync();
            return Ok(activityResource);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActivityResource>> Get(int id)
        {
            var activityResource = await _context.ActivityResources.FindAsync(id);

            if (activityResource == null)
            {
                return NotFound();
            }

            return activityResource;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var activityResource = await _context.ActivityResources.FindAsync(id);
            if (activityResource == null)
            {
                return NotFound();
            }

            _context.ActivityResources.Remove(activityResource);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}