<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Index.aspx.cs" Inherits="PDM.View.Index" %>

<!DOCTYPE html>
<html lang="pt-BR">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Página de venda PDM">
    <meta name="author" content="Cristian, Gustavo">

    <title>PDM - Product Development Manager</title>

    <!-- Bootstrap Core CSS -->
    <link href="style/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="style/css/sales_page.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="http://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css">

</head>

<body>

    <!-- Header -->
    <a name="about"></a>
    <div class="intro-header">
        <div class="container">
            <div class="row">
                <div class="col-lg-3"></div>
                <div class="col-lg-6">
                    <div class="intro-message fundo">
                        <h1>PDM</h1>
                        <h3>Gerencie Seus Projetos Em Um Só Lugar</h3>
                        <hr class="intro-divider">
                        <form role="form" runat="server">
                            <ul class="list-inline intro-social-buttons">
                                <li>
                                    <asp:LinkButton ID="btnRegistro" runat="server" OnClick="btnRegistro_Click" CssClass="btn btn-primary btn-lg" Text="Criar Conta"></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="btnLogin" runat="server" OnClick="btnLogin_Click" CssClass="btn btn-success btn-lg" Text="Entrar"></asp:LinkButton>
                                </li>
                            </ul>
                        </form>
                    </div>
                </div>
                <div class="col-lg-3"></div>
            </div>
        </div>
        <!-- /.container -->

    </div>
    <!-- /.intro-header -->

</body>

</html>