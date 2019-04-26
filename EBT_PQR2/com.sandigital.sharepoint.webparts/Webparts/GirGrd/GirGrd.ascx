<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GirGrd.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.GirGrd.GirGrd" %>






<%@ Register assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI.WebControls" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>










            <dx:ASPxGridView ID="grdMain" runat="server" AutoGenerateColumns="False" 
                onpageindexchanged="grdMain_PageIndexChanged" Width="100%">
                <Styles>
                  
                      <Header BackColor="White" CssClass="boxAuxiliarPeq" Font-Bold="True" 
                        ForeColor="#003D75">
                    </Header>
                    <Cell>
                        <BorderBottom BorderColor="#CEDCE5" />
                    </Cell>
                    <PagerBottomPanel CssClass="boxGirGrdPager">
                    </PagerBottomPanel>
                </Styles>
                <SettingsPager PageSize="5" EllipsisMode="OutsideNumeric">
                    <AllButton Text="All">
                    </AllButton>
                    <Summary AllPagesText="Páginas: {0} - {1} ({2} itens)" 
                        Text="Página  {0} de {1} ({2} itens)" />
                    
                </SettingsPager>
                <Border BorderStyle="None" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="SGIR" Caption="SGIR" VisibleIndex="0">
                    <CellStyle  HorizontalAlign="Left"  ForeColor="#003d75"></CellStyle>
                    <HeaderStyle HorizontalAlign="Left" />
                    
                    <DataItemTemplate>
                    
                    <asp:HyperLink ID="lnkSGIR" runat="server" NavigateUrl='<%# string.Format("http://ENDERECO_S_GIR?SGIR={0}", Eval("SGIR")) %>' >
                    <asp:Label ID="lblTextoSGIR" runat="server" Text='<%# Eval("SGIR") %>'></asp:Label>
                    </asp:HyperLink>
                    </DataItemTemplate>
                    
                    
                    
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Grd"  Caption="GRD" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="INÍCIO" FieldName="Inicio" 
                        VisibleIndex="2">
                        <PropertiesDateEdit DisplayFormatString="dd/MMM HH:mm">
                        </PropertiesDateEdit>
                         <CellStyle HorizontalAlign="Left"></CellStyle>
                           <HeaderStyle HorizontalAlign="Left" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="Rede" Caption="REDE" VisibleIndex="3">
                     <CellStyle HorizontalAlign="Left"></CellStyle>
                       <HeaderStyle HorizontalAlign="Left" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Atividade" Caption="ATIVIDADE" VisibleIndex="4" Visible="false">
                    
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Localidade" Caption="LOCALIDADES" VisibleIndex="5">
                    <CellStyle HorizontalAlign="Left"></CellStyle>
                      <HeaderStyle HorizontalAlign="Left" />
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Settings GridLines="Horizontal" />
            </dx:ASPxGridView>
        
 


                   
<asp:Label  ID="lblErro" runat="server" Visible="False" />







