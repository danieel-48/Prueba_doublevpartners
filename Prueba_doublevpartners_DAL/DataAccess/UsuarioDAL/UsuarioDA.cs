using Prueba_doublevpartners_ENL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Prueba_doublevpartners_DAL.DataAccess.UsuarioDAL
{
    public class UsuarioDA
    {
        PersonasEntities context;

        string logfilepath_Nom_String = HttpContext.Current.Server.MapPath("~/ErrorLog/" + "error" + ".txt");

        /// <summary>
        /// GetUsuario_bd
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public Usuarios GetUsuario(Usuarios users)
        {
            try
            {
                context = new PersonasEntities();
                context.Database.CommandTimeout = 2000;

                var consulta = (from db in context.Usuarios
                                where db.Usuario == users.Usuario && db.Pass == users.Pass
                                select db).FirstOrDefault();

                return consulta;
            }
            catch (Exception ex)
            {
                string errorMessage = "Error DAL: " + ex.Message;
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string errorLog = $"Error generado el {currentTime}:{Environment.NewLine}{errorMessage}{Environment.NewLine}{Environment.NewLine}";

                using (var escribir = File.AppendText(logfilepath_Nom_String))
                {
                    escribir.Write(errorLog);
                }

                return null;
            }
        }

        /// <summary>
        /// AddUsuarios_bd
        /// </summary>
        /// <param name="usuarios"></param>
        /// <returns></returns>
        public bool AddUsuarios(Usuarios usuarios)
        {
            try
            {
                context = new PersonasEntities();

                context.Usuarios.Add(usuarios);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string errorMessage = "Error DAL: " + ex.Message;
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string errorLog = $"Error generado el {currentTime}:{Environment.NewLine}{errorMessage}{Environment.NewLine}{Environment.NewLine}";

                using (var escribir = File.AppendText(logfilepath_Nom_String))
                {
                    escribir.Write(errorLog);
                }
                return false;
            }  
        }
    }
}
