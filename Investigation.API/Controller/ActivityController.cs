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
            var activities = await _context.Activities.Include(x => x.Projects).ToListAsync();

            var modelo = activities.Select(activity => new 
            { 
                
                activity.Id,
                activity.Descripcion,
                activity.FechaInicio,
                activity.FechaFinal,
                ProyectId = activity.Projects != null ? (int?)activity.Projects.Id : null,
                associatedProject = activity.Projects != null ? (string?)activity.Projects.Nombre : null,


            });

            return Ok(modelo);
        }

        [HttpPost]

        public async Task<ActionResult> Post(int ProjectID, Activity activity)
        {
            var project = await _context.Projects.FindAsync(ProjectID);
            if (project == null)
            {
                return NotFound("Proyecto no encontrado");
            }

            activity.Projects = project;
            _context.Add(activity);
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