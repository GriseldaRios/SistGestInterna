<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="SistGestInterna.Inventario" %>

<!DOCTYPE html>
<html style="font-size: 16px;" lang="es"><head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta charset="utf-8">
    <meta name="keywords" content="Error 404">
    <meta name="description" content="">
    <title>Inventario</title>
    <link rel="stylesheet" href="nicepage.css" media="screen">
<link rel="stylesheet" href="Inventario.css" media="screen">
    <script class="u-script" type="text/javascript" src="jquery.js" defer=""></script>
    <script class="u-script" type="text/javascript" src="nicepage.js" defer=""></script>
    <meta name="generator" content="Nicepage 4.19.3, nicepage.com">
    <link id="u-theme-google-font" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i|Open+Sans:300,300i,400,400i,500,500i,600,600i,700,700i,800,800i">
    
    
    
    <script type="application/ld+json">{
		"@context": "http://schema.org",
		"@type": "Organization",
		"name": "",
		"logo": "images/default-logo.png"
}</script>
    <meta name="theme-color" content="#478ac9">
    <meta property="og:title" content="Inventario">
    <meta property="og:type" content="website">
  </head>
  <body class="u-body u-xl-mode" data-lang="es">
      <form runat="server">
      <header class="u-clearfix u-header u-header" id="sec-b34f"><div class="u-clearfix u-sheet u-sheet-1">
        <a href="https://nicepage.com" class="u-image u-logo u-image-1" data-image-width="80" data-image-height="40">
          <img src="images/default-logo.png" class="u-logo-image u-logo-image-1">
        </a>
        <nav class="u-menu u-menu-one-level u-offcanvas u-menu-1" data-responsive-from="MD" data-position="">
          <div class="menu-collapse" style="font-size: 1rem; letter-spacing: 0px;">
            <a class="u-button-style u-custom-left-right-menu-spacing u-custom-padding-bottom u-custom-text-active-color u-custom-text-hover-color u-custom-top-bottom-menu-spacing u-nav-link u-text-active-palette-1-base u-text-hover-palette-2-base" href="#" style="font-size: calc(1em + 8px);">
              <svg class="u-svg-link" viewBox="0 0 24 24"><use xmlns:xlink="http://www.w3.org/1999/xlink" xlink:href="#menu-hamburger"></use></svg>
              <svg class="u-svg-content" version="1.1" id="menu-hamburger" viewBox="0 0 16 16" x="0px" y="0px" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns="http://www.w3.org/2000/svg"><g><rect y="1" width="16" height="2"></rect><rect y="7" width="16" height="2"></rect><rect y="13" width="16" height="2"></rect>
</g></svg>
              <span> Menú</span>
            </a>
          </div>
          <div class="u-custom-menu u-nav-container">
            <ul class="u-nav u-unstyled u-nav-1"><li class="u-nav-item"><a class="u-button-style u-nav-link u-text-active-black u-text-hover-palette-4-dark-1" href="Inicio.aspx" style="padding: 10px;">Inicio</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link u-text-active-black u-text-hover-palette-4-dark-1" href="IngresodeMercaderia.aspx" style="padding: 10px;">Ingreso de Mercadería</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link u-text-active-black u-text-hover-palette-4-dark-1" href="Inventario.aspx" style="padding: 10px;">Inventario</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link u-text-active-black u-text-hover-palette-4-dark-1" href="Marcasdecarne.aspx" style="padding: 10px;">Marcas de carne</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link u-text-active-black u-text-hover-palette-4-dark-1" href="Proveedores.aspx" style="padding: 10px;">Proveedores</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link u-text-active-black u-text-hover-palette-4-dark-1" href="CerrarSesion.aspx" style="padding: 10px;">Cerrar Sesión</a>
