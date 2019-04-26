<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GeradorDeAtas.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.GeradorDeAtas.GeradorDeAtas" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


   

<table  style="width:100%">
    <tr>

        <td style="padding-right:10px;width:40px;">Reunião:</td>

        <td style="padding-right:10px;">
            <dx:ASPxComboBox  runat="server" ID="cboDataReuniao"  TextField="dt_evento"  width="100%"  ValueField="ID" ValueType="System.Int32" />

        </td>

        <td style="width:40px;">
            
            <asp:Button ID="btnGerar" runat="server" Text="Gerar Ata" CssClass="btn-small btn-primary" OnClick="btnGerar_Click" /> 

        </td>

    </tr>

</table>



<p>
    &nbsp;</p>


<asp:Panel runat="server" ID="pnlResultado" Visible="false">
<div id="resultadoGeradorAtas" class="alert alert-success">

    <p>
    <asp:Label ID="lblResultado" runat="server" Text="Ata gerada com sucesso! Deseja enviar aos participantes automaticamente?">

    </asp:Label>

    </p>
 
   

</div>
    
 <asp:LinkButton ID="btnEnviarEmail" runat="server" CssClass="btn btn-primary" Text="Enviar" OnClick="btnEnviarEmail_Click"  />

    <asp:HyperLink ID="btnVisualizar" runat="server" CssClass="btn btn-primary" Text="Visualizar" />
  

</asp:Panel>


<asp:Panel ID="pnlErro" runat="server" Visible="false" >
    <div class="alert alert-danger" role="alert">
        <asp:Label ID="lblErro" runat="server" ></asp:Label>
    </div>
</asp:Panel>
