<!DOCTYPE html>
<html lang="pt-br">
  <head>
    <title>Guarda Digital</title>
    <meta charset="utf-8">
    <meta content="IE=edge" http-equiv="x-ua-compatible">
    <meta content="initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no" name="viewport">
    <meta content="yes" name="apple-mobile-web-app-capable">
    <meta content="yes" name="apple-touch-fullscreen">

    <!-- Fonts -->
    <link href='https://fonts.googleapis.com/css?family=Raleway:300,400,700' rel='stylesheet' type='text/css'>

    <!-- Icons -->
    <link href="http://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" media="all" rel="stylesheet" type="text/css">

    <!-- Styles -->
    <link href="css/keyframes.css" rel="stylesheet" type="text/css">
    <link href="css/materialize.min.css" rel="stylesheet" type="text/css">
    <link href="css/swiper.css" rel="stylesheet" type="text/css">
    <link href="css/swipebox.min.css" rel="stylesheet" type="text/css">
    <link href="css/style.css" rel="stylesheet" type="text/css">

</head>

  <body>
    <div id="main"> <!-- Main Container -->

      <!-- Sidebar -->
      <ul id="slide-out-left" class="side-nav primary-color collapsible">
        <li>
          <div class="sidenav-header">

          <p class="topo"> <img src="img/logo.png" class="logo-tit" /> <span class="titulo"> Guarda Digital</span></p>

           

            <!-- Avatar -->
            <div class="nav-avatar">
              <img class="circle avatar" src="<%=Request.QueryString("img").ToString() %>" width="400" alt="foto do guarda">
              <div class="avatar-body">
                <h3><%=Request.QueryString("nome").ToString() %></h3>
                <p><%=Request.QueryString("inscricao").ToString() %></p>
              </div>
            </div>
          </div>
        </li>

        <!-- Menu -->
        <li>
          <div class="collapsible-header">
              <img src="img/nova.png" /> <a href="ocorrencia.html">Nova Ocorrência</a>
          </div>
          
        </li>
       
        <li>
          <div class="collapsible-header">
            <img src="img/verifica.png" /> <a href="modalImagem.html">Verificar Vendedor </a>
          </div>
          
        </li>
       
       
        <li>
          <div class="collapsible-header">
              <img src="img/lei.png" /> <a href="leis.html">Legislação</a>   </div>
          
        </li>
        
          </ul>
      <!-- End of Sidebars -->

      <!-- Toolbar -->
      <div id="toolbar" class="primary-color">
        <div class="open-left" id="open-left" data-activates="slide-out-left">
          <i class="ion-android-menu"></i>
        </div>
        <div><a href="http://guarda.digital"><img src="img/logo.png" class="logo-topo" style="float:right;" /></a></div>
      </div>
      <!-- End of Toolbar -->
      
      <!-- Page Contents -->
      <div class="page fullscreen valign-wrapper animated fadeinright">
        
        <div class="valign center-align w-100">
<<<<<<< HEAD:frontend/app/dadosUsuario.html
          <img src="" alt="ImagemUsuario">
          <h3 class="m-0"><strong>Antonio Luis</strong></h3>
          <h6 class="m-0">Validade: 02/10/2020</h6>
          <h6 class="m-0">Endereço: Rua das Esmeraldas LT 42.</h6>
          <h6 class="m-0">O que pode vender: Frutas, Verduras e Legumes.</h6>
=======
         <img src='<%=Request.QueryString("img").ToString()%>' width="700">
          <h3 class="m-0"><strong><%=Request.QueryString("nome").ToString()%></strong></h3>
          <h6 class="m-0">Validade: <%=Request.QueryString("validade").ToString() %></h6>
          <h6 class="m-0">Endereço: <%=Request.QueryString("endereco").ToString() %></h6>
          <h6 class="m-0">O que pode vender: <%=Request.QueryString("poder").ToString() %></h6>
>>>>>>> 84c6a7b4271166645758c3ab39aa587630b68a77:frontend/app/cracha.aspx
          <br>
          <br>
          <br>
          <a class="waves-effect waves-light btn-large primary-color block m-20 animated bouncein delay-4" href="index.html" style="text-align: center;">Voltar</a> 
        </div>

      </div> 
      <!-- End of Page Contents -->

    </div><!-- End of Main Container -->
    
    
    <script src="js/jquery-2.1.0.min.js"></script>
    <script src="js/jquery.swipebox.min.js"></script>   
    <script src="js/materialize.min.js"></script> 
    <script src="js/swiper.min.js"></script>  
    <script src="js/jquery.mixitup.min.js"></script>
    <script src="js/masonry.min.js"></script>
    <script src="js/chart.min.js"></script>
    <script src="js/functions.js"></script>

    <script src="verificar.js"></script>
  </body>
</html>