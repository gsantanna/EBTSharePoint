<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AcessoRapido.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.Webparts.AcessoRapido.AcessoRapido" %>




<link rel="stylesheet" type="text/css" href="/css/smoothDivScroll.css">

<style type="text/css">
    .acessoRapido {
      
        position: relative;
        background: #075181;
        border-radius: 10px;
        clear: both;
        text-align: center;
        height: 65px;

        text-align: justify;
        -ms-text-justify: distribute-all-lines;
        text-justify: distribute-all-lines;

    }

    .acessoRapidodiv.scrollableArea img {
        position: relative;
        /*float: left;*/
        margin: 0;
        padding: 0;
        -webkit-user-select: none;
        -khtml-user-select: none;
        -moz-user-select: none;
        -o-user-select: none;
        user-select: none;







    }
</style>

<div id="dvContainerAcessoRapido" style="width: 100%; text-align:center;" class="text-center">
    <div id="divAcessoRapido" class="acessoRapido text-center" style="text-align:center;" runat="server">
    </div>
</div>





	<script src="/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
	
	
	<script src="/js/jquery.mousewheel.min.js" type="text/javascript"></script>

	
	<script src="/js/jquery.kinetic.min.js" type="text/javascript"></script>

	<script src="/js/jquery.smoothdivscroll-1.3-min.js" type="text/javascript"></script>

