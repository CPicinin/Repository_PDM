<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="EditaEtapa.aspx.cs" Inherits="PDM.View.EditaEtapa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menuUser" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Editar Etapa</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-xs-4 col-md-4"></div>
            <div class="col-xs-4 col-md-4">
                <div class="form-group">
                    <label>Descrição</label>
                    <input id="txtTitulo" type="text" class="form-control" placeholder="Titulo" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnSalvar" type="submit" OnClick="btnSalvar_Click" runat="server" CssClass="btn btn-default" Text="Salvar" />
                    <asp:Button ID="btnExcluir" OnClick="btnExcluir_Click" runat="server" CssClass="btn btn-default" Text="Excluir" />
                    <asp:Button ID="btnCancelar" type="reset" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-default" Text="Cancelar" />
                </div>
            </div>
            <div class="col-xs-4 col-md-4"></div>
</asp:Content>
