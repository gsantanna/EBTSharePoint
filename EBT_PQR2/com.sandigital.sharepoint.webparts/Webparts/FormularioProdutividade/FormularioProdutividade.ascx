<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormularioProdutividade.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.FormularioProdutividade.FormularioProdutividade" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>



<div style="width: 100%;">


    <asp:Panel ID="pnlSucesso" runat="server" Visible="false">

        <div id="dvSucesso" class="alert alert-success">
            <br />
            A operação foi concluída com sucesso! 
            <br />
        </div>
    </asp:Panel>


    <asp:Panel ID="pnlFalha" runat="server" Visible="false">

        <div id="dvFalha" class="alert alert-danger">
            <br />
            <strong>
                <asp:Label ID="lblErro" runat="server"></asp:Label>
            </strong>
            <br />
            <br />
        </div>
    </asp:Panel>

    <style type="text/css">
        .tbl {
            border: none;
        }

            .tbl td {
                padding: 5px;
            }
    </style>


    <table style="width: 100%" border="0" class="tbl">

        <tr>
            <td style="width: 110px; white-space: nowrap"><strong>Número da Rec:</strong> </td>
            <td>
                <dx:ASPxTextBox ID="txtRecs" runat="server" Width="100%" AutoResizeWithContainer="true" CssClass="txtbbb" MaxLength="10" HorizontalAlign="Right">
                    <MaskSettings ErrorText="Valor Inválido" Mask="&lt;0..9999999999&gt;" />
                    <ValidationSettings ErrorText="Rec Inválida" SetFocusOnError="True">
                        <RegularExpression ErrorText="Rec Inválida" />
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>

        <tr>
            <td><strong>Causa:</strong> </td>
            <td>
                <asp:DropDownList ID="cboCausa" CssClass="cboCausa" runat="server" Width="100%">
                    <asp:ListItem>-Selecone-</asp:ListItem>
                    <asp:ListItem>Repasse para outras áreas Embratel</asp:ListItem>
                    <asp:ListItem>Falha no equipamento do cliente</asp:ListItem>
                    <asp:ListItem>Repasse para operadora </asp:ListItem>
                    <asp:ListItem>Rec indevida pela NET</asp:ListItem>
                    <asp:ListItem>Testado OK Embratel</asp:ListItem>
                    <asp:ListItem>Fechamento NET</asp:ListItem>
                    <asp:ListItem>Corrigido Embratel</asp:ListItem>
                    <asp:ListItem>Bloqueio Blacklist</asp:ListItem>
                    <asp:ListItem>Visita Técnica</asp:ListItem>
                    <asp:ListItem>Falha massiva - RAL</asp:ListItem>
                    <asp:ListItem>Rec indevida por outros CF's Embratel</asp:ListItem>
                    <asp:ListItem>Aguardando cliente para testes</asp:ListItem>
                    <asp:ListItem>Encerrado após 3 tentativas de contato</asp:ListItem>
                    <asp:ListItem>Retorno de operadora</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr id="trTratamento" style="display: none">
            <td><strong>Tratamento:</strong> </td>
            <td>
                <asp:DropDownList ID="cboTratamento" runat="server" Width="100%">
                    <asp:ListItem>-Selecione-</asp:ListItem>
                    <asp:ListItem>Falha de dígito</asp:ListItem>
                    <asp:ListItem>Discagem incorreta</asp:ListItem>
                    <asp:ListItem>Destino Incorreto com falha</asp:ListItem>
                    <asp:ListItem>Problema de fatura</asp:ListItem>
                    <asp:ListItem>Falta de informação</asp:ListItem>
                    <asp:ListItem>Telefone em pulso</asp:ListItem>
                    <asp:ListItem>Terminal não pertence a NET</asp:ListItem>
                    <asp:ListItem>Terminal possui bloqueios</asp:ListItem>
                    <asp:ListItem>Suspensão temporária</asp:ListItem>
                    <asp:ListItem>Modem Off line</asp:ListItem>
                    <asp:ListItem>Outros</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>

    <div style="float: right; width: 100px; text-align: right">
        <asp:Button ID="btnSalvar" Width="98%" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click" />

    </div>






    <script type="text/javascript" src="/js/jquery.min.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {

            Verifica();

            $(".cboCausa").change(function () {

                Verifica();
            });
        });


        function Verifica() {

            if ($(".cboCausa").val() == "Rec indevida pela NET") {
                $("#trTratamento").show();
            } else {
                $("#trTratamento").hide();
            }

        }


    </script>











</div>

<br />


<a href="Paginas/PainelProdutividade.aspx">Gráficos</a>
<br />
<a href="Paginas/PainelProdutividade_Causa.aspx">Gráficos - Causas</a>
<br />
<a href="Paginas/GridProdutividade.aspx">Relatório Grade</a>
<br />
<a href="Lists/Produtividade/AllItems.aspx">Recs Cadastradas</a>
<br />


