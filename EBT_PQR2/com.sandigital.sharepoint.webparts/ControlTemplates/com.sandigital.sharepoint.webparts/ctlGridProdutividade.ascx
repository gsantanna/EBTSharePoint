<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlGridProdutividade.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts.ctlGridProdutividade" %>


<%@ Register Assembly="DevExpress.XtraCharts.v12.1.Web, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>





<%@ Register Assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>





<h2 class="text-center">Grade Produtividade</h2>




<!-- Painel 1 -->

<div style="width: 1000px; padding-left: 10px; padding-top: 10px; padding-bottom: 10px; margin: auto; vertical-align: top; border: 1px solid #b0b0b0; background-color: #ededed" class="text-center">

    <table>
        <tr>
            <td>Data:</td>

            <td style="width: 10px;"></td>
            <td>
                <dx:ASPxDateEdit ID="cboDtInicio" runat="server" Width="100px">
                    <ValidationSettings ErrorText="*">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxDateEdit>
            </td>
            <td style="width: 10px;"></td>
            <td>
                <asp:Button runat="server" ID="btnGerar" CssClass="btn btn-sm btn-primary" Text="Gerar" OnClick="btnGerar_Click" />
            </td>
            <td style="width: 10px">&nbsp;</td>
            <td>
                <asp:Label ID="lblAviso" runat="server"></asp:Label></td>



        </tr>
    </table>

</div>

<div style="height: 10px; min-height: 10px; width: 100%;">
</div>


<p>
    &nbsp;
</p>
<dx:ASPxGridView ID="dGridMain"    runat="server" Theme="PlasticBlue" Width="100%" AutoGenerateColumns="False" EnableTheming="True">
    <Columns>
        <dx:GridViewDataTextColumn FieldName="Usuario" VisibleIndex="0">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="QtdRecs" VisibleIndex="1" Caption="Recs">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="QtdHoras" VisibleIndex="2" Caption="Horas" >
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Prod" VisibleIndex="3">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C1" VisibleIndex="4" Caption="01">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C2" VisibleIndex="5" Caption="02">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C3" VisibleIndex="6" Caption="03">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C4" VisibleIndex="7" Caption="04">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C5" VisibleIndex="8" Caption="05">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C6" VisibleIndex="9" Caption="06">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C7" VisibleIndex="10" Caption="07">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C8" VisibleIndex="11" Caption="08">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C9" VisibleIndex="12" Caption="09">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C10" VisibleIndex="13" Caption="10">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C11" VisibleIndex="14" Caption="11">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C12" VisibleIndex="15" Caption="12">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C13" VisibleIndex="16" Caption="13">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C14" VisibleIndex="17" Caption="14">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C15" VisibleIndex="18" Caption="15">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C16" VisibleIndex="19" Caption="16">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C17" VisibleIndex="20" Caption="17">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C18" VisibleIndex="21" Caption="18">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C19" VisibleIndex="22" Caption="19">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C20" VisibleIndex="23" Caption="20">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C21" VisibleIndex="24" Caption="21">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C22" VisibleIndex="25" Caption="22">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C23" VisibleIndex="26" Caption="23">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="C24" VisibleIndex="27" Caption="00">
        </dx:GridViewDataTextColumn>



    </Columns>
    <SettingsBehavior AllowGroup="False" AllowSort="False" />
    <SettingsPager Visible="False">
    </SettingsPager>
</dx:ASPxGridView>



