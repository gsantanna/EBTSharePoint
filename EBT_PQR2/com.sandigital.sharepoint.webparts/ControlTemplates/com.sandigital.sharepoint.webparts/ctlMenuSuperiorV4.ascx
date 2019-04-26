<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlMenuSuperiorV4.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts.ctlMenuSuperiorV4" %>





<asp:Label ID="lblErro" runat="server" />


				



	

<asp:Repeater ID="rptMain" runat="server">







    <HeaderTemplate>

		 <div role="tabpanel" class="mnuSupComunidades s4-notdlg">
               <ul class="nav nav-tabs" role="tablist">


    </HeaderTemplate>
        
    <ItemTemplate>

       

         <li runat="server" role="presentation"  class='<%# Eval("Classe") %>'  >
             
             	<asp:HyperLink ID="lnkMnu3" runat="server" NavigateUrl='<%# Eval("Link") %>'>	
					<asp:Label  Visible="true" ID="lnkMnuTtle3" runat="server" Text='<%# Eval("Texto") %>'   />
					</asp:HyperLink>

         </li>
  




       
    </ItemTemplate>

    <FooterTemplate>
      

        </ul>
        </div>

    </FooterTemplate>





</asp:Repeater>

