<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="CadastraProjeto.aspx.cs" Inherits="PDM.View.CadastraProjeto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PDM - Cadastro de Projeto</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <h1 class="page-header">Novo Projeto</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="form-group">
                    <label>Título</label>
                    <input id="txtTitulo" type="text" class="form-control" placeholder="Nome" runat="server" required="required"/>
                </div>
                <div class="form-group">
                    <label>Responsável</label>
                    <asp:DropDownList ID="listaResponsaveis" runat="server" CssClass="form-control" DataTextField ="Value" DataValueField="Key" ></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Tipo de projeto</label>
                    <div class="list-group">
                            <asp:DropDownList ID="listaTipo" runat="server" CssClass="form-control" DataTextField ="Value" DataValueField="Key"></asp:DropDownList>
                    </div>
                </div>
                <asp:Button ID="btnCadastrar" type="submit" OnClick="btnCadastrar_Click" runat="server" class="btn btn-default" Text="Salvar" />
                <asp:Button ID="btnCancela" type="cancel" runat="server" OnClick="btnCancela_Click" class="btn btn-default" Text="Cancelar" />
            </div>
            <div class="col-xs-2 col-md-2"></div>
        </div>
    </div>
</asp:Content>
