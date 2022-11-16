<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Marcasdecarne.aspx.cs" Inherits="SistGestInterna.Marcasdecarne" %>

<!DOCTYPE html>
<html style="font-size: 16px;" lang="es"><head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta charset="utf-8">
    <meta name="keywords" content="Marcas">
    <meta name="description" content="">
    <title>Marcas de carne</title>
    <link rel="stylesheet" href="nicepage.css" media="screen">
<link rel="stylesheet" href="Marcasdecarne.css" media="screen">
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
    <meta property="og:title" content="Marcas de carne">
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
                <ul class="u-align-center u-nav u-popupmenu-items u-unstyled u-nav-2"><li class="u-nav-item"><a class="u-button-style u-nav-link" href="Inicio.html">Inicio</a>
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
    <section class="u-align-center u-clearfix u-section-1" id="sec-1e59">
      <div class="u-clearfix u-sheet u-valign-middle u-sheet-1">
        <h1 class="u-align-left u-text u-text-1">Marcas de carne</h1>
      </div>
    </section>
    <section class="u-clearfix u-section-2" id="sec-e1bc">
      <div class="u-clearfix u-sheet u-sheet-1">
        <div class="u-expanded-width u-form u-form-1">
          <form action="https://forms.nicepagesrv.com/Form/Process" class="u-clearfix u-form-spacing-10 u-form-vertical u-inner-form" source="email" name="form" style="padding: 10px;">
            <div class="u-form-group u-form-name">
              <label for="name-6cb0" class="u-label u-label-1">Nombre</label>
              <asp:TextBox ID="TextBox1" runat="server" placeholder="Introduzca el nombre de la marca" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-1" />
            </div>
            <div class="u-form-group u-form-message">
              <label for="message-6cb0" class="u-label u-label-2">Observaciones</label>
              <asp:TextBox ID="TextBox2" runat="server" placeholder="Ingrese una observación" class="u-border-1 u-border-grey-30 u-input u-input-rectangle u-white u-input-2" Columns="50" Rows="4" TextMode="MultiLine" />
            </div>
            <div class="u-align-left u-form-group u-form-submit">
              <asp:Button runat="server" 
                   text="Guardar" class="u-border-none u-btn u-btn-round u-btn-submit u-button-style u-palette-4-base u-radius-6 u-btn-1" OnClick="Button1_Click" />
              <input type="submit" value="submit" class="u-form-control-hidden">
            </div>
            <input type="hidden" value="" name="recaptchaResponse">
            <input type="hidden" name="formServices" value="">
          </form>
        </div>
      </div>
    </section>
    
    
    <footer class="u-align-center u-clearfix u-footer u-grey-80 u-footer" id="sec-2c1a"><div class="u-clearfix u-sheet u-sheet-1">
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
