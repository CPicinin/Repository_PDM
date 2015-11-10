<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="EditaProjeto.aspx.cs" Inherits="PDM.View.EditaProjeto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <h1 class="page-header">Edita Projeto</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="form-group">
                    <label>Título</label>
                    <input id="txtTitulo" type="text" class="form-control" placeholder="Nome" runat="server" />
                </div>
                <div class="form-group">
                    <label>Responsável</label>
                    <asp:DropDownList ID="listaResponsaveis"  runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Tipo de projeto</label>
                    <div class="list-group">
                        <asp:DropDownList ID="listaTipo" DataTextField="Value" DataValueField="key"  runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnCadastrar" type="submit" OnClick="btnCadastrar_Click" runat="server" class="btn btn-default" Text="Salvar" />
                    <asp:Button ID="btnCancela" type="cancel" runat="server" OnClick="btnCancela_Click" class="btn btn-default" Text="Cancelar" />
                    <asp:Button ID="btnrelatorio" runat="server" OnClick="btnGeraRelatorio_Click" CssClass="btn btn-default" Text="Gerar Relatório do Projetos" />
                </div>
                <div class="form-group">
                    <h3>Tarefas do Projeto</h3>
                    <div class="list-group">
                        Filtrar por Etapa:
                        <asp:DropDownList ID="lstEtapa" runat="server"></asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnBuscaTarefas" type="submit" OnClick="btnBuscaTarefas_Click" runat="server" class="btn btn-default" Text="Buscar" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="btnNotificar"  OnClick="btnNotifica_Click" runat="server" class="fa fa-envelope" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="btnAdicionar" CssClass="fa fa-plus" OnClick="btnAdicionar_Click" runat="server"/>
                    </div>
                </div>
                <div class="form-group">
                    <div class="dataTable_wrapper">
                        <asp:GridView ID="gridTarefas" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover">
                            <Columns>
                                <asp:BoundField DataField="Responsavel" HeaderText="Resposável" />
                                <asp:BoundField DataField="DataInicio" HeaderText="Data de Início" />
                                <asp:BoundField DataField="Prazo" HeaderText="Prazo" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:BoundField DataField="Titulo" HeaderText="Título da Tarefa" />
                                <asp:HyperLinkField ControlStyle-CssClass="fa fa-pencil fa-fw" DataNavigateUrlFields="editar" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="col-xs-2 col-md-2"></div>
        </div>
    </div>
</asp:Content>
