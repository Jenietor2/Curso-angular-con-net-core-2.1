 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using ControlSoftV1._3.Clases;
using ControlSoftV1._3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControlSoftV1._3.Controllers
{
    // [ApiController]
    [Route("Api/[Controller]")]
    [ApiController]
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Listadopersonas")]
        //[Route("api/persona/Listadopersonas")]
        public IEnumerable<PersonaCLS> Listadopersonas()
        {
            using (BDRestauranteContext contex = new BDRestauranteContext())
            {
                List<PersonaCLS> listPersonas = (from persona in contex.Persona
                                                where persona.Bhabilitado == 1
                                                select new PersonaCLS { 
                                                IdPersona = persona.Iidpersona,
                                                NombreCompleto = persona.Nombre + " " + persona.Apmaterno + " " + persona.Apmaterno,
                                                FechaNacimiento = Convert.ToDateTime(persona.Fechanacimiento),
                                                Correo = persona.Correo,
                                                Telefono = persona.Telefono
                                                }).ToList();
                return listPersonas;
            }
        }

        [HttpGet("FiltradoPersona/{nombre?}")]
        //[Route("api/persona/FiltradoPersona/{nombre?}")]
        public IEnumerable<PersonaCLS> FiltradoPersona(string nombre = "")
        {
            using (BDRestauranteContext contex = new BDRestauranteContext())
            {
                if(string.IsNullOrEmpty(nombre))
                {
                    List<PersonaCLS> listPersonas = (from persona in contex.Persona
                                                     where persona.Bhabilitado == 1
                                                     select new PersonaCLS
                                                     {
                                                         IdPersona = persona.Iidpersona,
                                                         NombreCompleto = persona.Nombre + " " + persona.Apmaterno + " " + persona.Apmaterno,
                                                         FechaNacimiento = Convert.ToDateTime(persona.Fechanacimiento),
                                                         Correo = persona.Correo,
                                                         Telefono = persona.Telefono
                                                     }).ToList();
                    return listPersonas;
                }
                else
                {
                    List<PersonaCLS> listPersonas = (from persona in contex.Persona
                                                     where persona.Bhabilitado == 1
                                                     && (persona.Nombre + " " + persona.Apmaterno + " " + persona.Apmaterno).ToLower().Contains(nombre.ToLower())
                                                     select new PersonaCLS
                                                     {
                                                         IdPersona = persona.Iidpersona,
                                                         NombreCompleto = persona.Nombre + " " + persona.Apmaterno + " " + persona.Apmaterno,
                                                         FechaNacimiento = Convert.ToDateTime(persona.Fechanacimiento),
                                                         Correo = persona.Correo,
                                                         Telefono = persona.Telefono
                                                     }).ToList();
                    return listPersonas;
                }
                
            }
        }

        [HttpPost("GuardarPersona")]
        //[Route("api/[controller]/GuardarPersona")]
        public ActionResult GuardarPersona([FromBody] XElement model)
        {
            try
            {
                using (BDRestauranteContext context = new BDRestauranteContext())
                {
                    Persona personaAdd = new Persona();
                    //personaAdd.Nombre = persona.Nombre;
                    //personaAdd.Appaterno = persona.PrimerApellido;
                    //personaAdd.Apmaterno = persona.SegundoApellido;
                    //personaAdd.Telefono = persona.Telefono;
                    //personaAdd.Correo = persona.Correo;
                    //personaAdd.Bhabilitado= 1;
                    //personaAdd.Btieneusuario = 0;
                    context.Persona.Add(personaAdd);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return BadRequest("A ocurrido un error inesperadp");
            }
            return Ok();
        }
    }
}