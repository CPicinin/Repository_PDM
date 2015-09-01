<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="ConsultaUsuario.aspx.cs" Inherits="PDM.View.ConsultaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PDM - Consulta de Usuários</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menuUser" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Usuários</h1>
            </div>
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="dataTable_wrapper">
                            <asp:GridView ID="gridUsuarios" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover" >
                                <Columns>
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                                    <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
                                    <asp:BoundField DataField="Licença" HeaderText="Validade da Licença" />
                                    <asp:HyperLinkField ControlStyle-CssClass="fa fa-pencil fa-fw" DataNavigateUrlFields="editar" />
                                </Columns>
                            </asp:GridView>
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
        <!-- /#page-wrapper -->

    </div>
    <!-- /#wrapper -->

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

</asp:Content>
