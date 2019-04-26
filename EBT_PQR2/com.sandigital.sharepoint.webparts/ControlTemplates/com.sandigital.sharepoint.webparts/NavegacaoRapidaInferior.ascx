<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavegacaoRapidaInferior.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts.NavegacaoRapidaInferior" %>


<asp:Label ID="lblErro" runat="server" Visible="false" />



    <asp:Repeater ID="rptMain" runat="server">

        <HeaderTemplate>
            <div  class="col-md-1" style="margin-top:5px;float:right">
              <div class="btn-group-sm" style="">
                   <button type="button" class="btn btn-default btn-sm dropdown-toggle" data-toggle="dropdown">
                    &nbsp&nbspIr para 
                    <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu">


        </HeaderTemplate>

        <ItemTemplate>
              <li><a href='<%#Eval("Link") %>'><%#Eval("Texto") %></a></li>
        </ItemTemplate>
      
        
        
        
          <FooterTemplate>
                    </ul>
                </div><!-- btnGrupo-->
            </div><!--container-->

        </FooterTemplate>


    </asp:Repeater>








  




