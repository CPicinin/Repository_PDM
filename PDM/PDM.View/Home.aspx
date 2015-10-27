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
                <div class="panel panel-green">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-tasks fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge"><asp:Label ID="lblQntTarefas" runat="server" Text="0"></asp:Label></div>
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
            <div class="col-lg-3 col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-comments fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge"><asp:Label ID="lblMensagens" runat="server" Text="0"></asp:Label></div>
                                <div>Mensagens</div>
                            </div>
                        </div>
                    </div>
                    <a href="#">
                        <div class="panel-footer">
                            <span class="pull-left"><a href="ConsultaMensagens.aspx">Ver Detalhes</a></span>
                            <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                            <div class="clearfix"></div>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-lg-6 col-md-6">
                <div class="panel body">
                    <div class="dataTable_wrapper">
                        <table border="1" bordercolor="#FFA500">
                            <tr>
                                <td colspan="4" style="background-color:#FFA500;padding:5px;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label runat="server" id="lblloka" Text="Resumo dos Projetos de Sua Empresa" ForeColor="White" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding:3px;">Quantidade de Projetos</td>
                                <td style="padding:3px;"><asp:Label ID="lblQntProj" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="padding:3px;">Percentual de Projetos Concluídos e Cancelados</td>
                                <td style="padding:3px;"><asp:Label ID="lblProjFim" runat="server"></asp:Label>%</td>
                            </tr>
                            <tr>
                                <td style="padding:3px;">Percentual de Projetos Em Andamento e Pendentes</td>
                                <td style="padding:3px;"><asp:Label ID="lblProjPendente" runat="server"></asp:Label>%</td>
                            </tr>
                            <tr>
                                <td style="padding:3px;">Quantidade Total de Tarefas da sua Empresa</td>
                                <td style="padding:3px;"><asp:Label ID="lblTotalTarefas" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="padding:3px;">Quantidade de Tarefas Abertas e Pendentes</td>
                                <td style="padding:3px;"><asp:Label ID="lblTarefaTotal" runat="server"></asp:Label>%</td>
                            </tr>
                            <tr>
                                <td style="padding:3px;">Quantidade de Tarefas Concluídas e Canceladas</td>
                                <td style="padding:3px;"><asp:Label ID="lblTarefaExec" runat="server"></asp:Label>%</td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /#page-wrapper -->
</asp:Content>

