<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="CasdastraMensagem.aspx.cs" Inherits="PDM.View.CasdastraMensagem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menuUser" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Nova Etapa</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-xs-4 col-md-4"></div>
            <div class="col-xs-4 col-md-4">
                <div class="form-group">
                    <label>Destinatário</label>
                    <asp:DropDownList ID="listaUsuarios" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Mensagem</label>
                    <input id="txtmensagem" type="text" class="form-control" placeholder="Mensagem" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnCadastrar" type="submit" OnClick="btnCadastrar_Click" runat="server" CssClass="btn btn-default" Text="Salvar" />
                    <asp:Button ID="btnCancela" type="cancel" runat="server" OnClick="btnCancela_Click" CssClass="btn btn-default" Text="Cancelar" />
                </div>
            </div>
            <div class="col-xs-4 col-md-4"></div>
        </div>
    </div>
</asp:Content>
