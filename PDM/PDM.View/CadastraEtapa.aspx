﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="CadastraEtapa.aspx.cs" Inherits="PDM.View.CadastraEtapa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <h1 class="page-header">Nova Etapa</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="form-group">
                    <label>Nome da Etapa</label>
                    <input id="txtNome" type="text" class="form-control" placeholder="Nome" runat="server" required="required"/>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnCadastrar" type="submit" OnClick="btnCadastrar_Click" runat="server" CssClass="btn btn-default" Text="Salvar" />
                    <asp:LinkButton ID="btnCancela" runat="server" OnClick="btnCancela_Click" CssClass="btn btn-default" Text="Cancelar" />
                </div>
            </div>
            <div class="col-xs-4 col-md-4"></div>
        </div>
    </div>
</asp:Content>
