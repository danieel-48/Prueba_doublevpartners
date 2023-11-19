using Newtonsoft.Json.Linq;
using Prueba_doublevpartners_API;
using Prueba_doublevpartners_BLL.BusinessLogic.UsuarioBLL;
using Prueba_doublevpartners_ENL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba_doublevpartners.Views.Login
{
    public partial class Log_In : System.Web.UI.Page
    {
        Usuarios usuario;
        UsuarioBL usuarioBL;
        Metodos_API metodos_API;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            usuario = new Usuarios();

            if (Usuariotxt.Text != "" && Passtxt.Text != "")
            {
                usuarioBL = new UsuarioBL();
                metodos_API = new Metodos_API();

                usuario.Usuario = Usuariotxt.Text;
                usuario.Pass = Passtxt.Text;

                string consulta = metodos_API.GetUsuarios(usuario);

                if (consulta == "\"El usuario existe\"")
                {
                    Response.Redirect("../Registrar/Persona_Usuario.aspx");


                }
                else
                {
                    Label3.Visible = true;
                }
            }
        }
    }  
}