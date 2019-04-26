<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualizadorDeListaAgrupadaEditor.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts.VisualizadorDeListaAgrupadaEditor" EnableViewState="true" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>



<asp:Label ID="lblErro" runat="server"></asp:Label>
<asp:HiddenField runat="server" ID="hiddenFieldDetectRequest" Value="0" />

<fieldset>


  <fieldset>
    <legend>Lista para exibir:</legend>
   
        <dx:ASPxComboBox ID="cboLista" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboLista_SelectedIndexChanged"></dx:ASPxComboBox>
  </fieldset>



</fieldset>

<fieldset>
    <legend>Selecione as colunas:</legend>


<dx:ASPxGridView ID="dGridConfig" runat="server"  AutoGenerateColumns="False" Width="100%" KeyFieldName="InternalName" EnableRowsCache="False" ClientInstanceName="grid">
    <columns>
        <dx:GridViewDataColumn Visible="false" Name="Id" FieldName="Id">


        </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn Caption="InternalName" FieldName="InternalName" Name="InternalName" ReadOnly="True" Visible="False" VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Coluna" FieldName="DisplayName" Name="DisplayName" ReadOnly="True" VisibleIndex="1">

                    <DataItemTemplate>


                        <asp:Label data-toggle="tooltip" data-placement="left"  runat="server" ID="lblt1" ToolTip='<%#Eval("StaticName") %>'  Text='<%#Eval("DisplayName") %>'></asp:Label>
                          

                    </DataItemTemplate>

                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Exibido"  Name="Exibido" VisibleIndex="2" Width="60px" >

                    <DataItemTemplate>
                                        <dx:ASPxCheckBox ID="cbExibido" Checked='<%# Eval("Visible") %>' runat="server"  />
                    </DataItemTemplate>

                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Agrupado"  Name="Agrupado" VisibleIndex="3" Width="60px">

                    
                    <DataItemTemplate>
                                        <dx:ASPxCheckBox ID="cbAgrupado" Checked='<%# Eval("Grouped") %>' runat="server"  />
                    </DataItemTemplate>


                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Ordem" FieldName="Order" Name="Ordem"  VisibleIndex="4" Width="30px">
                    <DataItemTemplate>

                        <dx:ASPxTextBox ID="txtOrdem" runat="server" Text='<%#Eval("Order") %>'  NullText="0"  AutoResizeWithContainer="true" Width="30px" >
                          
                        </dx:ASPxTextBox>

                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
            </columns>
    <settingsbehavior allowdragdrop="False" allowgroup="False" allowsort="False" />

    <settingspager mode="ShowAllRecords">
            </settingspager>







</dx:ASPxGridView>


</fieldset>
