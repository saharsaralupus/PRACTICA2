using Investigation.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigation.Shared.Entities;


namespace Investigation.API.Controllers
{

    [ApiController]
    [Route("/api/Proyects")]
    public class ProyectController : ControllerBase
    {

        private readonly DataContext _context;

        public ProyectController(DataContext context)
        {
            _context = context;
        }


        //Método GET --- Select * From proyect
        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.Proyects.ToListAsync());
        }


        //Método POST- insertar en base de datos
        [HttpPost]

        public async Task<ActionResult> Post(Proyect proyect)
        {

            _context.Add(proyect);
            await _context.SaveChangesAsync();
            return Ok(proyect);
        }

        //GEt por párametro- select * from proyect where id=1
        //https://localhost:7000/api/proyect/id:int?id=1
        [HttpGet("id:int")]

        public async Task<ActionResult> Get(int id)
        {

            var proyect = await _context.Proyects.FirstOrDefaultAsync(x => x.Id == id);
            if (proyect == null)
            {


                return NotFound();  //404
            }

            return Ok(proyect);//200


        }



        //Método PUT- actualizar datos 
        [HttpPut]

        public async Task<ActionResult> Put(Proyect proyect)
        {

            _context.Update(proyect);
            await _context.SaveChangesAsync();
            return Ok(proyect);
        }

        //Delete - Eliminar registros

        [HttpDelete("id:int")]

        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.Proyects
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