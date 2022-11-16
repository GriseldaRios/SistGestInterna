using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SistGestInterna
{
    public partial class Inventario : System.Web.UI.Page
    {
        Class1 class1 = new Class1();

        public struct tipoRegistro
        {
            public string nom_producto;
            public int cant_cajas;
            public int unidades;
            public decimal peso;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Pre_Init();
        }

        protected void Pre_Init()
        {
            if (!User.Identity.IsAuthenticated)
                Response.Redirect("index.aspx");
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            //guarda productos no reservados
            try
            {
                DateTime fecha_elaboracion = Calendar2.SelectedDate;
                string producto = DropDownList1.SelectedItem.ToString();
                int cajas = Int32.Parse(TextBox115.Text);
                int unidades = Int32.Parse(TextBox116.Text);
                decimal peso = decimal.Parse(TextBox119.Text, System.Globalization.CultureInfo.InvariantCulture);
                decimal peso_bruto = decimal.Parse(TextBox117.Text, System.Globalization.CultureInfo.InvariantCulture);
                decimal tara = decimal.Parse(TextBox118.Text, System.Globalization.CultureInfo.InvariantCulture);
                DateTime fecha_registro = Calendar1.SelectedDate;
                string responsable = DropDownList3.SelectedValue;
                string marca = DropDownList2.SelectedValue;
                string ubicacion = TextBox122.Text;
                string observaciones = "bla";

                class1.GuardarInventarioNoReservas(producto, cajas, unidades, peso, fecha_elaboracion, fecha_registro, responsable, peso_bruto, tara, marca, ubicacion, observaciones);
                //Response.Write("<script>alert('Datos guardados.');</script>");
                TextBox115.Text = "";
                TextBox116.Text = "";
                TextBox117.Text = "";
                TextBox118.Text = "";
                TextBox119.Text = "";
                TextBox122.Text = "";
                //TextBox123.Text = "";
                //Label13.Visible = true;
                

                //ListBox1.SelectedValue = null;
                DropDownList2.SelectedValue = null;
                DropDownList1.SelectedValue = null;
                DropDownList3.SelectedValue = null;
                //Response.Write("<script> window.open('" + "Inventario.aspx" + "', '_self'); </script>");
            }
            catch (System.Data.SqlTypes.SqlTypeException)
            {
                Response.Write("<script>alert('No ha marcado fecha/s.');</script>");
            }
            catch (System.FormatException)
            {
                Response.Write("<script>alert('Debe completar todos los datos.');</script>");
            }
            catch (System.NullReferenceException)
            {
                Response.Write("<script>alert('Debe completar todos los datos.');</script>");
            }
        }
        



        protected void Button4_Click(object sender, EventArgs e)
        {
            decimal peso_neto_noreservas = decimal.Parse(TextBox117.Text, System.Globalization.CultureInfo.InvariantCulture) - (decimal.Parse(TextBox118.Text, System.Globalization.CultureInfo.InvariantCulture) * decimal.Parse(TextBox115.Text, System.Globalization.CultureInfo.InvariantCulture));
            TextBox119.Text = peso_neto_noreservas.ToString();
            TextBox119.Text = TextBox119.Text.Replace(",", ".");
            TextBox119.Focus();
        }
        
    }
}