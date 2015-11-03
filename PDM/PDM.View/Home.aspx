<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PDM.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PDM - Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <h1 class="page-header">Início</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
              <div class="box">
                <div class="box-header with-border">
                  <h3 class="box-title">Resumo de seus projetos</h3>
                </div><!-- /.box-header -->
                <div class="box-body table-responsive no-padding">
                  <table class="table table-bordered">
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
                                <td style="padding:3px;">Percentual de Tarefas Abertas e Pendentes</td>
                                <td style="padding:3px;"><asp:Label ID="lblTarefaTotal" runat="server"></asp:Label>%</td>
                            </tr>
                            <tr>
                                <td style="padding:3px;">Percentual de Tarefas Concluídas e Canceladas</td>
                                <td style="padding:3px;"><asp:Label ID="lblTarefaExec" runat="server"></asp:Label>%</td>
                            </tr>
                  </table>
                </div><!-- /.box-body -->
              </div><!-- /.box -->
            </div>
        </div>
    </div>
    <!-- /#page-wrapper -->
</asp:Content>

