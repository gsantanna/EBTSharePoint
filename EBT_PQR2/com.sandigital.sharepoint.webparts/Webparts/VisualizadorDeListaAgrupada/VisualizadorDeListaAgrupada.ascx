<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>


<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualizadorDeListaAgrupada.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.VisualizadorDeListaAgrupada.VisualizadorDeListaAgrupada" %>




   <%@ Register assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Label ID="lblHack" runat="server"></asp:Label>

<asp:Label ID="lblErro" runat="server"></asp:Label>

   <style type="text/css">
            .dxgvIndentCell {
                background-color:transparent !important;
                            border: 0px !important;

            }

             .dxgvGroupRow td , dxgvGroupRow {
            border: 0px !important;
        }

        </style>

<dx:ASPxGridView Visible="false"   ID="dGridMain" runat="server" AutoGenerateColumns="True"  Width="100%" EnableTheming="True" OnCustomColumnSort="dGridMain_CustomColumnSort" >
            <SettingsBehavior SortMode="Custom" />
            <SettingsPager Mode="ShowAllRecords" Visible="False">
            </SettingsPager>
            <Settings GridLines="None" GroupFormat="{0}:  &lt;span class='ms-gb2' style='border:none;color:#4c4c4c'&gt;  {1} {2} &lt;/spam&gt;" />
            <SettingsLoadingPanel Text="Carregando&amp;hellip;" />
            <Images>
                <CollapsedButton Url="/_layouts/images/plus.gif">
                </CollapsedButton>
                <ExpandedButton Url="/_layouts/images/minus.gif">
                </ExpandedButton>
            </Images>
            <Styles>
                <Header BackColor="Transparent">
                    <Paddings PaddingBottom="5px" PaddingTop="5px" />
                    <Border BorderStyle="None" />
                </Header>
                <GroupRow BackColor="Transparent" CssClass="ms-gb" Font-Bold="True" ForeColor="#0072BC">
                </GroupRow>
                <Row CssClass="ms-vb2 ms-itmhover" >
                    
                </Row>
                <DetailCell>
                    <Border BorderStyle="None" />
                </DetailCell>
                <Cell BackColor="Transparent">
                    <Border BorderStyle="None" />
                </Cell>
                <GroupFooter>
                    <Border BorderStyle="None" />
                </GroupFooter>
                <GroupPanel>
                    <Border BorderStyle="None" />
                </GroupPanel>
                <HeaderPanel>
                    <Border BorderStyle="None" />
                </HeaderPanel>
                <StatusBar>
                    <Border BorderStyle="None" />
                </StatusBar>
                <HeaderFilterItem>
                    <Border BorderStyle="None" />
                </HeaderFilterItem>
            </Styles>
            <Border BorderStyle="None" />

    <Columns>
    </Columns>
        


        </dx:ASPxGridView>

	<script type="text/javascript" src="/js/jquery.min.js"></script>


<script type="text/javascript">

    $(document).ready(function () {

        var hack = $(".ag_hackTitulo");

        $(hack).each(function () {
            $($(this).closest("tbody")).find(".ms-WPHeaderTd h3 nobr").html("<a href='" + $(this).attr("url")  + "'>"+ $(this).attr("titulo") +"</a>")
        });
        //

    });
    

</script>










