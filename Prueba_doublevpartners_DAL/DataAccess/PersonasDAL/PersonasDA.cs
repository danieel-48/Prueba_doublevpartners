using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Prueba_doublevpartners_ENL.EntityDataModel;

namespace Prueba_doublevpartners_DAL.DataAccess.PersonasDAL
{
    public class PersonasDA
    {
        PersonasEntities context;

        string logfilepath_Nom_String = HttpContext.Current.Server.MapPath("~/ErrorLog/" + "error" + ".txt");

        /// <summary>
        /// AddPersonas_bd
        /// </summary>
        /// <param name="personas"></param>
        /// <returns></returns>
        public bool AddPersonas (Personas personas)
        {
            try
            {
                context = new PersonasEntities();
                context.Database.CommandTimeout = 3000;

                context.Personas.Add(personas);
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
