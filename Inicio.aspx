<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SistGestInterna.Inicio" %>

<!DOCTYPE html>
<html style="font-size: 16px;" lang="es"><head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta charset="utf-8">
    <meta name="keywords" content="Inicio">
    <meta name="description" content="">
    <title>Inicio</title>
    <link rel="stylesheet" href="nicepage.css" media="screen">
<link rel="stylesheet" href="Inicio.css" media="screen">
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
    <meta property="og:title" content="Inicio">
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
</li><li class="u-nav-item">
    <asp:Button runat="server" Text="Cerrar Sesión" class="u-button-style u-nav-link" style="padding: 10px;" OnClick="cerrarSesion" />
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
</li><li class="u-nav-item">
    <asp:Button runat="server" class="u-button-style u-nav-link" OnClick="cerrarSesion" />
</li></ul>
              </div>
            </div>
            <div class="u-black u-menu-overlay u-opacity u-opacity-70"></div>
          </div>
        </nav>
      </div></header>
    <section class="u-align-center u-clearfix u-section-1" id="sec-56e3">
      <div class="u-clearfix u-sheet u-valign-middle u-sheet-1">
        <h1 class="u-align-left u-text u-text-default u-text-1">Inicio<br>
        </h1>
      </div>
    </section>
    <section class="u-align-center u-clearfix u-section-2" id="sec-b035">
      <div class="u-clearfix u-sheet u-valign-top u-sheet-1">
        <div class="u-expanded-width u-tab-links-align-justify u-tabs u-tabs-1">
          <ul class="u-border-2 u-border-palette-1-base u-spacing-10 u-tab-list u-unstyled" role="tablist">
            <li class="u-tab-item" role="presentation">
              <a class="active u-active-palette-4-base u-button-style u-grey-10 u-tab-link u-text-active-white u-text-black u-tab-link-1" id="link-tab-0da5" href="#tab-0da5" role="tab" aria-controls="tab-0da5" aria-selected="true">Ingresos</a>
            </li>
            <li class="u-tab-item" role="presentation">
              <a class="u-active-palette-4-base u-button-style u-grey-10 u-tab-link u-text-active-white u-text-black u-tab-link-2" id="link-tab-14b7" href="#tab-14b7" role="tab" aria-controls="tab-14b7" aria-selected="false">Salidas</a>
            </li>
            <li class="u-tab-item" role="presentation">
              <a class="u-active-palette-4-base u-button-style u-grey-10 u-tab-link u-text-active-white u-text-black u-tab-link-3" id="link-tab-2917" href="#tab-2917" role="tab" aria-controls="tab-2917" aria-selected="false">Visores</a>
            </li>
            <li class="u-tab-item u-tab-item-4" role="presentation">
              <a class="u-active-palette-4-base u-button-style u-grey-10 u-tab-link u-text-active-white u-text-black u-tab-link-4" id="tab-93fc" href="#link-tab-93fc" role="tab" aria-controls="link-tab-93fc" aria-selected="false">Clientes</a>
            </li>
          </ul>
          <div class="u-tab-content">
            <div class="u-container-style u-tab-active u-tab-pane u-white u-tab-pane-1" id="tab-0da5" role="tabpanel" aria-labelledby="link-tab-0da5">
              <div class="u-container-layout u-valign-top u-container-layout-1">
                <a href="IngresodeMercaderia.aspx" class="u-border-none u-btn u-btn-round u-button-style u-hover-palette-4-light-1 u-palette-4-base u-radius-6 u-btn-1">Ingreso de Mercaderías</a>
                <a href="Inventario.aspx" class="u-border-none u-btn u-btn-round u-button-style u-hover-palette-4-light-1 u-palette-4-base u-radius-6 u-btn-2">Para Hacer el Inventario</a>
              </div>
            </div>
            <div class="u-container-style u-tab-pane u-white u-tab-pane-2" id="tab-14b7" role="tabpanel" aria-labelledby="link-tab-14b7">
              <div class="u-container-layout u-valign-top u-container-layout-2">
                <a href="Error404.aspx" class="u-border-none u-btn u-btn-round u-button-style u-hover-palette-4-light-1 u-palette-4-base u-radius-6 u-btn-3">Pedidos<br>
                </a>
                <a href="Error404.aspx" class="u-btn u-btn-round u-button-style u-hover-palette-4-light-1 u-palette-4-base u-radius-6 u-btn-4" data-animation-name="" data-animation-duration="0" data-animation-delay="0" data-animation-direction="">Pedidos eliminados</a>
                <a href="Error404.aspx" class="u-btn u-btn-round u-button-style u-hover-palette-4-light-1 u-palette-4-base u-radius-6 u-btn-5" data-animation-name="" data-animation-duration="0" data-animation-delay="0" data-animation-direction="">Reservas</a>
              </div>
            </div>
            <div class="u-container-style u-tab-pane u-white u-tab-pane-3" id="tab-2917" role="tabpanel" aria-labelledby="link-tab-2917">
              <div class="u-container-layout u-container-layout-3">
                <a href="Error404.aspx" class="u-border-none u-btn u-btn-round u-button-style u-hover-palette-4-light-1 u-palette-4-base u-radius-6 u-btn-6">Visor de pedidos<br>
                </a>
              </div>
            </div>
            <div class="u-container-style u-tab-pane u-white u-tab-pane-4" id="link-tab-93fc" role="tabpanel" aria-labelledby="tab-93fc">
              <div class="u-container-layout u-valign-top u-container-layout-4">
                <a href="Error404.aspx" class="u-border-none u-btn u-btn-round u-button-style u-hover-palette-4-light-1 u-palette-4-base u-radius-6 u-btn-7">Clientes<br>
                </a>
                <a href="Proveedores.aspx" class="u-border-none u-btn u-btn-round u-button-style u-hover-palette-4-light-1 u-palette-4-base u-radius-6 u-btn-8">Proveedores<br>
                </a>
                <a href="Marcasdecarne.aspx" class="u-border-none u-btn u-btn-round u-button-style u-hover-palette-4-light-1 u-palette-4-base u-radius-6 u-btn-9">Marcas de carne<br>
                </a>
              </div>
            </div>
          </div>
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