using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Web.Services;
using System.Net.Mail;

namespace SistGestInterna
{
    public class Class1
    {
        public SqlConnection conex;
        public Class1()
        {
            string connection = ConfigurationManager.ConnectionStrings["BD_coselConnectionString"].ConnectionString;
            conex = new SqlConnection(connectionString: connection);
        }

        public void Conectar()
        {
            if (conex.State == System.Data.ConnectionState.Closed)
            {
                conex.Open();
            }
        }

        public void Desconectar()
        {
            if (conex.State == System.Data.ConnectionState.Open)
            {
                conex.Close();
            }
        }

        public void GuardarCostosImportacion(string arancel, string pago_agente, string costo_camion_dol, string costo_camion_pes, string producto, string cant_cajas, string peso_bruto, string peso_neto)
        {
            Conectar();

            string cadena = "insert into CostosImportacion (arancel, pago_agente, costo_camion_dol, costo_camion_pes, producto, cant_cajas, peso_bruto, peso_neto) values (@arancel, @pago_agente, @costo_camion_dol, @costo_camion_pes, @producto, @cant_cajas, @peso_bruto, @peso_neto)";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue(parameterName: "@arancel", arancel);
            cmd.Parameters.AddWithValue(parameterName: "@pago_agente", pago_agente);
            cmd.Parameters.AddWithValue(parameterName: "@costo_camion_dol", costo_camion_dol);
            cmd.Parameters.AddWithValue(parameterName: "@costo_camion_pes", costo_camion_pes);
            cmd.Parameters.AddWithValue(parameterName: "@producto", producto);
            cmd.Parameters.AddWithValue(parameterName: "@cant_cajas", cant_cajas);
            cmd.Parameters.AddWithValue(parameterName: "@peso_bruto", peso_bruto);
            cmd.Parameters.AddWithValue(parameterName: "@peso_neto", peso_neto);
            cmd.ExecuteNonQuery();

            Desconectar();
        }

        public void GuardarInventario(DateTime fecha_ingreso, string codigo, string nombre, string peso_bruto, string peso_neto, string cant_cajas, string tara, string bodega)
        {
            Conectar();

            string cadena = "insert into Inventario (fecha_ingreso, codigo, nombre, peso_bruto, peso_neto, cant_cajas, tara, bodega) values (@fecha_ingreso, @codigo, @nombre, @peso_bruto, @peso_neto, @cant_cajas, @tara, @bodega)";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue(parameterName: "@fecha_ingreso", fecha_ingreso);
            cmd.Parameters.AddWithValue(parameterName: "@codigo", codigo);
            cmd.Parameters.AddWithValue(parameterName: "@nombre", nombre);
            cmd.Parameters.AddWithValue(parameterName: "@tara", tara);
            cmd.Parameters.AddWithValue(parameterName: "@bodega", bodega);
            cmd.Parameters.AddWithValue(parameterName: "@cant_cajas", cant_cajas);
            cmd.Parameters.AddWithValue(parameterName: "@peso_bruto", peso_bruto);
            cmd.Parameters.AddWithValue(parameterName: "@peso_neto", peso_neto);
            cmd.ExecuteNonQuery();

            Desconectar();
        }

        public void GuardarIngresoMercaderias(string producto, int cant_cajas, decimal peso_neto, DateTime fecha_ingreso, DateTime fecha_elaboracion, string bodega, string marca, decimal peso_bruto, decimal tara, string ubicacion)
        {
            //actualizo tabla IngresoMercaderias y NoReservas (existentes)
            int id_producto;
            Conectar();

            string cadena = "insert into IngresoMercaderias (cant_cajas, peso_neto, fecha_ingreso, fecha_elaboracion, bodega, marca, peso_bruto, tara, ubicacion) values (@cant_cajas, @peso_neto, @fecha_ingreso, @fecha_elaboracion, @bodega, @marca, @peso_bruto, @tara, @ubicacion)";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue(parameterName: "@cant_cajas", cant_cajas);
            cmd.Parameters.AddWithValue(parameterName: "@peso_neto", peso_neto);
            cmd.Parameters.AddWithValue(parameterName: "@fecha_ingreso", fecha_ingreso);
            cmd.Parameters.AddWithValue(parameterName: "@fecha_elaboracion", fecha_elaboracion);
            cmd.Parameters.AddWithValue(parameterName: "@bodega", bodega);
            cmd.Parameters.AddWithValue(parameterName: "@marca", marca);
            cmd.Parameters.AddWithValue(parameterName: "@peso_bruto", peso_bruto);
            cmd.Parameters.AddWithValue(parameterName: "@tara", tara);
            cmd.Parameters.AddWithValue(parameterName: "@ubicacion", ubicacion);
            cmd.ExecuteNonQuery();
            //completo la fila
            string cadena1 = "UPDATE IngresoMercaderias set id_producto = Productos.id_producto from Productos where '" + producto + "' = Productos.nom_producto and id_ingreso = (SELECT MAX(id_ingreso) FROM IngresoMercaderias)";
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            cmd1.ExecuteNonQuery();
            //me quedo con el id_producto 
            string cadena2 = "select id_producto from IngresoMercaderias where id_ingreso = (select max(id_ingreso) from IngresoMercaderias)";
            SqlCommand cmd2 = new SqlCommand(cadena2, conex);
            SqlDataReader leer2 = cmd2.ExecuteReader();
            leer2.Read();
            id_producto = leer2.GetInt32(0);
            leer2.Close();
            int unidades = 0;
            string cadena3 = "insert into NoReservas (id_producto, cant_cajas, peso, fecha_elaboracion, marca, peso_bruto, tara, ubicacion, unidades) values (" + id_producto + ", @cant_cajas, @peso, @fecha_elaboracion, @marca, @peso_bruto, @tara, @ubicacion, " + unidades + ")";
            SqlCommand cmd3 = new SqlCommand(cadena3, conex);
            cmd3.Parameters.AddWithValue(parameterName: "@cant_cajas", cant_cajas);
            cmd3.Parameters.AddWithValue(parameterName: "@fecha_elaboracion", fecha_elaboracion);
            cmd3.Parameters.AddWithValue(parameterName: "@marca", marca);
            cmd3.Parameters.AddWithValue(parameterName: "@peso", peso_neto);
            cmd3.Parameters.AddWithValue(parameterName: "@peso_bruto", peso_bruto);
            cmd3.Parameters.AddWithValue(parameterName: "@tara", tara);
            cmd3.Parameters.AddWithValue(parameterName: "@ubicacion", ubicacion);
            cmd3.ExecuteNonQuery();

            Desconectar();
        }

