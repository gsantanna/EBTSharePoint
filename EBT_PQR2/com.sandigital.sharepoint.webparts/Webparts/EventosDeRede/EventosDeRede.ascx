<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>



<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventosDeRede.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.EventosDeRede.EventosDeRede" %>



<%@ Register assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>


<%@ Register Tagprefix="asp" Namespace="System.Web.UI.WebControls" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>



        


<asp:LinqDataSource ID="dsEventos" runat="server" 
    ContextTypeName="com.sandigital.sharepoint.dal.EventoRedeDataContext" TableName="Evento" 
        OrderBy="Inicio desc" Where="Inicio >= DateTime.Now.AddDays(-7)" />
        
        
        



<table style="width:100%">
<tr>

<td>
      <dx:ASPxGridView ID="dGridEventos" runat="server"  
    AutoGenerateColumns="False" 
    DataSourceID="dsEventos" KeyFieldName="id_evento" SettingsPager-PageSize="5" Width="100%">
    
    
                <Styles>
                    <Header CssClass="vEventosHeader" Font-Bold="True" ForeColor="#003D75">
                    </Header>
                    <Cell CssClass="vEventosCell">
                    </Cell>
                </Styles>
    
    
    <SettingsPager Mode="ShowPager" Visible="True">
        <Summary AllPagesText="Páginas: {0} - {1} ({2} Eventos)" 
            Text="Página {0} de {1} ({2} Eventos)" />
    </SettingsPager>
    
    
                <Templates>
                    <PagerBar>
                       
                        <table style="width:100%">
                        <tr>
                        <td><dx:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement1"  runat="server" ReplacementType="Pager" /></td>
                        
                        <td style="width:80px; text-align:right;"> <a href="//SitePages/Eventos.aspx">Histórico >></a></td>
                        
                        <td style="width:10px"> </td>
                        </tr>
                        
                        </table>

                     
                    </PagerBar>
                </Templates>
    
    
                <Border BorderStyle="None" />
    
    
    <Columns>
        <dx:GridViewDataTextColumn FieldName="id_evento" ReadOnly="True" 
            Visible="False" VisibleIndex="0">
            <HeaderStyle HorizontalAlign="Left" />
            <CellStyle HorizontalAlign="Left">
            </CellStyle>
        </dx:GridViewDataTextColumn>
        
        
        
        
        <dx:GridViewDataTextColumn Caption="Evento" FieldName="Evento1" 
            VisibleIndex="0">
            <HeaderStyle HorizontalAlign="Left" />
            <CellStyle HorizontalAlign="Left" Wrap="True">
            </CellStyle>
            
            <DataItemTemplate>
            <asp:HyperLink ID="lnkEvt" runat="server"  NavigateUrl='<%# string.Format("http://2k8rjoapp007:8080/Registro.aspx?IdControle={0}", Eval("id_evento")  ) %>' >            
            <asp:Label ID="lblEvnt" runat="server" Text='<%# Eval("Evento1") %>'>
            </asp:Label>
            </asp:HyperLink>
            
            
            </DataItemTemplate>
            
        </dx:GridViewDataTextColumn>
        
        
        
        
        
        
        <dx:GridViewDataDateColumn FieldName="Inicio" VisibleIndex="1">
            <PropertiesDateEdit DisplayFormatString="dd/MMM HH:mm">
            </PropertiesDateEdit>
            <HeaderStyle HorizontalAlign="Left" />
            <CellStyle HorizontalAlign="Left">
            </CellStyle>
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn FieldName="Localidades" VisibleIndex="2">
            <HeaderStyle HorizontalAlign="Left" />
            <CellStyle HorizontalAlign="Left" Wrap="True">
            </CellStyle>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Responsavel" Caption="Responsável" VisibleIndex="3">
            <HeaderStyle HorizontalAlign="Left" />
            <CellStyle HorizontalAlign="Left" Wrap="True">
            </CellStyle>
        </dx:GridViewDataTextColumn>
    </Columns>
    
    
                <Settings GridLines="None" />
    
    
</dx:ASPxGridView>




            
        
        
        </td>

        
        </tr>
</table>








        








        







