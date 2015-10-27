<%@ Page Title="" Language="C#" MasterPageFile="~/PDMWithoutNavigationLeft.Master" AutoEventWireup="true" CodeBehind="CadastroUsuarioMasterNovo.aspx.cs" EnableEventValidation="false" Inherits="PDM.View.CadastroUsuarioMasterNovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
            <div class="col-xs-5 col-md-5"></div>
            <div class="col-lg-2">
               <img src="template/img/pdm.png" class="img-responsive" alt="PDM" width="200px" height="100px">
                </div>
            <div class="col-xs-5 col-md-5"></div>
        </div>
    <br />
        <div class="row">
            <div class="col-xs-4 col-md-4"></div>
            <div class="col-lg-4">
                <p class="login-box-msg">Registre uma nova conta</p>
            </div>
            <div class="col-xs-4 col-md-4"></div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-xs-4 col-md-4"></div>
            <div class="col-xs-4 col-md-4">
                <form role="form">
                    <div class="box box-primary">
                    <div class="form-group has-feedback">
                        <input id="email" runat="server" type="email" class="form-control" placeholder="Email" required="required">
                        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <input id="senha" runat="server" type="password" required="required" class="form-control" placeholder="Password">
                        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                    </div>
                        <div class="form-group has-feedback">
                            <input type="text" class="form-control" placeholder="Nome Completo" id="nome" runat="server">
                            <span class="glyphicon glyphicon-user form-control-feedback"></span>
                        </div>
                    <div></div> 
                    <div class="form-group">
                        <h4>Dados da Empresa</h4>
                    </div>
                        <div class="form-group has-feedback">
                            <input id="cnpj" runat="server" required="required" type="text" class="form-control" placeholder="CNPJ">
                            <span class="form-control-feedback"></span>
                        </div>
                        <div class="form-group has-feedback">
                            <input id="razao" runat="server" required="required" type="text" class="form-control" placeholder="Razão Social">
                            <span class="form-control-feedback"></span>
                        </div>
                        <div class="form-group has-feedback">
                            <input id="emailEmpresa" runat="server" required="required" type="text" class="form-control" placeholder="Email Principal">
                            <span class="form-control-feedback"></span>
                        </div>
                    
                    <asp:Button ID="btnCadastrar" CssClass="btn btn-primary" Text="Cadastrar" runat="server" OnClick="btnCadastrar_Click" />
                </div>
                        </form>
            </div>
            <div class="col-xs-4 col-md-4"></div>
        </div>
    <!-- /#page-wrapper -->
</asp:Content>
