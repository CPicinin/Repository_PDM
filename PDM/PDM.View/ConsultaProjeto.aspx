﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="ConsultaProjeto.aspx.cs" Inherits="PDM.View.ConsultaProjeto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <h1 class="page-header">Projetos</h1>
                <div class="box-header">
                  <div class="box-tools">
                    <div class="input-group" style="width: 150px;">
                        <a class="btn btn-block btn-primary pull-right" href="CadastraProjeto.aspx">Novo</a>
                    </div>
                  </div>
                </div><!-- /.box-header -->
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="panel panel-default">
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="dataTable_wrapper">
                            <asp:GridView ID="gridProjetos" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover">
                                <Columns>
                                    <asp:BoundField DataField="numero" HeaderText="Número" />
                                    <asp:BoundField DataField="titulo" HeaderText="Título" />
                                    <asp:BoundField DataField="responsavel" HeaderText="Responsável" />
                                    <asp:BoundField DataField="dataAbertura" HeaderText="Data de Abertura" />
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
