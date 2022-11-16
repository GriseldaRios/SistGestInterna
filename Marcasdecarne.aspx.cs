using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistGestInterna
{
    public partial class Marcasdecarne : System.Web.UI.Page
    {
        Class1 class1 = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            Pre_Init();
        }

        protected void Pre_Init()
        {
            if (!User.Identity.IsAuthenticated)
                Response.Redirect("LoginReservas.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nombre = TextBox1.Text;
            string observaciones = TextBox2.Text;
            class1.GuardarMarca(nombre, observaciones);
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

    }
}