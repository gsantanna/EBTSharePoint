<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParticipantesReuniao.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ParticipantesReuniao.ParticipantesReuniao" %>


<%@ Register assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>



<asp:Label ID="lblErro" runat="server" Visible="false" />

    
        <!-- inicio do script do Grid -->
    <script type="text/javascript">
        // <![CDATA[
        var timeout;
        function scheduleGridUpdate(grid) {
            window.clearTimeout(timeout);
            timeout = window.setTimeout(
                function () { /*grid.Refresh();*/ },
                5000
            );
        }
        function grid_Init(s, e) {
            scheduleGridUpdate(s);
        }
        function grid_BeginCallback(s, e) {
            window.clearTimeout(timeout);
        }
        function grid_EndCallback(s, e) {
            scheduleGridUpdate(s);
        }
        // ]]> 
    </script>
        <!-- Fim do script do Grid -->








        <table style="width:100%;padding:5px 5px 5px 5px;">
            <tr style="padding-bottom:5px">
                <td style="width:72px;padding:5px 5px 5px 5px;" >Reunião:</td>
                <td><dx:ASPxComboBox Width="140" ID="cboReunioes" runat="server"   TextField="dt_evento"  ValueField="ID" ValueType="System.Int32" AutoPostBack="True"  /> </td>
            </tr>
            
        </table>


<asp:Panel ID="pnlAdd" runat="server"  >

<table style="width:300px;">
    <tr>

                <td style="width:70px">Participante:</td>
                <td>  

                    <table style="width:100%">
                        <tr>

                            <td>
                                <SharePoint:PeopleEditor ID="pppAdd" runat="server" Width="100%" BorderStyle="Solid" BorderColor="Black" BorderWidth="1" MultiSelect="true" />

                            </td>

                        </tr>
                            
                        <tr>
                            <td> <asp:Button ID="btnIncluir" runat="server" Text="Adicionar" CssClass="btn-small btn-primary" OnClick="btnIncluir_Click"  /> </td>
                      </tr>
                    </table>

                </td>
            </tr>
</table>

</asp:Panel>



        <br />

        <table style="width:100%">

            <tr>
                <td>
                    

                    <asp:ObjectDataSource ID="dsGridMain" runat="server" SelectMethod="ListaUsuarios" TypeName="com.sandigital.sharepoint.webparts.ParticipantesReuniao.ParticipantesReuniao" >
                        <SelectParameters>
                            <asp:ControlParameter ControlID="cboReunioes" Name="id_reuniao" PropertyName="Value" Type="String" />
                        </SelectParameters>

                    </asp:ObjectDataSource>


                    <dx:ASPxGridView Width="100%" Settings-ShowColumnHeaders="false" ID="grid" ClientInstanceName="grid" runat="server" AutoGenerateColumns="False" DataSourceID="dsGridMain" KeyFieldName="id_registro" OnRowDeleting="grid_RowDeleting">
                        
                        <SettingsPager Mode="ShowAllRecords" />
                        
                        <ClientSideEvents Init="grid_Init" BeginCallback="grid_BeginCallback" EndCallback="grid_EndCallback" />
                        
                        <SettingsText  EmptyDataRow="Sem participantes "/>
                        <Columns>
                            <dx:GridViewDataColumn>
                                <DataItemTemplate><asp:Label ID="lblUsr" runat="server" Text='<%#Eval ("nome") %>'></asp:Label></DataItemTemplate>
                            </dx:GridViewDataColumn>

                            <dx:GridViewCommandColumn ButtonType="Image" Width="15px">

                                <DeleteButton Text="Remover" Visible="True">
                                    <Image Url="~/Images/Excluir.png">
                                    </Image>
                                </DeleteButton>

                            </dx:GridViewCommandColumn>


                        </Columns>

                       


                        <SettingsBehavior AllowDragDrop="false" />
                        
                        <SettingsPager Visible="False" />

<Settings ShowColumnHeaders="False"></Settings>

                        <SettingsLoadingPanel Mode="Disabled" />

                    </dx:ASPxGridView>
                </td>
            </tr>

        </table>
           



