<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="PDM.View.EditarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Editar Usuário</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <h1 class="page-header">Editar Usuário</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="form-group">
                    <label>Nome</label>
                    <input id="nomeUser" type="text" class="form-control" placeholder="Nome" runat="server" />
                </div>
                <div class="form-group">
                    <label>Email</label>
                    <input id="emailUser" type="email" class="form-control" placeholder="Email" runat="server" />
                </div>
                <div class="form-group">
                    <label>Empresa</label>
                    <input id="EmpresaUser" runat="server" type="text" class="form-control" rplaceholder="Empresa" />
                </div>
                <div class="form-group">
                    <label>Senha</label>
                    <input id="senhaUser" class="form-control" type="password" runat="server" />
                </div>
                <div class="form-group">
                    <label>Repita a senha</label>
                    <input id="senha2User" class="form-control" type="password" runat="server" />
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
                <asp:Button ID="btnCadastrar" type="submit" OnClick="btnCadastrar_Click" runat="server" CssClass="btn btn-default" Text="Salvar" />
                <asp:Button ID="btnExcluir" OnClick="btnExcluir_Click" runat="server" CssClass="btn btn-default" Text="Excluir" />
                <asp:Button ID="btnLimpar" type="reset" runat="server" OnClick="btnLimpar_Click" CssClass="btn btn-default" Text="Cancelar" />
            </div>
            <div class="col-xs-2 col-md-2"></div>
        </div>
    </div>
</asp:Content>
