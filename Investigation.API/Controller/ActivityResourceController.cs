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
        public async Task<ActionResult<IEnumerable<ActivityResource>>> GetActivityResources()
        {
            return await _context.ActivityResources.ToListAsync();
        }

        // GET: api/ActivityResources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityResource>> GetActivityResource(int id)
        {
            var activityResource = await _context.ActivityResources.FindAsync(id);

            if (activityResource == null)
            {
                return NotFound();
            }

            return activityResource;
        }



        // DELETE: api/ActivityResources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityResource(int id)
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

        private bool ActivityResourceExists(int id)
        {
            return _context.ActivityResources.Any(e => e.Id == id);
        }
    }
}