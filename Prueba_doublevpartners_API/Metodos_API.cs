using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Prueba_doublevpartners_ENL.EntityDataModel;
using System.IO;

namespace Prueba_doublevpartners_API
{
    public class Metodos_API
    {
        string logfilepath_Nom_String = HttpContext.Current.Server.MapPath("~/ErrorLog/" + "error" + ".txt");

        /// <summary>
        /// GetUsuarios
        /// </summary>
        /// <param name="envio"></param>
        /// <returns></returns>
        public string GetUsuarios(Usuarios envio)
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri("https://localhost:44309/api/getusuario");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = cliente.PostAsJsonAsync("", envio).GetAwaiter().GetResult(); 

                response.EnsureSuccessStatusCode();

                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult(); 
            }
            catch (Exception ex)
            {
                string errorMessage = "Error API: " + ex.Message;
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string errorLog = $"Error generado el {currentTime}:{Environment.NewLine}{errorMessage}{Environment.NewLine}{Environment.NewLine}";

                using (var escribir = File.AppendText(logfilepath_Nom_String))
                {
                    escribir.Write(errorLog);
                }
                return errorMessage;
            }
        }

        /// <summary>
        /// AddUsuarios
        /// </summary>
        /// <param name="usuarios"></param>
        /// <returns></returns>
        public string AddUsuarios(Usuarios usuarios)
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri("https://localhost:44309/api/addusuario");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = cliente.PostAsJsonAsync("", usuarios).GetAwaiter().GetResult();

                response.EnsureSuccessStatusCode();

                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                string errorMessage = "Error API: " + ex.Message;
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string errorLog = $"Error generado el {currentTime}:{Environment.NewLine}{errorMessage}{Environment.NewLine}{Environment.NewLine}";

                using (var escribir = File.AppendText(logfilepath_Nom_String))
                {
                    escribir.Write(errorLog);
                }
                return errorMessage;
            }
        }

        /// <summary>
        /// AddPersonas
        /// </summary>
        /// <param name="personas"></param>
        /// <returns></returns>
        public string AddPersonas(Personas personas)
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri("https://localhost:44309/api/addpersonas");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = cliente.PostAsJsonAsync("", personas).GetAwaiter().GetResult();

                response.EnsureSuccessStatusCode();

                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                string errorMessage = "Error API: " + ex.Message;
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string errorLog = $"Error generado el {currentTime}:{Environment.NewLine}{errorMessage}{Environment.NewLine}{Environment.NewLine}";

                using (var escribir = File.AppendText(logfilepath_Nom_String))
                {
                    escribir.Write(errorLog);
                }
                return errorMessage;
            }
        }
    }
}