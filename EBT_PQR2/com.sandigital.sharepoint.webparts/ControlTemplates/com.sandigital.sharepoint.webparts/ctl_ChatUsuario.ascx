<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctl_ChatUsuario.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts.ctl_ChatUsuario" %>




<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxe" %>








<style type="text/css" >

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
    
    body
    {
        font: 11px Tahoma,Arial,Helvetiva,sans-serif;
    }
    
   .titBlig
    {
    	
    	padding-left:15px;
    	background-image: url("/App_Themes/Plastic%20Blue/GridView/gvHeaderBackground.gif");    	
    	color:White;
    	text-align:left;   
	    font-family: Tahoma,Arial,Helvetiva,sans-serif;
    	vertical-align:middle;    	    	
    	font-size:13px;
       	height:25px;
       	font-weight:bolder;    	   	
        Width:622px;  	   	
    	
    	}


 </style>
 
<asp:HiddenField ID="HField" runat="server" />



                                              
                                              

<div style="background:#dedfde;margin:0;padding:0;">
<table cellpadding="0" cellspacing="0" style="width:100%;background:#dedfde;color:#ffffff;" >
    <tr valign="top">
        <td align="left" >                 
            <table width="100%" cellpadding="0" cellspacing="0" >
                <tr valign="top">
                    <td align="left" >
                    <asp:Timer ID="tAtualizaGrid" runat="server" Interval="1000" 
                        ontick="tAtualizaGrid_Tick" Enabled="False">
                        </asp:Timer>
                        <table width="100%" cellpadding="0" cellspacing="0" style="color:#ffffff;" >
                            <tr valign="top">
                                <td style="padding-left:15px;padding-right:10px;padding-top:10px;" align="left" >
                                    <table style="width:45%" cellpadding="0" cellspacing="0">
                                        <tr valign="top">
                                            <td class="titBlig" align="left" >                                            
                                                &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Chat com: " CssClass="texto_chat_titulo" ></asp:Label>
                                                <asp:Label ID="lblNoc" runat="server" CssClass="texto_chat"></asp:Label>                
                                                &nbsp;&nbsp;&nbsp;&nbsp;                
                                                <asp:Label ID="Label2" runat="server" Text="Operador: " CssClass="texto_chat_titulo"></asp:Label>
                                                <asp:Label ID="lblOperador" runat="server" CssClass="texto_chat"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td  >                                                                                                             
                                              
                                             
          
                                                  <dxe:ASPxListBox ID="lstMsgs" runat="server"  Width="100%" Height="210px" 
                                                  >
                                                    <ItemStyle Wrap="true" />
                                                </dxe:ASPxListBox>
                                            
                                               
                                               
                                              
                                             
                                     
                                               
                                               
                                                <table border="0" cellpadding="0" cellspacing="0" >
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
                                                                                    <dxe:ASPxButton ID="btnSend" runat="server" Width="120px" Text="Enviar" 
                                                                                       OnClick="btnSend_Click" Theme="iOS">
                                                                                    </dxe:ASPxButton>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding-top:10px">
                                                                                    <dxe:ASPxButton ID="btnFinalizar" runat="server" Width="120px" Text="Finalizar Chat" 
                                                                                        ClientInstanceName="btnFinalizar"
                                                                                        OnClick="btnFinalizar_Click" Theme="iOS">
                                                                                        <ClientSideEvents Click="function(s, e) { 
                                                                                          e.processOnServer = confirm('Deseja realmente Finalizar o Chat?'); }" />
                                                                                    </dxe:ASPxButton>                                                 
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
                                                                                    <dxe:ASPxButton ID="btnReabir" runat="server" Width="120px" Text="Reabrir Chat" 
                                                                                        CssFilePath="~/App_Themes/Plastic Blue/{0}/styles.css" ClientInstanceName="btnReabir"
                                                                                        CssPostfix="PlasticBlue" OnClick="btnReabir_Click" Visible="false" >
                                                                                        <ClientSideEvents Click="function(s, e) { 
                                                                                          e.processOnServer = confirm('Deseja realmente Reabrir o Chat?'); }" />
                                                                                    </dxe:ASPxButton>  
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
                                            <asp:Timer ID="tVerificaMsgs" runat="server" Interval="5000" 
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
         </td>
    </tr> 
</table>
</div>
 
 
