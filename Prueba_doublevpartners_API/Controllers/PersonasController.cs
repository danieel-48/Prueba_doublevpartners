using Prueba_doublevpartners_BLL.BusinessLogic.PersonasBLL;
using Prueba_doublevpartners_ENL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prueba_doublevpartners_API.Controllers
{
    public class PersonasController : ApiController
    {
        Personas personas;
        PersonasBL personasBL;

        [HttpPost]
        [Route("api/addpersonas")]

        public IHttpActionResult AddPersonas([FromBody] Personas item)
        {
            try
            {
                personas = new Personas();
                personasBL = new PersonasBL();

                personas.Identificador = item.Identificador;
                personas.Nombres = item.Nombres;
                personas.Apellidos = item.Apellidos;
                personas.Numero_de_identificacion = item.Numero_de_identificacion;
                personas.Email = item.Email;
                personas.Tipo_identificacion = item.Tipo_identificacion;
                personas.Fecha_de_creación = item.Fecha_de_creación;

                bool respuesa = personasBL.AddPersonas(personas);

                if (respuesa == true)
                {
                    return Ok("Persona Registrada");
                }
                else
                {
                    return Ok("Ha ocurtido un error");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}