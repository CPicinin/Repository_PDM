<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="PDM.View.Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PDM - Configurações</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Configurações</h1>
                    <h3>Banco de Dados</h3>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-xs-4 col-md-4"></div>
                <div class="col-xs-4 col-md-4">
                    <form role="form">
                        <div class="form-group">
                            <label>Servidor</label>
                            <asp:TextBox ID="txtServidor" runat="server" class="form-control" placeholder="Servidor" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Instância</label>
                            <asp:TextBox ID="txtInstancia" runat="server" class="form-control" placeholder="Instância" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Usuário</label>
                            <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Usuário" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Senha</label>
                            <asp:TextBox ID="txtSenha" runat="server" class="form-control" type="password" placeholder="Senha" required="required"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" />
                        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
                    </form>
                </div>
                <div class="col-xs-4 col-md-4"></div>
            </div>
        </div>
        <!-- /#page-wrapper -->

    <!-- jQuery -->
    <script src="bower_components/jquery/dist/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="bower_components/metisMenu/dist/metisMenu.min.js"></script>

    <!-- Morris Charts JavaScript -->
    <script src="bower_components/raphael/raphael-min.js"></script>
    <script src="bower_components/morrisjs/morris.min.js"></script>
    <script src="js/morris-data.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="dist/js/sb-admin-2.js"></script>

</asp:Content>
