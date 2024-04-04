using Investigation.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigation.Shared.Entities;
using System.Threading.Tasks;
using System.Linq;


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


        //Método GET --- Select * From proyect
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var publications = await _context.Publications
                .Include(x => x.Proyects)
                .ToListAsync();

            var atributosPublication = publications.Select(publication => new
            {
                publication.Id,
                publication.Titulo,
                publication.Autor,
                publication.FechaPrublicacion,               
                ProjectId = publication.Proyects != null ? (int?)publication.Proyects.Id : null
            });

            return Ok(atributosPublication);
        }


        //Método POST- insertar en base de datos
        [HttpPost]

        public async Task<ActionResult> Post(int ProjectID, Publication publication)
        {
            var project = await _context.Proyects.FindAsync(ProjectID);
            if (project == null)
            {
                return NotFound("Proyecto no encontrado");
            }

            publication.Proyects = project;
            _context.Add(publication);
            await _context.SaveChangesAsync();
            return Ok(publication);
        }

        //GEt por párametro- select * from proyect where id=1
        //https://localhost:7000/api/proyect/id:int?id=1
        [HttpGet("id:int")]

        public async Task<ActionResult> Get(int id)
        {

            var publication = await _context.Publications.FirstOrDefaultAsync(x => x.Id == id);
            if (publication == null)
            {


                return NotFound();  //404
            }

            return Ok(publication);//200


        }



        //Método PUT- actualizar datos 
        [HttpPut]

        public async Task<ActionResult> Put(Publication publication)
        {

            _context.Update(publication);
            await _context.SaveChangesAsync();
            return Ok(publication);
        }

        //Delete - Eliminar registros

        [HttpDelete("id:int")]

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