        public void GuardarEgresoMercaderias(string producto_local, string producto_importado, string peso_neto, DateTime fecha_venta)
        {
            Conectar();

            string cadena = "insert into EgresoMercaderias (producto_local, producto_importado, peso_neto, fecha_venta) values (@producto_local, @producto_importado, @peso_neto, @fecha_venta)";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue(parameterName: "@producto_local", producto_local);
            cmd.Parameters.AddWithValue(parameterName: "@producto_importado", producto_importado);
            cmd.Parameters.AddWithValue(parameterName: "@peso_neto", peso_neto);
            cmd.Parameters.AddWithValue(parameterName: "@fecha_venta", fecha_venta);
            cmd.ExecuteNonQuery();

            Desconectar();
        }

        public void TraerRegistro(DropDownList a, TextBox b)
        {
            string producto = a.SelectedItem.ToString();
            Conectar();
            string cadena = "select peso_neto from CostosImportacion where producto = '" + producto + "'";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                string peso_neto = leer.GetString(0);
                b.Text = peso_neto;
            }
            leer.Close();
            Desconectar();
        }

        public void Poblar(GridView grid, string nombreTabla)
        {
            DataTable table = new DataTable();
            Conectar();
            string sql = "select * from " + nombreTabla;
            SqlCommand cmd = new SqlCommand(sql, conex);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            grid.DataSource = table;
            grid.DataBind();
            Desconectar();
        }

        public void ExportGridView(GridView gridView, string nombre_reporte)
        {
            string attachment = "attachment; filename=Reporte " + nombre_reporte + ".xls";
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            // Create a form to contain the grid  
            HtmlForm frm = new HtmlForm();
            gridView.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(gridView);
            frm.RenderControl(htw);
            //gridView.RenderControl(htw);  
            System.Web.HttpContext.Current.Response.Write(sw.ToString());
            System.Web.HttpContext.Current.Response.End();
        }

        public void CantidadIngresada(TextBox a, string producto_local, string producto_importado)
        {
            //suma las cantidades de los distintos productos
            double cantPos;

            Conectar();

            string cadena = "select sum(peso_neto) from IngresoMercaderias where producto_local = '" + producto_local + "' or producto_importado = '" + producto_importado + "'";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                cantPos = (double)leer.GetValue(0);
                a.Text = cantPos.ToString();
            }
            leer.Close();

