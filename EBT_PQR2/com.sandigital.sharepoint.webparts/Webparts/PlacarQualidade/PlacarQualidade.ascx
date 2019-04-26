<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlacarQualidade.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.PlacarQualidade.PlacarQualidade" %>


<div class="placarContainer" runat="server">

    <div id="placar" style='width:100%;max-width:<%# Eval("Tamanho") %>;' class="carousel slide" data-interval="4000" data-ride="carousel">
    <asp:Repeater ID="rptIndicadores" runat="server">
    <HeaderTemplate>
          <!-- Carousel indicators -->
        <ol class="carousel-indicators">
    </HeaderTemplate>
    <ItemTemplate>
            <li data-target="#placar" data-slide-to='<%# Eval("ID") %>' class='<%# Eval("css") %>' ></li>
    </ItemTemplate>
    <FooterTemplate>
             </ol>  
    </FooterTemplate>
</asp:Repeater>
        <asp:Repeater ID="rptItens" runat="server">
            <HeaderTemplate>
       <!-- Carousel items -->
        <div class="carousel-inner">
            </HeaderTemplate>
            <ItemTemplate>

                
            <div  runat="server"  class='<%# Eval("css") + " item" %>'>

                <asp:HyperLink runat="server" ID="lnk" NavigateUrl='<%#Eval("Link") %>' >
                 <img style='width:<%#Eval("Tamanho") %>;max-width:<%#Eval("Tamanho")%>' src='<%#Eval("Imagem") %>' alt='<%# Eval("Titulo") %>' /></asp:HyperLink>

                  <p> <asp:Label runat="server" ID="lblDescr" Text='<%#Eval("Titulo") %>'></asp:Label>  </p>
            </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <!-- Carousel nav -->
        <a class="carousel-control left" href="#placar" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
        </a>
        <a class="carousel-control right" href="#placar" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
        </a>
    </div>

</div>

<p>
    <asp:Label ID="lblErro" runat="server"></asp:Label>
</p>


