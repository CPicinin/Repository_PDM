<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="RealizaTarefa.aspx.cs" Inherits="PDM.View.RealizaTarefa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menuUser" runat="server">
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
                    <input id="txtDataIni" type="date" class="form-control" runat="server" />
                </div>
                <div class="form-group">
                    <label>Prazo (dias)</label>
                    <input id="txtPrazo" type="number" class="form-control" runat="server" />
                </div>
                <div class="form-group">
                    <label>Status</label>
                    <div class="radio">
                        <label>
                            <input id="pendente" type="radio" runat="server" name="optionsRadios1" value="option1" />Pendente
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="emAndamento" type="radio" runat="server" name="optionsRadios2" value="option2" />Em Andamento
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="concluido" type="radio" runat="server" name="optionsRadios3" value="option3" />Concluído
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="cancelado" type="radio" runat="server" name="optionsRadios4" value="option4" />Cancelado
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label>Incluir Item</label>
                    <input id="itemAdd" type="text" class="form-control" runat="server" />
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="btn btn-default" Text="Incluir" />
                </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Tarefas</h1>
                        </div>
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="dataTable_wrapper">
                                        <asp:GridView ID="gridItens" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover">
                                            <Columns>
                                                <asp:BoundField DataField="data" HeaderText="Data" />
                                                <asp:BoundField DataField="descricao" HeaderText="Descrição" />
                                                <asp:HyperLinkField ControlStyle-CssClass="fa fa-pencil fa-fw" DataNavigateUrlFields="excluir" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <div class="row">
                    </div>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnSalvar" OnClick="btnSalvar_Click" runat="server" CssClass="btn btn-default" Text="Salvar" />
                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-default" Text="Cancelar" />
                </div>
                <!-- /#page-wrapper -->
                <!-- jQuery -->
                <script src="bower_components/jquery/dist/jquery.min.js"></script>

                <!-- Bootstrap Core JavaScript -->
                <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>

                <!-- Metis Menu Plugin JavaScript -->
                <script src="bower_components/metisMenu/dist/metisMenu.min.js"></script>

                <!-- Morris Charts JavaScript -->
                <script src="bower_components/raphael/raphael-min.js"></script>
                <script src="bower_components/morrisjs/morris.min.js"></script>
                <script src="js/morris-data.js"></script>

                <!-- Custom Theme JavaScript -->
                <script src="dist/js/sb-admin-2.js"></script>
                <div class="col-xs-4 col-md-4"></div>
</asp:Content>