            Desconectar();
        }

        public void CantidadEgresada(TextBox a, string producto_local, string producto_importado)
        {
            double cantNeg;

            Conectar();

            string cadena1 = "select sum(peso_neto) from EgresoMercaderias where producto_local = '" + producto_local + "' or producto_importado = '" + producto_importado + "'";
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            SqlDataReader leer1 = cmd1.ExecuteReader();
            if (leer1.Read())
            {
                cantNeg = (double)leer1.GetValue(0);
                a.Text = cantNeg.ToString();
            }
            leer1.Close();

            Desconectar();
        }

        public void CantidadTotal(TextBox a, TextBox b, TextBox c)
        {
            c.Text = (double.Parse(a.Text) - double.Parse(b.Text)).ToString();
        }

        public void MostrarResultadoInventario(GridView gridview1, GridView gridview2)
        {
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            Conectar();
            string cadena = "select * from RegistroInventario where es_reserva = 0";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table1);
            gridview1.DataSource = table1;
            gridview1.DataBind();

            string cadena1 = "select * from RegistroInventario where es_reserva = 1";
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            SqlDataAdapter db = new SqlDataAdapter(cmd1);
            db.Fill(table2);
            gridview2.DataSource = table2;
            gridview2.DataBind();
            Desconectar();

        }

        public void GuardarInventarioNoReservas(string producto, int cajas, int unidades, decimal peso, DateTime fecha_elaboracion, DateTime fecha_registro, string responsable, decimal peso_bruto, decimal tara, string marca, string ubicacion, string observaciones)
        {
            int es_reserva = 0;
            Conectar();

            string cadena = "insert into NoReservas (cant_cajas, unidades, peso, fecha_elaboracion, marca, ubicacion, observaciones, peso_bruto, tara) values (@cant_cajas, @unidades, @peso, @fecha_elaboracion, @marca, @ubicacion, @observaciones, @peso_bruto, @tara)";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue(parameterName: "@cant_cajas", cajas);
            cmd.Parameters.AddWithValue(parameterName: "@unidades", unidades);
            cmd.Parameters.AddWithValue(parameterName: "@peso", peso);
            cmd.Parameters.AddWithValue(parameterName: "@fecha_elaboracion", fecha_elaboracion);
            cmd.Parameters.AddWithValue(parameterName: "@peso_bruto", peso_bruto);
            cmd.Parameters.AddWithValue(parameterName: "@tara", tara);
            cmd.Parameters.AddWithValue(parameterName: "@marca", marca);
            cmd.Parameters.AddWithValue(parameterName: "@ubicacion", ubicacion);
            cmd.Parameters.AddWithValue(parameterName: "@observaciones", observaciones);
            cmd.ExecuteNonQuery();
            string cadena1 = "update NoReservas set id_producto = Productos.id_producto from Productos where '" + producto + "' = Productos.nom_producto and id_noreserva = (SELECT MAX(id_noreserva) FROM NoReservas)";
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            cmd1.ExecuteNonQuery();
            string cadena2 = "insert into RegistroInventario (cant_cajas, unidades, peso, fecha_elaboracion, responsable, fecha_registro, es_reserva, peso_bruto, tara, ubicacion, observaciones, marca) values (@cant_cajas, @unidades, @peso, @fecha_elaboracion, @responsable, @fecha_registro, @es_reserva, @peso_bruto, @tara, @ubicacion, @observaciones, @marca)";
            SqlCommand cmd2 = new SqlCommand(cadena2, conex);
            cmd2.Parameters.AddWithValue(parameterName: "@cant_cajas", cajas);
            cmd2.Parameters.AddWithValue(parameterName: "@unidades", unidades);
            cmd2.Parameters.Add(new SqlParameter("@peso", SqlDbType.Decimal)).Value = peso;
            cmd2.Parameters.AddWithValue(parameterName: "@fecha_elaboracion", fecha_elaboracion);
            cmd2.Parameters.AddWithValue(parameterName: "@responsable", responsable);
            cmd2.Parameters.AddWithValue(parameterName: "@fecha_registro", fecha_registro);
            cmd2.Parameters.AddWithValue(parameterName: "@es_reserva", es_reserva);
            cmd2.Parameters.AddWithValue(parameterName: "@peso_bruto", peso_bruto);
            cmd2.Parameters.AddWithValue(parameterName: "@tara", tara);
            cmd2.Parameters.AddWithValue(parameterName: "@marca", marca);
            cmd2.Parameters.AddWithValue(parameterName: "@observaciones", observaciones);
            cmd2.Parameters.AddWithValue(parameterName: "@ubicacion", ubicacion);
            cmd2.ExecuteNonQuery();
            string cadena3 = "update RegistroInventario set id_producto = Productos.id_producto from Productos where '" + producto + "' = Productos.nom_producto and id_registro = (SELECT MAX(id_registro) FROM RegistroInventario)";
            SqlCommand cmd3 = new SqlCommand(cadena3, conex);
            cmd3.ExecuteNonQuery();

            Desconectar();
        }

        public void GuardarInventarioReservas(string producto, int cajas, int unidades, decimal peso, DateTime fecha_elaboracion, DateTime fecha_registro, string responsable, decimal peso_bruto, decimal tara, string ubicacion, string observaciones, string cliente, string marca)
        {
            int es_reserva = 1;

            Conectar();

            string cadena = "insert into Reservas (cliente, cant_cajas, unidades, peso, fecha_elaboracion, marca, peso_bruto, tara, ubicacion, observaciones) values (@cliente, @cant_cajas, @unidades, @peso, @fecha_elaboracion, @marca, @peso_bruto, @tara, @ubicacion, @observaciones)";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue(parameterName: "@cliente", cliente);
            cmd.Parameters.AddWithValue(parameterName: "@cant_cajas", cajas);
            cmd.Parameters.AddWithValue(parameterName: "@unidades", unidades);
            cmd.Parameters.AddWithValue(parameterName: "@peso", peso);
            cmd.Parameters.AddWithValue(parameterName: "@fecha_elaboracion", fecha_elaboracion);
            cmd.Parameters.AddWithValue(parameterName: "@peso_bruto", peso_bruto);
            cmd.Parameters.AddWithValue(parameterName: "@tara", tara);
            cmd.Parameters.AddWithValue(parameterName: "@marca", marca);
            cmd.Parameters.AddWithValue(parameterName: "@ubicacion", ubicacion);
            cmd.Parameters.AddWithValue(parameterName: "@observaciones", observaciones);
            cmd.ExecuteNonQuery();
            string cadena1 = "update Reservas set id_producto = Productos.id_producto from Productos where '" + producto + "' = Productos.nom_producto and id_reserva = (SELECT MAX(id_reserva) FROM Reservas)";
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            cmd1.ExecuteNonQuery();

            string cadena2 = "insert into RegistroInventario (cant_cajas, unidades, peso, fecha_elaboracion, responsable, fecha_registro, es_reserva, peso_bruto, tara, ubicacion, observaciones, cliente, marca) values (@cant_cajas, @unidades, @peso, @fecha_elaboracion, @responsable, @fecha_registro, @es_reserva, @peso_bruto, @tara, @ubicacion, @observaciones, @cliente, @marca)";
            SqlCommand cmd2 = new SqlCommand(cadena2, conex);
            cmd2.Parameters.AddWithValue(parameterName: "@cant_cajas", cajas);
            cmd2.Parameters.AddWithValue(parameterName: "@unidades", unidades);
            cmd2.Parameters.Add(new SqlParameter("@peso", SqlDbType.Decimal)).Value = peso;
            cmd2.Parameters.AddWithValue(parameterName: "@fecha_elaboracion", fecha_elaboracion);
            cmd2.Parameters.AddWithValue(parameterName: "@responsable", responsable);
            cmd2.Parameters.AddWithValue(parameterName: "@fecha_registro", fecha_registro);
            cmd2.Parameters.AddWithValue(parameterName: "@es_reserva", es_reserva);
            cmd2.Parameters.AddWithValue(parameterName: "@peso_bruto", peso_bruto);
            cmd2.Parameters.AddWithValue(parameterName: "@tara", tara);
            cmd2.Parameters.AddWithValue(parameterName: "@observaciones", observaciones);
            cmd2.Parameters.AddWithValue(parameterName: "@ubicacion", ubicacion);
            cmd2.Parameters.AddWithValue(parameterName: "@cliente", cliente);
            cmd2.Parameters.AddWithValue(parameterName: "@marca", marca);
            cmd2.ExecuteNonQuery();
            string cadena3 = "update RegistroInventario set id_producto = Productos.id_producto from Productos where '" + producto + "' = Productos.nom_producto and id_registro = (SELECT MAX(id_registro) FROM RegistroInventario)";
            SqlCommand cmd3 = new SqlCommand(cadena3, conex);
            cmd3.ExecuteNonQuery();

            Desconectar();
        }

        public void GuardarReserva(DateTime fecha_reserva, string producto, int cant_cajas, decimal peso, string cliente)
        {
            int id_producto;
            Conectar();
            //guardo los datos en Reservas
            string cadena = "insert into Reservas (peso, nombre_razon_social, fecha_reserva, cant_cajas) values (@peso, @cliente, @fecha_reserva, @cant_cajas)";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue(parameterName: "@fecha_reserva", fecha_reserva);
            cmd.Parameters.AddWithValue(parameterName: "@cant_cajas", cant_cajas);
            cmd.Parameters.AddWithValue(parameterName: "@peso", peso);
            cmd.Parameters.AddWithValue(parameterName: "@cliente", cliente);
            cmd.ExecuteNonQuery();
            //le pongo el correspondiente id_producto
            string cadena1 = "update Reservas set id_producto = Productos.id_producto from Productos where '" + producto + "' = Productos.nom_producto and id_reserva = (SELECT MAX(id_reserva) FROM Reservas)";
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            cmd1.ExecuteNonQuery();
            //me quedo con el id_producto 
            string cadena2 = "select id_producto from Reservas where id_reserva = (select max(id_reserva) from Reservas)";
            SqlCommand cmd2 = new SqlCommand(cadena2, conex);
            SqlDataReader leer = cmd2.ExecuteReader();
            leer.Read();
            id_producto = leer.GetInt32(0);
            leer.Close();

            string cadena4 = "update NoReservas set peso = peso - @peso, cant_cajas = cant_cajas - @cant_cajas where id_producto = " + id_producto;
            SqlCommand cmd4 = new SqlCommand(cadena4, conex);
            cmd4.Parameters.Add(new SqlParameter("@peso", SqlDbType.Decimal)).Value = peso;
            cmd4.Parameters.Add(new SqlParameter("@cant_cajas", cant_cajas));
            cmd4.ExecuteNonQuery();

            Desconectar();
        }

        public void MostrarPeso(TextBox textBox, string producto)
        {
            //muestra el peso en NoReservas del item seleccionado
            int id_producto;
            decimal peso;
            Conectar();
            string cadena = "select id_producto from Productos where nom_producto = '" + producto + "'";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            SqlDataReader leer = cmd.ExecuteReader();
            leer.Read();
            id_producto = leer.GetInt32(0);
            leer.Close();

            string cadena1 = "select peso from NoReservas where id_producto = " + id_producto;
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            SqlDataReader leer1 = cmd1.ExecuteReader();
            leer1.Read();
            peso = leer1.GetDecimal(0);
            leer1.Close();

            textBox.Text = peso.ToString();
        }

        public void MostrarReservas(GridView gridview, string nombre_razon_social)
        {
            DataTable table = new DataTable();
            Conectar();
            string cadena = "select Reservas.id_reserva, Reservas.nombre_razon_social, Productos.nom_producto, Reservas.peso, Reservas.cant_cajas, Reservas.fecha_reserva from Reservas inner join Productos on Reservas.id_producto = Productos.id_producto where Reservas.nombre_razon_social = '" + nombre_razon_social + "'";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            gridview.DataSource = table;
            gridview.DataBind();
            Desconectar();
        }

        public bool UsuarioRegistrado(string nombreUsuario)
        {
            bool resultado = false;
            Conectar();
            string cadena = "select * from Usuarios where usuario = '" + nombreUsuario + "'";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                resultado = true;
            }
            leer.Close();
            Desconectar();
            return resultado;
        }

        public string contrasena(string nombreUsuario)
        {
            string resultado = "";
            Conectar();
            string cadena = "select contrasena from Usuarios where usuario = '" + nombreUsuario + "'";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                resultado = leer.GetString(0);
            }
            leer.Close();
            return resultado;
        }

        public void GuardarCliente(string nombre, string rut, string direccion, string comuna, string ciudad, string rubro, string mail, string telefono)
        {
            Conectar();
            string cadena = "insert into Clientes (nombre_razon_social, rut, direccion, comuna, ciudad, rubro, mail, telefono) values (@nombre_razon_social, @rut, @direccion, @comuna, @ciudad, @rubro, @mail, @telefono)";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue(parameterName: "@nombre_razon_social", nombre);
            cmd.Parameters.AddWithValue(parameterName: "@rut", rut);
            cmd.Parameters.AddWithValue(parameterName: "@direccion", direccion);
            cmd.Parameters.AddWithValue(parameterName: "@comuna", comuna);
            cmd.Parameters.AddWithValue(parameterName: "@ciudad", ciudad);
            cmd.Parameters.AddWithValue(parameterName: "@rubro", rubro);
            cmd.Parameters.AddWithValue(parameterName: "@mail", mail);
            cmd.Parameters.AddWithValue(parameterName: "@telefono", telefono);
            cmd.ExecuteNonQuery();

            Desconectar();
        }

        public void EditarCliente(int id, TextBox TextBox1, TextBox TextBox2, TextBox TextBox3, TextBox TextBox4, TextBox TextBox5, TextBox TextBox6, TextBox TextBox7, TextBox TextBox8)
        {
            string nombre, rut, direccion, comuna, ciudad, rubro, mail, telefono;
            Conectar();
            string cadena = "select nombre_razon_social, rut, direccion, comuna, ciudad, rubro, mail, telefono from Clientes where id_nombre = " + id;
            SqlCommand cmd = new SqlCommand(cadena, conex);
            SqlDataReader leer = cmd.ExecuteReader();
            leer.Read();
            nombre = leer.GetString(0);
            rut = leer.GetString(1);
            direccion = leer.GetString(2);
            comuna = leer.GetString(3);
            ciudad = leer.GetString(4);
            rubro = leer.GetString(5);
            mail = leer.GetString(6);
            telefono = leer.GetString(7);
            leer.Close();

            TextBox1.Text = nombre;
            TextBox2.Text = rut;
            TextBox3.Text = direccion;
            TextBox4.Text = comuna;
            TextBox5.Text = ciudad;
            TextBox6.Text = rubro;
            TextBox7.Text = mail;
            TextBox8.Text = telefono;

            Desconectar();
        }

        public void GuardarEdicionCliente(int id, string nombre, string rut, string direccion, string comuna, string ciudad, string rubro, string mail, string telefono)
        {
            Conectar();
            string cadena = "update Clientes set nombre_razon_social = @nombre, rut = @rut, direccion = @direccion, comuna = @comuna, ciudad = @ciudad, rubro = @rubro, mail = @mail, telefono = @telefono where id_nombre = " + id;
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue(parameterName: "@nombre", nombre);
            cmd.Parameters.AddWithValue(parameterName: "@rut", rut);
            cmd.Parameters.AddWithValue(parameterName: "@direccion", direccion);
            cmd.Parameters.AddWithValue(parameterName: "@comuna", comuna);
            cmd.Parameters.AddWithValue(parameterName: "@ciudad", ciudad);
            cmd.Parameters.AddWithValue(parameterName: "@rubro", rubro);
            cmd.Parameters.AddWithValue(parameterName: "@mail", mail);
            cmd.Parameters.AddWithValue(parameterName: "@telefono", telefono);
            cmd.ExecuteNonQuery();

            Desconectar();
        }

        public void EliminarCliente(int id)
        {
            Conectar();
            string cadena = "delete from Clientes where id_nombre = " + id;
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void EliminarReserva(int id)
        {
            Conectar();
            //sumar peso y cant_cajas al producto
            decimal peso;
            int cant_cajas;
            int id_producto;

            string cadena = "select peso, cant_cajas from Reservas where id_reserva = " + id;
            SqlCommand cmd = new SqlCommand(cadena, conex);
            SqlDataReader leer = cmd.ExecuteReader();
            leer.Read();
            peso = leer.GetDecimal(0);
            cant_cajas = leer.GetInt32(1);
            leer.Close();

            string cadena1 = "select id_producto from Reservas where id_reserva = " + id;
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            SqlDataReader leer1 = cmd1.ExecuteReader();
            leer1.Read();
            id_producto = leer1.GetInt32(0);
            leer1.Close();

            string cadena2 = "update NoReservas set peso = peso + @peso, cant_cajas = cant_cajas + @cant_cajas where id_producto = " + id_producto;
            SqlCommand cmd2 = new SqlCommand(cadena2, conex);
            cmd2.Parameters.Add(new SqlParameter("@peso", SqlDbType.Decimal)).Value = peso;
            cmd2.Parameters.Add(new SqlParameter("@cant_cajas", cant_cajas));
            cmd2.ExecuteNonQuery();

            //borrar el registro
            string cadena3 = "delete from Reservas where id_reserva = " + id;
            SqlCommand cmd3 = new SqlCommand(cadena3, conex);
            cmd3.ExecuteNonQuery();
            Desconectar();
        }

        public void EditarReserva(int id, TextBox TextBox9, TextBox TextBox10, TextBox TextBox11, TextBox TextBox12)
        {
            string nombre_razon_social, nom_producto;
            int cant_cajas;
            decimal peso;
            Conectar();
            string cadena = "select Reservas.nombre_razon_social, Productos.nom_producto, Reservas.cant_cajas, Reservas.peso from Reservas inner join Productos on Productos.id_producto = Reservas.id_producto where Reservas.id_reserva = " + id;
            SqlCommand cmd = new SqlCommand(cadena, conex);
            SqlDataReader leer = cmd.ExecuteReader();
            leer.Read();
            nombre_razon_social = leer.GetString(0);
            nom_producto = leer.GetString(1);
            cant_cajas = leer.GetInt32(2);
            peso = leer.GetDecimal(3);
            leer.Close();

            TextBox9.Text = nombre_razon_social;
            TextBox10.Text = nom_producto;
            TextBox11.Text = cant_cajas.ToString();
            TextBox12.Text = peso.ToString();

            Desconectar();
        }

        public void GuardarEdicionReserva(int id, string nombre_razon_social, int cant_cajas_nueva, decimal peso_nuevo)
        {
            int id_producto;
            decimal peso_viejo;
            decimal peso_resultante;
            int cant_cajas_vieja;
            int cant_cajas_resultante;

            Conectar();

            //me quedo con el peso_viejo y la cant_cajas_vieja
            string cadena1 = "select id_producto, peso, cant_cajas from Reservas where id_reserva = " + id;
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            SqlDataReader leer1 = cmd1.ExecuteReader();
            leer1.Read();
            id_producto = leer1.GetInt32(0);
            peso_viejo = leer1.GetDecimal(1);
            cant_cajas_vieja = leer1.GetInt32(2);
            leer1.Close();

            //grabo el peso nuevo y la cant_cajas nueva en Reservas
            string cadena = "update Reservas set nombre_razon_social = @nombre_razon_social, cant_cajas = @cant_cajas, peso = @peso where id_reserva = " + id;
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.AddWithValue(parameterName: "@nombre_razon_social", nombre_razon_social);
            cmd.Parameters.AddWithValue(parameterName: "@cant_cajas", cant_cajas_nueva);
            cmd.Parameters.AddWithValue(parameterName: "@peso", peso_nuevo);
            cmd.ExecuteNonQuery();

            //comparar los pesos y las cantidades de cajas para saber si sumar o restar
            if (peso_viejo < peso_nuevo & cant_cajas_vieja < cant_cajas_nueva)
            {
                peso_resultante = peso_nuevo - peso_viejo;
                cant_cajas_resultante = cant_cajas_nueva - cant_cajas_vieja;
                //actualizo NoReservas
                string cadena2 = "update NoReservas set peso = peso - @peso_resultante, cant_cajas = cant_cajas - @cant_cajas_resultante where id_producto = " + id_producto;
                SqlCommand cmd2 = new SqlCommand(cadena2, conex);
                cmd2.Parameters.Add(new SqlParameter("@peso_resultante", SqlDbType.Decimal)).Value = peso_resultante;
                cmd2.Parameters.Add(new SqlParameter("@cant_cajas_resultante", cant_cajas_resultante));
                cmd2.ExecuteNonQuery();
            }
            else
            {
                peso_resultante = peso_viejo - peso_nuevo;
                cant_cajas_resultante = cant_cajas_vieja - cant_cajas_nueva;
                //actualizo NoReservas
                string cadena3 = "update NoReservas set peso = peso + @peso_resultante, cant_cajas = cant_cajas + @cant_cajas_resultante where id_producto = " + id_producto;
                SqlCommand cmd3 = new SqlCommand(cadena3, conex);
                cmd3.Parameters.Add(new SqlParameter("@peso_resultante", SqlDbType.Decimal)).Value = peso_resultante;
                cmd3.Parameters.Add(new SqlParameter("@cant_cajas_resultante", cant_cajas_resultante));
                cmd3.ExecuteNonQuery();
            }

            Desconectar();
        }

        public void AgregarAlPedido(GridView GridView3, string cliente, int id_producto, DateTime fecha_elaboracion, int cant_cajas, int unidades, string marca, decimal peso, string ubicacion, string observaciones, string obs_del_pedido, DateTime fecha_pedido)
        {
            Conectar();
            int mandado = 0;
            string cadena = "insert into Pedidos (cliente, id_producto, fecha_elaboracion, cant_cajas, unidades, marca, peso, mandado, ubicacion, observaciones, obs_del_pedido, fecha_pedido) values (@cliente, @id_producto, @fecha_elaboracion, @cant_cajas, @unidades, @marca, @peso, @mandado, @ubicacion, @observaciones, @obs_del_pedido, @fecha_pedido)";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.Add(new SqlParameter("@peso", SqlDbType.Decimal)).Value = peso;
            cmd.Parameters.Add(new SqlParameter("@id_producto", id_producto));
            cmd.Parameters.Add(new SqlParameter("@fecha_elaboracion", SqlDbType.Date)).Value = fecha_elaboracion;
            cmd.Parameters.Add(new SqlParameter("@cant_cajas", cant_cajas));
            cmd.Parameters.Add(new SqlParameter("@unidades", unidades));
            cmd.Parameters.Add(new SqlParameter("@marca", marca));
            cmd.Parameters.Add(new SqlParameter("@mandado", mandado));
            cmd.Parameters.Add(new SqlParameter("@cliente", cliente));
            cmd.Parameters.Add(new SqlParameter("@ubicacion", ubicacion));
            cmd.Parameters.Add(new SqlParameter("@observaciones", observaciones));
            cmd.Parameters.Add(new SqlParameter("@obs_del_pedido", obs_del_pedido));
            cmd.Parameters.Add(new SqlParameter("@fecha_pedido", fecha_pedido));
            cmd.ExecuteNonQuery();
            string cadena1 = "select Pedidos.fecha_pedido, Pedidos.cliente, Productos.nom_producto, Pedidos.marca, Pedidos.cant_cajas, Pedidos.unidades, Pedidos.peso, Pedidos.ubicacion, Pedidos.fecha_elaboracion, Pedidos.observaciones, Pedidos.obs_del_pedido from Pedidos inner join Productos on Pedidos.id_producto = Productos.id_producto where Pedidos.mandado = 0";
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
            string cadena2 = "update NoReservas set NoReservas.cant_cajas = NoReservas.cant_cajas - Pedidos.cant_cajas from NoReservas inner join Pedidos on NoReservas.ubicacion = Pedidos.ubicacion where (Pedidos.mandado = 0) and (Pedidos.id_pedido = (select max(id_pedido) from Pedidos))";
            SqlCommand cmd2 = new SqlCommand(cadena2, conex);
            cmd2.ExecuteNonQuery();
            string cadena3 = "update NoReservas set NoReservas.peso = NoReservas.peso - Pedidos.peso from NoReservas inner join Pedidos on NoReservas.ubicacion = Pedidos.ubicacion where (Pedidos.mandado = 0) and (Pedidos.id_pedido = (select max(id_pedido) from Pedidos))";
            SqlCommand cmd3 = new SqlCommand(cadena3, conex);
            cmd3.ExecuteNonQuery();
            string cadena4 = "update NoReservas set NoReservas.unidades = NoReservas.unidades - Pedidos.unidades from NoReservas inner join Pedidos on NoReservas.ubicacion = Pedidos.ubicacion where (Pedidos.mandado = 0) and (Pedidos.id_pedido = (select max(id_pedido) from Pedidos))";
            SqlCommand cmd4 = new SqlCommand(cadena4, conex);
            cmd4.ExecuteNonQuery();
            Desconectar();
        }





        public void CambiarMandado(GridView gridView)
        {
            Conectar();

            string cadena = "update Pedidos set mandado = 1 where mandado = 0";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.ExecuteNonQuery();
            Desconectar();
            gridView.Visible = false;
        }

        public void ResetearExistencias()
        {
            Conectar();
            string cadena = "delete from NoReservas";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void RestablecerValores(int id_pedido, int cant_cajas, int unidades, decimal peso, string ubicacion, DateTime fecha_pedido, string cliente, int id_producto, DateTime fecha_elaboracion, string marca, string observaciones, string obs_del_pedido)
        {
            Conectar();
            string cadena = "update NoReservas set NoReservas.cant_cajas = NoReservas.cant_cajas + @cant_cajas, NoReservas.unidades = NoReservas.unidades + @unidades, NoReservas.peso = NoReservas.peso + @peso where NoReservas.ubicacion = @ubicacion";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.Add(new SqlParameter("@peso", SqlDbType.Decimal)).Value = peso;
            cmd.Parameters.Add(new SqlParameter("@cant_cajas", cant_cajas));
            cmd.Parameters.Add(new SqlParameter("@unidades", unidades));
            cmd.Parameters.Add(new SqlParameter("@ubicacion", ubicacion));
            cmd.ExecuteNonQuery();
            string cadena2 = "insert into PedidosEliminados (fecha_pedido, cliente, id_producto, fecha_elaboracion, cant_cajas, unidades, marca, peso, ubicacion, observaciones, obs_del_pedido) values (@fecha_pedido, @cliente, @id_producto, @fecha_elaboracion, @cant_cajas, @unidades, @marca, @peso, @ubicacion, @observaciones, @obs_del_pedido)";
            SqlCommand cmd2 = new SqlCommand(cadena2, conex);
            cmd2.Parameters.Add(new SqlParameter("@fecha_pedido", fecha_pedido));
            cmd2.Parameters.Add(new SqlParameter("@cliente", cliente));
            cmd2.Parameters.Add(new SqlParameter("@id_producto", id_producto));
            cmd2.Parameters.Add(new SqlParameter("@fecha_elaboracion", fecha_elaboracion));
            cmd2.Parameters.Add(new SqlParameter("@cant_cajas", cant_cajas));
            cmd2.Parameters.Add(new SqlParameter("@unidades", unidades));
            cmd2.Parameters.Add(new SqlParameter("@marca", marca));
            cmd2.Parameters.Add(new SqlParameter("@peso", SqlDbType.Decimal)).Value = peso;
            cmd2.Parameters.Add(new SqlParameter("@ubicacion", ubicacion));
            cmd2.Parameters.Add(new SqlParameter("@observaciones", observaciones));
            cmd2.Parameters.Add(new SqlParameter("@obs_del_pedido", obs_del_pedido));
            cmd2.ExecuteNonQuery();
            string cadena1 = "delete from Pedidos where id_pedido = @id_pedido";
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            cmd1.Parameters.Add(new SqlParameter("@id_pedido", id_pedido));
            cmd1.ExecuteNonQuery();
            Desconectar();
        }

        public void RestablecerValores1(int id_registro, string ubicacion)
        {
            Conectar();

            string cadena = "delete from NoReservas where (ubicacion = @ubicacion)";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.Add(new SqlParameter("@ubicacion", ubicacion));
            cmd.ExecuteNonQuery();


            string cadena1 = "delete from RegistroInventario where id_registro = @id_registro";
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            cmd1.Parameters.Add(new SqlParameter("@id_registro", id_registro));
            cmd1.ExecuteNonQuery();
            Desconectar();
        }

        public void MostrarClientes(string nombrecliente, TextBox textbox)
        {
            string nombrecliente1;
            Conectar();
            string cadena = "select nombre_razon_social from Clientes where nombre_razon_social like '%" + nombrecliente + "%'";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            SqlDataReader leer = cmd.ExecuteReader();
            leer.Read();
            nombrecliente1 = leer.GetString(0);
            leer.Close();
            textbox.Text = nombrecliente1;
            Desconectar();
        }

        public void BorrarIngreso(int id_ingreso, string ubicacion)
        {
            Conectar();
            string cadena = "delete from IngresoMercaderias where id_ingreso = " + id_ingreso;
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.ExecuteNonQuery();
            string cadena1 = "delete from NoReservas where ubicacion = @ubicacion";
            SqlCommand cmd1 = new SqlCommand(cadena1, conex);
            cmd1.Parameters.Add(new SqlParameter("@ubicacion", ubicacion));
            cmd1.ExecuteNonQuery();
            Desconectar();
        }

        public void GuardarUbicacionDesarmada(string ubicacion)
        {
            Conectar();
            string cadena = "update NoReservas set desarmado = 1 where ubicacion = @ubicacion";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.Add(new SqlParameter("@ubicacion", ubicacion));
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void MostrarDeterminadoMes(GridView gridView, int mes, int anio)
        {
            DataTable table = new DataTable();
            Conectar();
            string cadena = "select RegistroInventario.*, Productos.nom_producto from RegistroInventario inner join Productos on RegistroInventario.id_producto = Productos.id_producto where month(fecha_registro) = @mes and year(fecha_registro) = @anio";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.Add(new SqlParameter("@mes", mes));
            cmd.Parameters.Add(new SqlParameter("@anio", anio));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            gridView.DataSource = table;
            gridView.DataBind();
            Desconectar();
        }

        public void MostrarDeterminadaFecha(GridView gridView, DateTime fecha_registro)
        {
            DataTable table = new DataTable();
            Conectar();
            string cadena = "select RegistroInventario.*, Productos.nom_producto from RegistroInventario inner join Productos on RegistroInventario.id_producto = Productos.id_producto where fecha_registro = @fecha_registro";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.Add(new SqlParameter("@fecha_registro", fecha_registro));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            gridView.DataSource = table;
            gridView.DataBind();
            Desconectar();
        }

        public void GuardarProveedor(string nombre, string rut, string direccion, string correo, string telefono, string observaciones)
        {
            Conectar();
            string cadena = "insert into Proveedores (nombre, rut, direccion, correo, telefono, observaciones) values (@nombre, @rut, @direccion, @correo, @telefono, @observaciones)";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new SqlParameter("@rut", rut));
            cmd.Parameters.Add(new SqlParameter("@direccion", direccion));
            cmd.Parameters.Add(new SqlParameter("@correo", correo));
            cmd.Parameters.Add(new SqlParameter("@telefono", telefono));
            cmd.Parameters.Add(new SqlParameter("@observaciones", observaciones));
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void GuardarMarca(string nombre, string observaciones)
        {
            Conectar();
            string cadena = "insert into Marcas (marca, observaciones) values (@nombre, @observaciones)";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
            cmd.Parameters.Add(new SqlParameter("@observaciones", observaciones));
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void Despachado(string cliente, DateTime fecha_pedido)
        {
            Conectar();
            string cadena = "update Pedidos set despachado = 1 where cliente = @cliente and fecha_pedido = @fecha_pedido";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.Add(new SqlParameter("@cliente", cliente));
            cmd.Parameters.Add(new SqlParameter("@fecha_pedido", fecha_pedido));
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void RestablecerCliente(string cliente, DateTime fecha_pedido)
        {
            Conectar();
            string cadena = "update Pedidos set despachado = null where cliente = @cliente and fecha_pedido = @fecha_pedido";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.Add(new SqlParameter("@cliente", cliente));
            cmd.Parameters.Add(new SqlParameter("@fecha_pedido", fecha_pedido));
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void send_click(string cliente1, string id_producto)
        {
            MailMessage message = new MailMessage("griseldariossistemas@gmail.com", "pulpogris6@gmail.com", "Pedidos de hoy", "El cliente " + cliente1 + " pidió el producto " + id_producto);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);  //587
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("griseldariossistemas@gmail.com", "vrvsbtdxsqolgcvg");
            client.Send(message);
        }

        public void chequear_pedidos(DateTime hoy)
        {
            string cliente;
            int id_producto;
            string hoy1 = hoy.ToString("yyyy'-'MM'-'dd");
            DataTable dt = new DataTable();
            Conectar();
            string cadena = "select cliente, id_producto from Pedidos where fecha_pedido = @hoy1";
            SqlCommand cmd = new SqlCommand(cadena, conex);
            cmd.Parameters.Add(new SqlParameter("@hoy1", hoy1));
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            SqlDataReader leer = cmd.ExecuteReader();

            foreach (DataRow row in dt.Rows)
            {
                leer.Read();
                cliente = leer.GetString(0);
                id_producto = leer.GetInt32(1);

                send_click(cliente, id_producto.ToString());
            }
            leer.Close();
            
            Desconectar();
        }
    }

}
