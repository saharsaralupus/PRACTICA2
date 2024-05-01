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
        public async Task<ActionResult> Post(int resourceId, int activityId)
        {
            var resource = await _context.Resources.FindAsync(resourceId);
            var activity = await _context.Activities.FindAsync(activityId);

            if (resource == null)
            {
                return NotFound("Recurso no encontrado");
            }
            if (activity == null)
            {
                return NotFound("Actividad no encontrado");
            }

            var idActivityResource = new ActivityResource
            {
                Activities = activity,
                Resources = resource
            };

            _context.ActivityResources.Add(idActivityResource);
            await _context.SaveChangesAsync();

            return Ok(idActivityResource);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var activityResource = await _context.ActivityResources
                .Include(ar => ar.Activities)
                .Include(ar => ar.Resources)
                .FirstOrDefaultAsync(ar => ar.Id == id);

            if (activityResource == null)
            {
                return NotFound();
            }

            return Ok(activityResource);
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