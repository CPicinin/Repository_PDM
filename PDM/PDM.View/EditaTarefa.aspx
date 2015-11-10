<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="EditaTarefa.aspx.cs" Inherits="PDM.View.EditaTarefa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <h1 class="page-header">Editar Tarefa</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="form-group">
                    <label>Etapa</label>
                    <asp:DropDownList ID="listaEtapas" class="form-control" runat="server" />
                </div>
                <div class="form-group">
                    <label>Responsável</label>
                    <asp:DropDownList ID="listaResponsaveis" class="form-control" runat="server" />
                </div>
                <div class="form-group">
                    <label>Título</label>
                    <input id="txtTitulo" type="text" class="form-control" placeholder="Titulo" runat="server" />
                </div>
                <div class="form-group">
                    <label>Data de Início</label>
                    <input id="txtDataIni" type="text" class="form-control" runat="server" />
                </div>
                <div class="form-group">
                    <label>Prazo (dias)</label>
                    <input id="txtPrazo" type="number" class="form-control" runat="server" />
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
                            <input id="emAndamento" type="radio" runat="server" name="optionsRadios" value="option1" />Em Andamento
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="concluido" type="radio" runat="server" name="optionsRadios" value="option1" />Concluído
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="cancelado" type="radio" runat="server" name="optionsRadios" value="option1" />Cancelado
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnSalvar" type="submit" OnClick="btnSalvar_Click" runat="server" CssClass="btn btn-default" Text="Salvar" />
                    <asp:Button ID="btnExcluir" OnClick="btnExcluir_Click" runat="server" CssClass="btn btn-default" Text="Excluir" />
                    <asp:Button ID="btnCancelar" type="reset" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-default" Text="Cancelar" />
                </div>
            </div>
            <div class="col-xs-2 col-md-2"></div>
</asp:Content>
