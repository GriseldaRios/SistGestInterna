using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistGestInterna
{
    public partial class IngresodeMercaderia : System.Web.UI.Page
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            //calcula peso neto
            try
            {
                decimal peso_neto = Convert.ToDecimal(TextBox10.Text, System.Globalization.CultureInfo.InvariantCulture) - (Convert.ToDecimal(TextBox11.Text, System.Globalization.CultureInfo.InvariantCulture) * Convert.ToDecimal(TextBox2.Text, System.Globalization.CultureInfo.InvariantCulture));
                TextBox12.Text = peso_neto.ToString();
                TextBox12.Text = TextBox12.Text.Replace(",", ".");
                Button2.Focus();
            }
            catch (System.FormatException)
            {
                Response.Write("<script>alert('Debe ingresar los datos en el formato correcto.');</script>");
                //Response.Write("<script> window.open('" + "IngresoMercaderias.aspx" + "', '_self'); </script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                //guarda todo en la tabla IngresoMercaderias
                string producto = DropDownList1.SelectedItem.ToString();
                int cant_cajas = int.Parse(TextBox2.Text);
                decimal peso_neto = decimal.Parse(TextBox12.Text, System.Globalization.CultureInfo.InvariantCulture);
                DateTime fecha_ingreso = Calendar1.SelectedDate;
                DateTime fecha_elaboracion = Calendar2.SelectedDate;
                string bodega = "bodega";
                string marca = DropDownList2.SelectedItem.ToString();
                decimal peso_bruto = decimal.Parse(TextBox10.Text, System.Globalization.CultureInfo.InvariantCulture);
                decimal tara = decimal.Parse(TextBox11.Text, System.Globalization.CultureInfo.InvariantCulture);
                string ubicacion = TextBox6.Text;

                class1.GuardarIngresoMercaderias(producto, cant_cajas, peso_neto, fecha_ingreso, fecha_elaboracion, bodega, marca, peso_bruto, tara, ubicacion);

                //Label10.Visible = true;
                //DropDownList5.SelectedValue = null;
                TextBox2.Text = "";
                TextBox12.Text = "";
                //Calendar1.SelectedDate = DateTime.Today;
                //Calendar2.SelectedDate = DateTime.Today;
                DropDownList1.SelectedValue = null;
                DropDownList2.SelectedValue = null;
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox6.Text = "";
            }
            catch (System.Data.SqlTypes.SqlTypeException)
            {
                Response.Write("<script>alert('Debe marcar la/s fecha/s.');</script>");
                //Response.Write("<script> window.open('" + "IngresoMercaderias.aspx" + "', '_self'); </script>");
            }
        }
    }
}