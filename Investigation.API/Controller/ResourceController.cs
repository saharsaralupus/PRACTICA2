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


        //Método GET --- Select * From activity
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var resources = await _context.Resources
                .Include(x => x.Proyects)
                .ToListAsync();

            var atributosResource = resources.Select(resource => new
            {
                resource.Id,
                resource.Nombre,
                resource.Proveedor,
                resource.CantidadRequerida,
                resource.FechaEntregaEstimada,
                ProjectId = resource.Proyects != null ? (int?)resource.Proyects.Id : null
            });

            return Ok(atributosResource);
        }


        //Método POST- insertar en base de datos
        [HttpPost]

        public async Task<ActionResult> Post(int ProjectID, Resource resource)
        {
            var project = await _context.Proyects.FindAsync(ProjectID);
            if (project == null)
            {
                return NotFound("Proyecto no encontrado");
            }

            resource.Proyects = project;
            _context.Add(resource);
            await _context.SaveChangesAsync();
            return Ok(resource);
        }

        //GEt por párametro- select * from activity where id=1
        //https://localhost:7000/api/proyect/id:int?id=1
        [HttpGet("id:int")]

        public async Task<ActionResult> Get(int id)
        {

            var resource = await _context.Activities.FirstOrDefaultAsync(x => x.Id == id);
            if (resource == null)
            {


                return NotFound();  //404
            }

            return Ok(resource);//200


        }



        //Método PUT- actualizar datos 
        [HttpPut]

        public async Task<ActionResult> Put(Resource resource)
        {

            _context.Update(resource);
            await _context.SaveChangesAsync();
            return Ok(resource);
        }

        //Delete - Eliminar registros

        [HttpDelete("id:int")]

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