<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChatNoc.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ChatNoc.ChatNoc" %>





<%@ Register assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>








<script language="javascript" type="text/javascript" >

    function Redireciona(keyValue) {
        location.href = keyValue;

    }


    function ShowWindow(url, keyValue) {


        var janela = window.open(url + '?id_atendimento=' + keyValue, "janela" + keyValue, "width=650,height=350,scrollbars=NO,titlebar=NO")


        if (janela == null) {
            alert('Erro ao abrir o popup, desabilite o bloqueador de popups e tente novamente.');
            janela.close();
            return false;
        } else {
            return true;
        }




    }

</script>


<div class="chatContainer">

    <div class="chatContainerDD">
            <asp:DropDownList runat="server" ID="ddlNoc" CssClass="chatDD"/> 
    </div>
   
    <div class="chatContainerBtn">
            <dx:ASPxButton runat="server" Text="Selecionar"  CssClass="btn btn-primary"  EnableDefaultAppearance="false" ID="btnSelecionar" OnClick="btnSelecionar_Click" />
    </div> 
 </div>

