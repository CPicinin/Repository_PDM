<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PDM.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PDM - Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Início</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-3 col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-comments fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge">5</div>
                                <div>Mensagens</div>
                            </div>
                        </div>
                    </div>
                    <a href="ConsultaEtapa.aspx">
                        <div class="panel-footer">
                            <span class="pull-left">Ver Detalhes</span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="panel panel-green">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-tasks fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge">3</div>
                                <div>Tarefas</div>
                            </div>
                        </div>
                    </div>
                    <a href="ConsultaTarefas.aspx">
                        <div class="panel-footer">
                            <span class="pull-left"><a href="ConsultaTarefas.aspx">Ver Detalhes</a></span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <!-- /#page-wrapper -->
</asp:Content>

