using Prueba_doublevpartners_API;
using Prueba_doublevpartners_BLL.BusinessLogic.UsuarioBLL;
using Prueba_doublevpartners_ENL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba_doublevpartners.Views.Registrar
{
    public partial class Persona_Usuario : System.Web.UI.Page
    {
        Personas personas;
        Usuarios usuarios;
        Metodos_API metodos_API;
        bool registro_persona;
        bool registro_usuario;

        string logfilepath_Nom_String = HttpContext.Current.Server.MapPath("~/ErrorLog/" + "error" + ".txt");

        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdentificador.Text = txtID.Text;
            txtIdentificador_us.Text = txtID.Text;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
               registro_persona = false;

                personas = new Personas();
                metodos_API = new Metodos_API();

                personas.Identificador = Convert.ToInt64(txtIdentificador.Text);
                personas.Nombres = txtNombres.Text; ;
                personas.Apellidos = txtApellidos.Text;
                personas.Numero_de_identificacion = Convert.ToInt64(txtID.Text);
                personas.Email = txtEmail.Text;
                personas.Tipo_identificacion = cmbx_Tipo_Id.SelectedItem.Text;
                personas.Fecha_de_creación = DateTime.Now;

                string registro_existoso = metodos_API.AddPersonas(personas);

                if (registro_existoso == "\"Persona Registrada\"")
                {
                    registro_persona = true;
                    string script = "alert('Persona Registrada Correctamente');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
                else
                {
                    string script = "alert('Ha ocurrido un error');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Error Views: " + ex.Message;
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string errorLog = $"Error generado el {currentTime}:{Environment.NewLine}{errorMessage}{Environment.NewLine}{Environment.NewLine}";

                using (var escribir = File.AppendText(logfilepath_Nom_String))
                {
                    escribir.Write(errorLog);
                }
            }         
        }

        protected void btnRegistrar_Usuario_Click(object sender, EventArgs e)
        {
            try
            {
                registro_usuario = false;

                usuarios = new Usuarios();
                metodos_API = new Metodos_API();

                usuarios.Identificador = Convert.ToInt64(txtIdentificador_us.Text);
                usuarios.Usuario = txtUsuario.Text;
                usuarios.Pass = txtPass.Text;
                usuarios.Fecha_de_creacion = DateTime.Now;


                string registro_exitoso = metodos_API.AddUsuarios(usuarios);

                if (registro_exitoso == "\"Usuario Registrado\"")
                {
                    registro_usuario = true;
                    string script = "alert('Usuario Registrado Correctamente');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
                else
                {
                    string script = "alert('Ha ocurrido un error');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Error Views: " + ex.Message;
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string errorLog = $"Error generado el {currentTime}:{Environment.NewLine}{errorMessage}{Environment.NewLine}{Environment.NewLine}";

                using (var escribir = File.AppendText(logfilepath_Nom_String))
                {
                    escribir.Write(errorLog);
                }
            }
        }
    }
}