</li></ul>
          </div>
          <div class="u-custom-menu u-nav-container-collapse">
            <div class="u-black u-container-style u-inner-container-layout u-opacity u-opacity-95 u-sidenav">
              <div class="u-inner-container-layout u-sidenav-overflow">
                <div class="u-menu-close"></div>
                <ul class="u-align-center u-nav u-popupmenu-items u-unstyled u-nav-2"><li class="u-nav-item"><a class="u-button-style u-nav-link" href="Inicio.aspx">Inicio</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link" href="IngresodeMercaderia.aspx">Ingreso de Mercadería</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link" href="Inventario.aspx">Inventario</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link" href="Marcasdecarne.aspx">Marcas de carne</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link" href="Proveedores.aspx">Proveedores</a>
</li><li class="u-nav-item"><a class="u-button-style u-nav-link" href="CerrarSesion.aspx">Cerrar Sesión</a>
</li></ul>
              </div>
            </div>
            <div class="u-black u-menu-overlay u-opacity u-opacity-70"></div>
          </div>
        </nav>
      </div></header>
    <section class="u-align-center u-clearfix u-section-1" id="sec-17dc">
      <div class="u-clearfix u-sheet u-valign-middle u-sheet-1">
        <h1 class="u-align-left u-text u-text-default u-text-1">Inventario</h1>
      </div>
    </section>
    <section class="u-clearfix u-section-2" id="sec-537a">
      <div class="u-clearfix u-sheet u-sheet-1">
        <div class="u-expanded-width u-form u-form-1">
          <div class="u-form-date u-form-group u-form-partition-factor-2 u-form-group-1">
              <label for="date-c3ea" class="u-label u-label-1">Fecha del Inventario</label>
              <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
                    <ContentTemplate>
                <asp:Calendar ID="Calendar1" runat= "server" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-1" required=""></asp:Calendar>
            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
            <div class="u-form-group u-form-partition-factor-2 u-form-select u-form-group-2">
              <label for="select-8dbc" class="u-label u-label-2">Inventario Realizado por</label>
              <div class="u-form-select-wrapper">
                <asp:DropDownList id="DropDownList3" runat="server" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-2">
                      <asp:ListItem>Roberto Domínguez</asp:ListItem>
                      <asp:ListItem>César Arias</asp:ListItem>
                      <asp:ListItem>Amelia Rojas</asp:ListItem>
                      <asp:ListItem>Omar Pérez</asp:ListItem>
                  </asp:DropDownList>
                <svg class="u-caret u-caret-new" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" width="16px" height="16px" viewBox="0 0 16 16" style="fill:currentColor;" xml:space="preserve"><polygon class="st0" points="8,12 2,4 14,4 "></polygon></svg>
              </div>
            </div>
            <div class="u-form-group u-form-partition-factor-2 u-form-select u-form-group-3">
              <label for="select-424b" class="u-label u-label-3">Producto</label>
              <div class="u-form-select-wrapper">
                <asp:DropDownList id="DropDownList1" runat="server" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-3" DataSourceID="SqlDataSource1" DataTextField="nom_producto" DataValueField="nom_producto"></asp:DropDownList>
                <svg class="u-caret u-caret-new" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" width="16px" height="16px" viewBox="0 0 16 16" style="fill:currentColor;" xml:space="preserve"><polygon class="st0" points="8,12 2,4 14,4 "></polygon></svg>
              </div>
            </div>
            <div class="u-form-date u-form-group u-form-partition-factor-2 u-form-group-4">
              <label for="date-baae" class="u-label u-label-4">Fecha de Producción</label>
              <asp:UpdatePanel runat="server" id="UpdatePanel1" updatemode="Conditional">
                    <ContentTemplate>
                <asp:Calendar id="Calendar2" runat="server" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-4"></asp:Calendar>
            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
            <div class="u-form-group u-form-partition-factor-2 u-form-select u-form-group-5">
              <label for="select-1d04" class="u-label u-label-5">Marca</label>
              <div class="u-form-select-wrapper">
                <asp:DropDownList ID="DropDownList2" runat="server" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-5" DataSourceID="SqlDataSource2" DataTextField="marca" DataValueField="marca"></asp:DropDownList>
                  <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BD_coselConnectionString %>" SelectCommand="SELECT [marca] FROM [Marcas]"></asp:SqlDataSource>
                <svg class="u-caret u-caret-new" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" width="16px" height="16px" viewBox="0 0 16 16" style="fill:currentColor;" xml:space="preserve"><polygon class="st0" points="8,12 2,4 14,4 "></polygon></svg>
              </div>
            </div>
            <div class="u-form-group u-form-partition-factor-2 u-form-group-6">
              <label for="text-8d4a" class="u-label u-label-6">Ubicación</label>
              <asp:TextBox ID="TextBox122" runat="server" placeholder="Ingrese la ubicación" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-6"></asp:TextBox>
            </div>
            <div class="u-form-group u-form-partition-factor-2 u-form-group-7">
              <label for="text-99fc" class="u-label u-label-7">Cantidad de Cajas</label>
              <asp:TextBox ID="TextBox115" runat="server" placeholder="Ingrese la cantidad de cajas" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-7"></asp:TextBox>
            </div>
            <div class="u-form-group u-form-partition-factor-2 u-form-group-8">
              <label for="text-8666" class="u-label u-label-8">Unidades</label>
              <asp:TextBox ID="TextBox116" runat="server" placeholder="Ingrese la cantidad de unidades" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-8"></asp:TextBox>
            </div>
            <div class="u-form-group u-form-group-9">
              <label for="text-5e7c" class="u-label u-label-9">Peso Bruto</label>
              <asp:TextBox ID="TextBox117" runat="server" placeholder="Ingrese el peso bruto (utilice punto para los decimales)" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-9"></asp:TextBox>
            </div>
            <div class="u-form-group u-form-group-10">
              <label for="text-9dc5" class="u-label u-label-10">Tara</label>
             <asp:TextBox ID="TextBox118" runat="server" placeholder="Ingrese el peso de la tara (utilice punto para los decimales)" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-10"></asp:TextBox>
            </div>
            <div class="u-form-group u-form-group-11">
              <label for="text-bd4d" class="u-label u-label-11">Peso Neto</label>
              <asp:UpdatePanel runat="server" id="UpdatePanel2" updatemode="Conditional">
                <Triggers>
              <asp:AsyncPostBackTrigger controlid="Button4"
                    eventname="Click" />
            </Triggers>
                <ContentTemplate>
                <asp:TextBox ID="TextBox119" runat="server" placeholder="Calcule el peso neto con el boton Calcular o Ingrese manualmente el peso (utilice punto para los decimales)" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-11"></asp:TextBox>
            </div>
                </ContentTemplate>
                    </asp:UpdatePanel>
            <input type="hidden" value="" name="recaptchaResponse">
            <input type="hidden" name="formServices" value="">
        </div>     
                <div class="u-align-right u-form-group u-form-submit">
              <asp:Button runat="server" Text="Guardar" class="u-border-none u-btn u-btn-round u-btn-submit u-button-style u-palette-4-base u-radius-6 u-btn-1" OnClick="Button1_Click" />
                </div>
                <asp:Button runat="server" ID="Button4" Text="Calcular" class="u-border-none u-btn u-btn-round u-button-style u-hover-palette-4-dark-2 u-palette-4-base u-radius-6 u-btn-2" OnClick="Button4_Click" />
      </div>
    </section>
    
    
    <footer class="u-align-center u-clearfix u-footer u-grey-80 u-footer" id="sec-2c1a">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BD_coselConnectionString %>" SelectCommand="SELECT [nom_producto] FROM [Productos]"></asp:SqlDataSource>
        <div class="u-clearfix u-sheet u-sheet-1">
        <p class="u-small-text u-text u-text-variant u-text-1">Todos los derechos reservados Griselda Ríos 2022</p>
      </div></footer>
      <section class="u-backlink u-clearfix u-grey-80">
      <a class="u-link" href="https://nicepage.com/website-templates" target="_blank">
        <span>Website Templates</span>
      </a>
      <p class="u-text">
        <span>created with</span>
      </p>
      <a class="u-link" href="" target="_blank">
        <span>Website Builder Software</span>
      </a>. 
    </section>
  </form>
</body></html>
