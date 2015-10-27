<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PDM.View.Login" %>

<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>PDM - Login</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="template/bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="template/dist/css/AdminLTE.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="template/plugins/iCheck/square/blue.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
  <body class="hold-transition login-page">

    <div class="login-box">
        <div class="login-logo">
            <img src="template/img/pdm.png" class="img-responsive" alt="PDM">
        </div><!-- /.login-logo -->
        <div class="login-box-body">
            <p class="login-box-msg">Faça login para entrar no sistema</p>
                        <form role="form" runat="server">
                <div class="form-group has-feedback">
                    <input runat="server" type="email" class="form-control" id="email" placeholder="Email" autofocus="autofocus">
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                                </div>
                <div class="form-group has-feedback">
                    <input runat="server" type="password" class="form-control" id="password" placeholder="Senha">
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                                </div>
                <div class="row">
                    <div class="col-xs-8">
                        <div class="checkbox icheck">
                            <label>
                                <input runat="server" type="checkbox"> Lembrar
                            </label>
                        </div>
                    </div><!-- /.col -->
                    <div class="col-xs-4">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Unnamed_Click" class="btn btn-lg btn-success btn-block" Text="Login"></asp:LinkButton>
                    </div><!-- /.col -->
                    <div class="col-xs-8">
                        <asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="~/RecuperarSenha.aspx" Text="Esqueceu sua senha? Clique aqui!"></asp:HyperLink>
                    </div>
                                </div>
                        </form>
        </div><!-- /.login-box-body -->
    </div><!-- /.login-box -->

    <!-- jQuery 2.1.4 -->
    <script src="template/plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="template/bootstrap/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="template/plugins/iCheck/icheck.min.js"></script>
    <script>
      $(function () {
        $('input').iCheck({
          checkboxClass: 'icheckbox_square-blue',
          radioClass: 'iradio_square-blue',
          increaseArea: '20%' // optional
        });
      });
    </script>
</body>
</html>

