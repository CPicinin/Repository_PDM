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
                                    <asp:BoundField DataField="email" HeaderText="Email" />
                                    <asp:BoundField DataField="nome" HeaderText="Nome" />
                                    <asp:BoundField DataField="empresa" HeaderText="Empresa" />
                                    <asp:BoundField DataField="licenca" HeaderText="Validade da Licença" />
                                    <asp:HyperLinkField ControlStyle-CssClass="fa fa-search-plus fa-fw" />
                                    <asp:HyperLinkField ControlStyle-CssClass="fa fa-pencil fa-fw" />
                                    <asp:HyperLinkField ControlStyle-CssClass="fa fa-trash-o fa-fw" />
                                </Columns>
                            </asp:GridView>
                            <!-- <table id="tabelaUsuarios" class="table table-striped table-bordered table-hover" runat="server">
                                    <thead>
                                        <tr>
                                            <th>Email</th>
                                            <th>Nome</th>
                                            <th>Empresa</th>
                                            <th>Tipo</th>
                                            <th>Validade da Licença</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr class="odd gradeX">
                                            <td><label id="lblEmail" runat="server"></label></td>
                                            <td><label id="lblNome" runat="server"></label></td>
                                            <td><label id="lblEmpresa" runat="server"></label></td>
                                            <td><label id="lblTipo" runat="server"></label></td>
                                            <td><label id="lblDataLicenca" runat="server"></label></td>
                                            <td><a href="#"><i class="fa fa-search-plus fa-fw"></i></a><a href="#"><i class="fa fa-pencil fa-fw"></i></a><a href="#"><i class="fa fa-trash-o fa-fw"></i></a></td>
                                        </tr>

                                    </tbody>
                                </table>-->
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
