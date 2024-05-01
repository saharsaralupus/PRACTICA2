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
            var publications = await _context.Publications
                .Include(x => x.Projects)
                .ToListAsync();

            var atributosPublication = publications.Select(publication => new
            {
                publication.Id,
                publication.Titulo,
                publication.Autor,
                publication.FechaPublicacion,               
                ProjectId = publication.Projects != null ? (int?)publication.Projects.Id : null,
                associatedProject = publication.Projects != null ? (string?)publication.Projects.Nombre : null,
            });
            return Ok(atributosPublication);
        }


        [HttpPost]

        public async Task<ActionResult> Post(int ProjectID, Publication publication)
        {
            var project = await _context.Projects.FindAsync(ProjectID);
            if (project == null)
            {
                return NotFound("Proyecto no encontrado");
            }

            publication.Projects = project;
            _context.Add(publication);
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
