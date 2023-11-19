using Prueba_doublevpartners_DAL.DataAccess.UsuarioDAL;
using Prueba_doublevpartners_ENL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Prueba_doublevpartners_BLL.BusinessLogic.UsuarioBLL
{
    
    public class UsuarioBL
    {
      
        UsuarioDA usuarioDA;

        string logfilepath_Nom_String = HttpContext.Current.Server.MapPath("~/ErrorLog/" + "error" + ".txt");

        /// <summary>
        /// GetUsuario
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public Usuarios GetUsuario(Usuarios users)
        {
            try
            {
                usuarioDA = new UsuarioDA();
                var consulta = usuarioDA.GetUsuario(users);

                return consulta;
            }
            catch (Exception ex)
            {
                string errorMessage = "Error BLL: " + ex.Message;
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
        /// AddUsuario
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool AddUsuario(Usuarios users)
        {
            try
            {
                usuarioDA = new UsuarioDA();
                bool resuesta = usuarioDA.AddUsuarios(users);

                return resuesta;
            }
            catch (Exception ex)
            {
                string errorMessage = "Error BLL: " + ex.Message;
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
