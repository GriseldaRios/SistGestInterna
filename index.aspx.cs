using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SistGestInterna
{
    public partial class index : System.Web.UI.Page
    {
        Class1 class1 = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login (object sender, EventArgs e)
        {

            if (class1.UsuarioRegistrado(TextBox1.Text))
            {
                string contra = class1.contrasena(TextBox1.Text);
                if (contra.Equals(TextBox2.Text))
                {
                    FormsAuthentication.SetAuthCookie("anonimo", true);
                    Response.Write("<script> window.open('" + "Inicio.aspx" + "', '_self'); </script>");
                }
                else
                    Response.Write("<script>alert('Contraseña inválida.');</script>");
            }
            else
                Response.Write("<script>alert('El usuario no se encuentra registrado.');</script>");
        }
    }
}