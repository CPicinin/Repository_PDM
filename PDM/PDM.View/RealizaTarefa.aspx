<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="RealizaTarefa.aspx.cs" Inherits="PDM.View.RealizaTarefa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Realizar Tarefa</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-xs-4 col-md-4"></div>
            <div class="col-xs-4 col-md-4">
                <table>
                    <tr>
                        <td><label>Etapa: </label></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td><asp:Label ID="lblEtapa" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>Título: </label></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td><asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>Data de Início: </label></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td><asp:Label ID="lblDtIni" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>Prazo (dias): </label></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td><asp:Label ID="lblPrazo" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td><label>Status: </label></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td><asp:Label ID="lblStatus" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
                <div class="form-group">
                    <label><h3>Adicionar Registros</h3></label>
                    <asp:TextBox id="txtItem" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="btn btn-default" Text="Incluir" />
                </div>
                <div class="form-group">
                    <div class="dataTable_wrapper">
                        <asp:GridView ID="gridItens" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover">
                            <Columns>
                                <asp:BoundField DataField="data" HeaderText="Data" />
                                <asp:BoundField DataField="descricao" HeaderText="Descrição" />
                                <asp:HyperLinkField ControlStyle-CssClass="fa fa-close " DataNavigateUrlFields="excluir" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnFinalizar" OnClick="btnFinalizar_Click" runat="server" CssClass="btn btn-default" Text="Finalizar Tarefa" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancelar" type="reset" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-default" Text="Cancelar Tarefa" />
                    &nbsp;&nbsp;
                     <asp:Button ID="btnVoltar" OnClick="btnVoltar_Click" runat="server" CssClass="btn btn-default" Text="Voltar" />
                </div>
            </div>
    <div class="col-xs-4 col-md-4"></div>
</asp:Content>
