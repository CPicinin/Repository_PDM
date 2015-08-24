<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="CadastroUsuarioMasterNovo.aspx.cs" Inherits="PDM.View.CadastroUsuarioMasterNovo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menuUser" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Cadastro</h1>
                    <h3>Cadastro Alpha que cria usuário master e empresa novos</h3>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-xs-4 col-md-4"></div>
                <div class="col-xs-4 col-md-4">
                    <form role="form">
                        <div class="form-group">
                            <label>Email</label>
                            <input class="form-control" placeholder="email">
                        </div>
                        <div class="form-group">
                            <label>Senha</label>
                            <input class="form-control" placeholder="senha" type="password">
                        </div>
                        <div class="form-group">
                            <label>Empresa</label>
                            <input class="form-control" placeholder="empresa">
                        </div>
                        <button type="submit" class="btn btn-default">Cadastrar</button>
                    </form>
                </div>
                <div class="col-xs-4 col-md-4"></div>
            </div>
        </div>
        <!-- /#page-wrapper -->
</asp:Content>
