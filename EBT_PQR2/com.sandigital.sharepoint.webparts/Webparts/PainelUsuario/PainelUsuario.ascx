<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PainelUsuario.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.PainelUsuario.PainelUsuario" %>



<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTimer" tagprefix="dxwgv" %>








<script  type="text/javascript" >

    function ShowWindow(url, keyValue) {

        window.open(url + '?id_atendimento=' + keyValue, "janela" + keyValue, "width=650,height=350,scrollbars=NO")

    }

  

</script>




<div style="background-color:#dedfde;color:#ffffff;">
<table width="100%" cellpadding="0" cellspacing="0"  >
    <tr valign="top">
        <td align="left">     
            <table width="100%" cellpadding="0" cellspacing="0"  >                                      
                                                                                              
                <tr valign="top">
                    <td>                                                                                 
                        <table width="100%" cellpadding="0" cellspacing="0" id="outros_chats"  >            
                            <tr>
                                <td style="padding-top:20px;padding-bottom:20px;padding-left:10px;">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                           <td >       
                                               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                   <ContentTemplate>
                                                      <asp:Timer ID="tAtualizaGrid" runat="server" Interval="5000" 
                                                        ontick="tAtualizaGrid_Tick" >
                                                        </asp:Timer>     


                                                       <dxwgv:ASPxGridView ID="dGridMain" runat="server" AutoGenerateColumns="False"  
                                                            KeyFieldName="id_atendimento">
                                                           <Columns>
                                                               <dxwgv:GridViewDataTextColumn Caption="Noc" FieldName="Noc" VisibleIndex="0">
                                                               </dxwgv:GridViewDataTextColumn>
                                                               <dxwgv:GridViewDataTextColumn Caption="Operador" FieldName="Operador" 
                                                                    VisibleIndex="1" Width="80px">
                                                                   <CellStyle HorizontalAlign="Center">
                                                                   </CellStyle>
                                                               </dxwgv:GridViewDataTextColumn>
                                                               <dxwgv:GridViewDataTextColumn Caption="Data do Inicio" FieldName="dt_inicio" 
                                                                    VisibleIndex="2" Width="80px">
                                                                   <CellStyle HorizontalAlign="Center">
                                                                   </CellStyle>
                                                               </dxwgv:GridViewDataTextColumn>
                                                               <dxwgv:GridViewDataTextColumn Caption="Data do Fim" FieldName="dt_fim" 
                                                                    VisibleIndex="3" Width="80px">
                                                                   <CellStyle HorizontalAlign="Center">
                                                                   </CellStyle>
                                                               </dxwgv:GridViewDataTextColumn>
                                                               <dxwgv:GridViewDataTextColumn Caption="Mensagens" FieldName="Mensagens" 
                                                                    VisibleIndex="4" Width="80px">
                                                                   <CellStyle HorizontalAlign="Center">
                                                                   </CellStyle>
                                                               </dxwgv:GridViewDataTextColumn>
                                                               <dxwgv:GridViewDataTextColumn Caption="Status" FieldName="Status" 
                                                                    VisibleIndex="5" Width="80px">
                                                                   <CellStyle HorizontalAlign="Center">
                                                                   </CellStyle>
                                                               </dxwgv:GridViewDataTextColumn>
                                                               <dxwgv:GridViewDataTextColumn Caption="Ações" VisibleIndex="6" Width="60px">
                                                                   <DataItemTemplate>
                                                                       <a href="javascript:void(0);" 
                                                                            
                                                                            
                                                                           onclick='ShowWindow(&#039;/EbtChat/PopupUsuario.aspx&#039;,&#039;<%# Container.KeyValue %>&#039;)'>Exibir</a>
                                                                   </DataItemTemplate>
                                                                   <CellStyle HorizontalAlign="Center">
                                                                   </CellStyle>
                                                               </dxwgv:GridViewDataTextColumn>
                                                           </Columns>

                                                           <SettingsPager ShowDefaultImages="False">
                                                               <AllButton Text="All">
                                                               </AllButton>
                                                               <NextPageButton Text="Next &gt;">
                                                               </NextPageButton>
                                                               <PrevPageButton Text="&lt; Prev">
                                                               </PrevPageButton>
                                                           </SettingsPager>



                                                       </dxwgv:ASPxGridView>
                                                   </ContentTemplate>
                                               </asp:UpdatePanel>                                                                                                                                                                                                   
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="padding-top:20px" >

                                                <a href="InicioChat.aspx"  class="btn btn-primary" style="color:white!improtant;"  >                                     
                                                      
                                                    Novo Chat

                                                </a>    
                                            </td>
                                        </tr>
                                    </table> 
                                                             
                                </td>
                            </tr>
                        </table>                                                                       
                    </td>
                </tr>
            </table>
         </td>
    </tr> 
</table>
</div>
