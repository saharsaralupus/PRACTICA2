using Investigation.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigation.Shared.Entities;
using System.Threading.Tasks;
using System.Linq;


namespace Investigation.API.Controllers
{

    [ApiController]
    [Route("/api/Investigators")]
    public class InvestigatorController : ControllerBase
    {

        private readonly DataContext _context;

        public InvestigatorController(DataContext context)
        {
            _context = context;
        }


        //Método GET --- Select * From activity
        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.Investigators.ToListAsync());
        }


        //Método POST- insertar en base de datos
        [HttpPost]

        public async Task<ActionResult> Post(Investigator investigator)
        {

            _context.Add(investigator);
            await _context.SaveChangesAsync();
            return Ok(investigator);
        }

        //GEt por párametro- select * from activity where id=1
        //https://localhost:7000/api/proyect/id:int?id=1
        [HttpGet("id:int")]

        public async Task<ActionResult> Get(int id)
        {

            var investigator = await _context.Investigators.FirstOrDefaultAsync(x => x.Id == id);
            if (investigator == null)
            {


                return NotFound();  //404
            }

            return Ok(investigator);//200


        }



        //Método PUT- actualizar datos 
        [HttpPut]

        public async Task<ActionResult> Put(Investigator investigator)
        {

            _context.Update(investigator);
            await _context.SaveChangesAsync();
            return Ok(investigator);
        }

        //Delete - Eliminar registros

        [HttpDelete("id:int")]

        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.Investigators
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