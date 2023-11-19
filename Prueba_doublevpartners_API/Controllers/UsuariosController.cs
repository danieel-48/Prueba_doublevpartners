using Newtonsoft.Json;
using Prueba_doublevpartners_BLL.BusinessLogic.UsuarioBLL;
using Prueba_doublevpartners_ENL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prueba_doublevpartners_API.Controllers
{
    public class UsuariosController : ApiController
    {
        UsuarioBL usuarioBL;
        Usuarios usuarios;

        [HttpPost]
        [Route("api/getusuario")]
        public IHttpActionResult Get_Usuarios([FromBody] Usuarios users)
        {
            try
            {
                usuarios = new Usuarios();
                usuarioBL = new UsuarioBL();

                usuarios.Usuario = users.Usuario;
                usuarios.Pass = users.Pass;

                var consulta = usuarioBL.GetUsuario(usuarios);

                if(consulta != null)
                {
                    return Ok("El usuario existe");
                }
                else
                {
                    return Ok("El usuario no existe");   
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/addusuario")]
        public IHttpActionResult Add_Usuarios([FromBody] Usuarios users)
        {
            try
            {
                usuarios = new Usuarios();
                usuarioBL = new UsuarioBL();

                usuarios.Identificador = users.Identificador;
                usuarios.Usuario = users.Usuario;
                usuarios.Pass = users.Pass;
                usuarios.Fecha_de_creacion = users.Fecha_de_creacion;

                bool respuesta = usuarioBL.AddUsuario(usuarios);

                if(respuesta == true)
                {
                    return Ok("Usuario Registrado");
                }
                else
                {
                    return Ok("Ha ocurrido un error");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}