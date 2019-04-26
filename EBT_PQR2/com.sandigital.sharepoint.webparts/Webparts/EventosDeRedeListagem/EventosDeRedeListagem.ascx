<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<%@ Import Namespace="Microsoft.SharePoint" %> 

<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventosDeRedeListagem.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.EventosDeRedeListagem.EventosDeRedeListagem" %>




<%@ Register assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI.WebControls" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>












<%@ Register assembly="DevExpress.Web.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxMenu" tagprefix="dx" %>












<style type="text/css">
    .style1
    {
        font-size: 11px;
    }
</style>



<dx:ASPxGridView ID="dGridEvento" ClientInstanceName="dGridEvento" runat="server" AutoGenerateColumns="False" 
     KeyFieldName="id_evento" Width="100%" >



    <SettingsPager ShowDefaultImages="False">
        <AllButton Text="All">
        </AllButton>
        <NextPageButton Text="Next &gt;">
        </NextPageButton>
        <PrevPageButton Text="&lt; Prev">
        </PrevPageButton>
    </SettingsPager>



    <Columns>
        
        <dx:GridViewDataTextColumn Caption="Pai" FieldName="id_pai" GroupIndex="0" 
            SortIndex="0" SortOrder="Ascending" VisibleIndex="0">
        </dx:GridViewDataTextColumn>

        <dx:GridViewDataTextColumn Caption="Codigo" FieldName="id_evento" 
            ReadOnly="True" VisibleIndex="1">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Evento" FieldName="Evento1" 
            VisibleIndex="2">
            <DataItemTemplate>
                           <asp:Label ID="lblEventttt" runat="server" Text='<%# Eval("Evento1") %>' ></asp:Label>
                           
            </DataItemTemplate>
        </dx:GridViewDataTextColumn >
        <dx:GridViewDataTextColumn Caption="Tipo" FieldName="TipoEvento"  VisibleIndex="3">
            <DataItemTemplate>

                <dx:ASPxLabel ID="ASPxLabel1" runat="server"  Text='<%#   
                (DataBinder.Eval(Container.DataItem, "TipoEvento").ToString().Equals("3"))? "Normalizado":"Andamento"
                        %>'>
                </dx:ASPxLabel>
                
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Descricao" VisibleIndex="4">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Causa" VisibleIndex="5">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="Inicio" VisibleIndex="6">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataDateColumn FieldName="Fim" VisibleIndex="7">
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="Localidades" VisibleIndex="8">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ImpactoLocal" VisibleIndex="9">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ImpactoLDN" VisibleIndex="10">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="11">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Responsavel" VisibleIndex="12">
        </dx:GridViewDataTextColumn>
       
        <dx:GridViewDataTextColumn FieldName="Ral" VisibleIndex="13">
        </dx:GridViewDataTextColumn>
       
       
       
        <dx:GridViewDataTextColumn FieldName="EnviadoPor" VisibleIndex="14">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="EnviadoPor2" VisibleIndex="15">
        </dx:GridViewDataTextColumn>


    </Columns>

    <Settings ShowFilterRow="True" />

    <StylesEditors>
        <ProgressBar Height="25px">
        </ProgressBar>
    </StylesEditors>

</dx:ASPxGridView>


<asp:Label ID="lblErro" runat="server" Visible="false" />

<p class="style1">
    EBT Eventos 3.0</p>
