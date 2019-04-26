<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctl_alertas.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts.ctl_alertas" %>

<asp:Label ID="lblErro" runat="server" Visible="false"></asp:Label>
<asp:Panel ID="pnlAlertas" runat="server" Visible="false">



    <style type="text/css">
        .tituloWebpart {
            background-color: #FF4040;
            border: 1px #b22a2a solid;
            /*
            -webkit-border-top-right-radius: 10px;
            -webkit-border-top-left-radius: 10px;
            -moz-border-radius-topright: 10px;
            -moz-border-radius-topleft: 10px;
            border-top-right-radius: 10px;
            border-top-left-radius: 10px;
                */
            color: white;
            font-size: large;
            padding: 10px 10px 10px 10px;
            width: 100%;
        }

        .containerAlerta {
            margin-top: 5px;
            border: 1px solid #cfcfcf;
        }

        .tituloAlerta {
            background-color: #EBEBEB;
            color: red;
            font-size: medium;
            border-bottom: 1px solid #cfcfcf;
            padding: 2px 2px 2px 5px;
            margin-bottom: 2px;
        }

        .itemAlerta {
            list-style: none;
            padding-left: 5px;
            margin-left: 5px;
        }
    </style>



    <div class="tituloWebpart">
        <span class="glyphicon glyphicon-exclamation-sign">&nbsp;ALERTAS </span>
    </div>


    <asp:Repeater ID="rptMain" runat="server">

        <HeaderTemplate>

            <div class="containerAlerta">
                <div class="tituloAlerta">EMERGENCIAL</div>
                <ul class="itemAlerta">
        </HeaderTemplate>

        <ItemTemplate>


            <li>
                <asp:Label ID="lblAlerta" runat="server" Text='<%# Eval("Titulo") %>'></asp:Label>
            </li>




        </ItemTemplate>
       
        <FooterTemplate> 
            </ul></div>
        </FooterTemplate>

    </asp:Repeater>












</asp:Panel>


