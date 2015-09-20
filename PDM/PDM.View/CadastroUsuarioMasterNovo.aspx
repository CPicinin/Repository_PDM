<%@ Page Title="" Language="C#" MasterPageFile="~/PDMWithoutNavigationLeft.Master" AutoEventWireup="true" CodeBehind="CadastroUsuarioMasterNovo.aspx.cs" EnableEventValidation="false" Inherits="PDM.View.CadastroUsuarioMasterNovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
            <div class="col-xs-3 col-md-3"></div>
            <div class="col-lg-6">
                <h1 class="page-header">Cadastro</h1>
                <h3>Criar uma nova Conta de teste no PDM</h3>
            </div>
            <div class="col-xs-3 col-md-3"></div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-xs-4 col-md-4"></div>
            <div class="col-xs-4 col-md-4">
                <form role="form">
                    <div class="form-group">
                        <label>Email</label>
                        <input id="email" runat="server" class="form-control" required="required" type="email" placeholder="email"/>
                    </div>
                    <div class="form-group">
                        <label>Senha</label>
                        <input id="senha" runat="server" class="form-control" placeholder="senha" required="required" type="password"/>
                    </div>
                    <div class="form-group">
                        <label>Nome</label>
                        <input id="nome" runat="server" class="form-control" required="required" placeholder="nome"/>
                    </div>
                    <div></div>
                    <div class="form-group">
                        <h4>Dados da Empresa</h4>
                    </div>
                    <div class="form-group">
                        <label>CNPJ</label>
                        <input id="cnpj" runat="server" class="form-control" required="required" placeholder="cnpj"/>
                    </div>
                    <div class="form-group">
                        <label>Razão Social</label>
                        <input id="razao" runat="server" class="form-control" required="required" placeholder="razão"/>
                    </div>
                    <div class="form-group">
                        <label>Email Principal</label>
                        <input id="emailEmpresa" runat="server" class="form-control" required="required" type="email" placeholder="email"/>
                    </div>
                    <asp:Button ID="btnCadastrar" CssClass="btn btn-default" Text="Cadastrar" runat="server" OnClick="btnCadastrar_Click" />
                </form>
            </div>
            <div class="col-xs-4 col-md-4"></div>
        </div>
    <!-- /#page-wrapper -->
</asp:Content>
