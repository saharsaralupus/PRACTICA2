using Investigation.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigation.Shared.Entities;
using System.Threading.Tasks;

namespace Investigation.API.Controllers
{
    [ApiController]
    [Route("/api/ActivityResources")]
    public class ActivityResourceController : ControllerBase
    {
        private readonly DataContext _context;

        public ActivityResourceController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ActivityResources
        [HttpGet]
        public async Task<ActionResult> GetActivityResources()
        {
            var activityResources = await _context.ActivityResources
                .Include(ar => ar.Activities)
                .Include(ar => ar.Resources)
                .ToListAsync();
            return Ok(activityResources);
        }

        // POST: api/ActivityResources
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
                ResourceId = resourceId,
                ActivityId = activityId
            };

            _context.ActivityResources.Add(idActivityResource);
            await _context.SaveChangesAsync();

            return Ok(idActivityResource);
        }

        // GET: api/ActivityResources/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetActivityResource(int id)
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

        // DELETE: api/ActivityResources/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivityResource(int id)
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