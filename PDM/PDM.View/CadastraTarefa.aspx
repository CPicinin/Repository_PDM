﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="CadastraTarefa.aspx.cs" Inherits="PDM.View.CadastraTarefa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <h1 class="page-header">Nova Tarefa</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="form-group">
                    <label>Etapa</label>
                    <asp:DropDownList ID="ListaEtapas" class="form-control" runat="server" DataTextField="Value" DataValueField="Key"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Responsável</label>
                    <asp:DropDownList ID="listaResponsaveis" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Título</label>
                    <input id="txtTitulo" type="text" class="form-control" placeholder="Nome" runat="server" required="required"/>
                </div>
                <div class="form-group">
                    <label>Data de Início</label>
                    <input id="txtDataIni" type="date" class="form-control" runat="server" required="required"/>
                </div>
                <div class="form-group">
                    <label>Prazo (dias)</label>
                    <input id="txtPrazo" type="number" class="form-control" runat="server" required="required"/>
                </div>
                <div class="form-group">
                    <label>Status</label>
                    <div class="radio">
                        <label>
                            <input id="pendente" type="radio" runat="server" name="optionsRadios" value="option1" />Pendente
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="emAndamento" type="radio" runat="server" name="optionsRadios" value="option2" />Em Andamento
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="concluido" type="radio" runat="server" name="optionsRadios" value="option3" />Concluído
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="cancelado" type="radio" runat="server" name="optionsRadios" value="option4" />Cancelado
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label>Observação</label>
                    <input id="txtObservacao" type="text" class="form-control" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnCadastrar" type="submit" OnClick="btnCadastrar_Click" runat="server" class="btn btn-default" Text="Salvar" />
                    <asp:LinkButton ID="btnCancela" runat="server" OnClick="btnCancela_Click" class="btn btn-default" Text="Cancelar" />
                </div>
            </div>
            <div class="col-xs-2 col-md-2"></div>
        </div>
    </div>
</asp:Content>
