﻿using Investigation.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Investigation.Shared.Entities;
using System.Threading.Tasks;
using System.Linq;

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


        //Método GET --- Select * From activity
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var activities = await _context.Activities
                .Include(x => x.Proyects)
                .ToListAsync();

            var atributosActivities = activities.Select(activity => new
            {
                activity.Id,
                activity.Nombre,
                activity.Descripcion,
                activity.FechaInicio,
                activity.FechaFinal,
                ProjectId = activity.Proyects != null ? (int?)activity.Proyects.Id : null
            });

            return Ok(atributosActivities);
        }


        //Método POST- insertar en base de datos
        [HttpPost]

        public async Task<ActionResult> Post(int ProjectID, Activity activity)
        {
            var project = await _context.Proyects.FindAsync(ProjectID);
            if (project == null)
            {
                return NotFound("Proyecto no encontrado");
            }

            activity.Proyects = project;
            _context.Add(activity);
            await _context.SaveChangesAsync();
            return Ok(activity);
        }

        //GEt por párametro- select * from activity where id=1
        //https://localhost:7000/api/proyect/id:int?id=1
        [HttpGet("id:int")]

        public async Task<ActionResult> Get(int id)
        {

            var activity = await _context.Activities.FirstOrDefaultAsync(x => x.Id == id);
            if (activity == null)
            {


                return NotFound();  //404
            }

            return Ok(activity);//200


        }



        //Método PUT- actualizar datos 
        [HttpPut]

        public async Task<ActionResult> Put(Activity activity)
        {

            _context.Update(activity);
            await _context.SaveChangesAsync();
            return Ok(activity);
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