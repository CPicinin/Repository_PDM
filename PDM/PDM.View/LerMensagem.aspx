﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="LerMensagem.aspx.cs" Inherits="PDM.View.LerMensagem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <h1 class="page-header">Mensagem</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="form-group">
                    <label>Data de envio:</label><br />
                    <asp:Label id="txtDataEnvio" runat="server" />
                </div>
                <div class="form-group">
                    <label>Email Remetente</label><br />
                    <asp:Label id="txtemail" runat="server" />
                </div>
                <div class="form-group">
                    <label>Nome do Remetente</label><br />
                    <asp:Label id="txtNome" runat="server" />
                </div>
                <div class="form-group">
                    <label>Mensagem</label><br />
                    <asp:Label id="txtmensagem" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnLida" type="submit" OnClick="btnLida_Click" runat="server" CssClass="btn btn-default" Text="Marcar como Lida" />
                    <asp:Button ID="btnCancela" type="cancel" runat="server" OnClick="btnCancela_Click" CssClass="btn btn-default" Text="Cancelar" />
                </div>
            </div>
            <div class="col-xs-4 col-md-4"></div>
        </div>
    </div>
</asp:Content>
