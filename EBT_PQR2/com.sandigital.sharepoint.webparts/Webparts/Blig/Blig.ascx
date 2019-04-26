<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Blig.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.Blig.Blig" %>







<asp:Repeater ID="fvBlig" runat="server">
    <ItemTemplate>



        <table style="vertical-align: top; margin-left: 0px; width: 100%">
            <tr style="vertical-align: top;">
                <td style="text-align: center; vertical-align: top; width: 100px">

                    <!-- foto -->
                    <asp:Image ID="imgMain" runat="server" ImageUrl='<%#   Eval("ImagemHome").ToString().Split(",".ToCharArray())[0]       %>' Width="100" Height="130" />


                </td>

                <td style="width: 15px"></td>



                <td>


                    <table>
                        <tr>
                            <td>

                                <p class="bligTitulo">


                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#  bind("Url")     %>'>

                                        <asp:Label ID="Label1" runat="server" Text='<%# bind("Title") %>'></asp:Label>
                                    </asp:HyperLink>

                                </p>


                            </td>
                        </tr>

                        <tr>
                            <td>
                                <p class="bligConteudo">


                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%#  bind("Url")     %>'>

                                        <asp:Label ID="Label3" runat="server" Text='<%# bind("Chamada") %>'></asp:Label>
                                    </asp:HyperLink>
                                </p>
                            </td>
                        </tr>




                    </table>









                </td>





            </tr>

            <tr>
                <td></td>
                <!-- separador -->
                <td></td>

                <!-- Ler mais -->
                <td style="text-align: right">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#  bind("Url")    %>'>
                       
                       Ler Mais </asp:HyperLink></td>

            </tr>

        </table>



    </ItemTemplate>

    <SeparatorTemplate>
        <div style="height: 10px"></div>

    </SeparatorTemplate>



</asp:Repeater>
<div style="height: 20px;"></div>



<asp:Label ID="lblErro" runat="server" Visible="False" />




