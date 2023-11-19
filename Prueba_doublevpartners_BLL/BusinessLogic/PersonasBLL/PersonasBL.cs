using Prueba_doublevpartners_DAL.DataAccess.PersonasDAL;
using Prueba_doublevpartners_ENL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Prueba_doublevpartners_BLL.BusinessLogic.PersonasBLL
{
    public class PersonasBL
    {
        PersonasDA personasDA;

        string logfilepath_Nom_String = HttpContext.Current.Server.MapPath("~/ErrorLog/" + "error" + ".txt");

        /// <summary>
        /// AddPersonas
        /// </summary>
        /// <param name="personas"></param>
        /// <returns></returns>
        public bool AddPersonas(Personas personas)
        {
            try
            {
               personasDA = new PersonasDA();
               bool respuesta = personasDA.AddPersonas(personas);

                return respuesta;

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
