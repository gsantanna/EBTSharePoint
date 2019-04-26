<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuGenerico.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.MenuGenerico.MenuGenerico" %>




<asp:Label ID="lblErro" runat="server" />


<asp:Repeater ID="rptMain" runat="server">

    <HeaderTemplate>
        <div class="MenuSuperiorHome">
    </HeaderTemplate>

    <ItemTemplate>
            <asp:HyperLink ID="lnkMain" runat="server"  NavigateUrl='<%#Eval("Link") %>'  Text='<%#Eval("Texto") %>'   Target='<%# ((bool)Eval("NovaJanela"))? "_Blank" : "" %>'    />
     </ItemTemplate>
    
    <SeparatorTemplate>
         <span style="padding: 3px; font-weight:bold; font-size:12px; font-family: ARIal, Helvetica, sans-serif; text-transform: uppercase;">
         &nbsp;|&nbsp; 
        </span> 

    </SeparatorTemplate>

    <FooterTemplate>
        </div>
    </FooterTemplate>

</asp:Repeater>