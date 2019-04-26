<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>



<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctl_ChatOperador.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts.ctl_ChatOperador" %>



 


<script language="javascript" type="text/javascript" >

    function ShowWindow(keyValue) {
        __doPostBack('Open', keyValue);
    }

</script>




<style type="text/css" >
   body
    {
        font: 11px Tahoma,Arial,Helvetiva,sans-serif;
    }
    
    .texto_chat_titulo
    {
        color:#ffffff;
        font: 11pt Tahoma,Arial,Helvetiva,sans-serif;
        font-weight:bold;
    }


    .texto_chat
    {
        color:#ffffff;
        font: 11pt Tahoma,Arial,Helvetiva,sans-serif;

    }
    
    .titBlig
    {
    	
    	padding-left:15px;
    	color:White;
    	text-align:left;
    	font-family:Tahoma,Arial,Helvetiva,sans-serif;
    	vertical-align:middle;    	    	
    	font-size:15pt;
       	height:25px;
       	font-weight:bolder;    	   	
        Width:622px;
    	
    	}
    
</style>


<div style="margin:0;padding:0;color:#ffffff;width:100%;" >

<asp:Timer ID="tAtualizaGrid" runat="server" Interval="1000" 
ontick="tAtualizaGrid_Tick" Enabled="False">
</asp:Timer> 


<table width="100%" cellpadding="0" cellspacing="0"  >
    <tr valign="top">
        <td align="left">
            <table width="100%" cellpadding="0" cellspacing="0"  >
                <tr valign="top">
                     <td style="padding-left:15px;padding-right:10px;padding-top:10px;" align="left" >
                        <table style="width:45%" cellpadding="0" cellspacing="0">
                            <tr valign="top">
                                <td class="titBlig" align="left" >                                            
                                    <asp:Label ID="Label1" runat="server" Text="Chat com: " CssClass="texto_chat_titulo"></asp:Label>
                                    <asp:Label ID="lblUsuario" runat="server" CssClass="texto_chat"></asp:Label>                
                                    &nbsp;&nbsp;&nbsp;&nbsp;                
                                    <asp:Label ID="Label2" runat="server" Text="NOC: " CssClass="texto_chat_titulo"></asp:Label>
                                    <asp:Label ID="lblNoc" runat="server" CssClass="texto_chat"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td >
                                   
                                   
                                                <dx:ASPxListBox ID="lstMsgs" runat="server"  Width="610px" Height="210px"  >
                                                    <ItemStyle Wrap="true" />
                                                </dx:ASPxListBox>
                                            
                                               
                                                 
                                               
                                 
                                 
                                 
                                 
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left" style="padding-top:10px;width:625px">
                                                <table cellpadding="0" cellspacing="0" >
                                                    <tr valign="middle">
                                                        <td >
                                                            <asp:TextBox Id="txtMessage" runat="server" TextMode="MultiLine" Columns="59" 
                                                                Height="72px" />
                                                        </td>                                        
                                                        <td align="left" style="padding-left:10px;">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <dx:ASPxButton ID="btnSend" runat="server" Width="120px" Text="Enviar" 
                                                                         ClientInstanceName="btnSend"
                                                                             OnClick="btnSend_Click" Theme="iOS">
                                                                        </dx:ASPxButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-top:10px">
                                                                        <dx:ASPxButton ID="btnFinalizar" runat="server" Width="120px" Text="Finalizar Chat" 
                                                                           
                                                                       OnClick="btnFinalizar_Click" Theme="iOS">
                                                                            <ClientSideEvents Click="function(s, e) { 
                                                                              e.processOnServer = confirm('Deseja realmente Finalizar o Chat?'); }" />
                                                                        </dx:ASPxButton>                                                 
                                                                    </td>
                                                                </tr>                                            
                                                            </table>
                                                        </td>
                                                    </tr> 
                                                    <tr>
                                                        <td colspan="2" align="right" style="width:625px">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <dx:ASPxButton ID="btnReabir" runat="server" Width="120px" Text="Reabir Chat" 
                                                                            CssFilePath="~/App_Themes/Plastic Blue/{0}/styles.css"  ClientInstanceName="btnReabir"
                                                                            CssPostfix="PlasticBlue" OnClick="btnReabir_Click" Visible="false" >
                                                                            <ClientSideEvents Click="function(s, e) { 
                                                                              e.processOnServer = confirm('Deseja realmente Reabir o Chat?'); }" />
                                                                        </dx:ASPxButton>  
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>                                       
                                                </table>                                                        
                                            </td>
                                        </tr>
                                       
                                    </table>                                             
                                </td>
                            </tr>
                        </table>  
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Timer ID="tVerificaMsgs" runat="server" Interval="5000" Enabled="true" 
                            ontick="tVerificaMsgs_Tick">
                                </asp:Timer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
         </td>
    </tr>                     
</table>



</div>


