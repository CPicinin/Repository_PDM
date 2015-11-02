<%@ Page Title="" Language="C#" MasterPageFile="~/PDM.Master" AutoEventWireup="true" CodeBehind="CadastraTerceiro.aspx.cs" Inherits="PDM.View.CadatraTerceiro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>PDM - Cadastro de Terceiros</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Novo Terceiro</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-xs-2 col-md-2"></div>
            <div class="col-xs-8 col-md-8">
                <div class="form-group">
                    <label>Nome</label>
                    <input id="txtNome" type="text" class="form-control" placeholder="Nome" runat="server" />
                </div>
                <div class="form-group">
                    <label>Email</label>
                    <input id="txtEmail" type="email" class="form-control" placeholder="Email"  runat="server" />
                </div>
                <div class="form-group">
                    <label>Tipo</label>
                    <div class="radio">
                        <label>
                            <input id="radioPessoaFisica" type="radio" runat="server" name="optionsRadios" value="option1" />Pessoa Física
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="radioPessoaJuridica" type="radio" runat="server" name="optionsRadios" value="option2" />Pessoa Jurídica
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label>Telefone</label>
                    <input id="txtTelefone" class="form-control" type="text" runat="server" />
                </div>
                <div class="form-group">
                    <label>Tipo</label>
                    <div class="radio">
                        <label>
                            <input id="radioCliente" type="radio" runat="server" name="optionsRadios" value="Cliente" />Cliente
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="radioFornecedor" type="radio" runat="server" name="optionsRadios" value="Fornecedor" />Fornecedor
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label>CPF/CNPJ</label>
                    <input id="cpfCnpj" type="text" class="form-control" placeholder="CPF - CNPJ" runat="server" />
                </div>
                <div class="form-group">
                    <label>Ativo</label>
                    <div class="radio">
                        <label>
                            <input id="ativoSim" type="radio" runat="server" name="optionsRadios2" value="option3" />Sim
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input id="AtivoNao" type="radio" runat="server" name="optionsRadios2" value="option4" />Não
                        </label>
                    </div>
                </div>
                <asp:Button ID="btnCadastrar" type="submit" OnClick="btnCadastrar_Click" runat="server" class="btn btn-default" Text="Cadastrar" />
                <asp:Button ID="btnLimpar" type="reset" runat="server" OnClick="btnLimpar_Click" class="btn btn-default" Text="Limpar" />
            </div>
            <div class="col-xs-2 col-md-2"></div>
        </div>
    </div>
</asp:Content>
