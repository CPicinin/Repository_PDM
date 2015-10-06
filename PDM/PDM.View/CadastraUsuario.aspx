<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="CadastraUsuario.aspx.cs" EnableEventValidation="false" Inherits="PDM.View.CadastraUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PDM - Cadastro de Usuário</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menuUser" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Novo Usuário</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-xs-2 col-md-2"></div>
            <div class="col-xs-8 col-md-8">
                <div class="form-group">
                    <label>Nome</label>
                    <input id="nomeUser" type="text" class="form-control" placeholder="Nome" required="required" runat="server" />
                </div>
                <div class="form-group">
                    <label>Email</label>
                    <input id="emailUser" type="email" class="form-control" placeholder="Email" required="required" runat="server" />
                </div>
                <div class="form-group">
                    <label>Empresa</label>
                    <input id="EmpresaUser" runat="server" type="text" class="form-control" required="required" placeholder="Empresa" />
                </div>
                <div class="form-group">
                    <label>Senha</label>
                    <input id="senhaUser" class="form-control" type="password" required="required" runat="server" />
                </div>
                <div class="form-group">
                    <label>Repita a senha</label>
                    <input id="senha2User" class="form-control" type="password" required="required" runat="server" />
                </div>
                <div class="form-group">
                    <label>Administrador</label>
                    <div class="radio">
                        <label>
                            <input id="admSim" type="radio" runat="server" name="optionsRadios" value="option1" />Sim
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="admNao" type="radio" runat="server" name="optionsRadios" value="option2" />Não
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label>Ativo</label>
                    <div class="radio">
                        <label>
                            <input id="ativoSim" type="radio" runat="server" name="optionsRadios2" value="option3" />Sim
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="AtivoNao" type="radio" runat="server" name="optionsRadios2" value="option4" />Não
                        </label>
                    </div>
                </div>
                <asp:Button ID="btnCadastrar" type="submit" OnClick="btnCadastrar_Click" runat="server" class="btn btn-default" Text="Cadastrar" />
                <asp:Button ID="btnLimpar" type="reset" runat="server" OnClick="btnLimpar_Click" class="btn btn-default" Text="Limpar" />
            </div>
            <div class="col-xs-2 col-md-2"></div>
        </div>
    </div>
</asp:Content>
