<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PainelOperador.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.PainelOperador.PainelOperador" %>



<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTimer" tagprefix="dxe" %>



<script type="text/javascript" >

    function ShowWindow(url, keyValue) {
        var HField = document.getElementById("<%= HField.UniqueID %>");
        if (HField.value == 1) {
            window.open(url + '?id=' + keyValue, "janela" + keyValue, "width=650,height=350,scrollbars=NO")
        }
        else { alert('Para executar esta operação o operador deverá estar Online!'); }
    }

    function PassarParaMeusAtendimentos(keyValue) {

        var HField = document.getElementById("<%= HField.UniqueID %>");
        if (HField.value == 1) {
            if (!confirm("Deseja realmente abrir este Chat?"))
                return false;
            else {
                __doPostBack('MeusAtendimentos', keyValue);
            }
        }
        else { alert('Para executar esta opera;áo o operador deverá estar Online!'); }
    }


    function AlertaVisual(s, e) {

        var hf = document.getElementById("<%= HField2.UniqueID %>");
        if (hf.value > 0)
            self.focus();
    }



</script>
<style type="text/css" >

 body
    {
        font: 11px Tahoma,Arial,Helvetiva,sans-serif;
    }
    
.logo_chat
{
    width:100%;
   /* background-image:url('/img/fundoChat.jpg'); 
    background-repeat:repeat-x;   */
 /*   background-color:#6188A9;
    height:50px;
    padding-right:20px;*/
}

.tituloPainel
{
    /*vertical-align:middle;   
    font-weight:bold;    
    color:White;*/    
    width:100%;    
    /*height:50px;
    padding-left:20px;*/
}


#titulo_painel{
	
	vertical-align:middle;   
    font-weight:bold;    
   color:White;
    width:740px; 
    text-align:left;
	height:25px;

}

</style>

<asp:Label ID="lblErro" runat="server" /> 

<div style="width:100%;margin:0;padding:0;background:#dedfde;padding-left:10px;padding-top:10px">       
    



        <asp:HiddenField ID="HField" runat="server" />
        <asp:Timer ID="TAtualizaGrids" runat="server" ontick="TAtualizaGrids_Tick" Interval="5000" Enabled="False">
        </asp:Timer>




            <table cellpadding="0" cellspacing="0" style="width:100%;" >
                <tr valign="top">
                    <td align="left">                
                        <table width="100%;" cellpadding="0" cellspacing="0">                   
                            <tr valign="top">
                                <td align="left" >                
                                    <table cellpadding="0" cellspacing="0" style="width:100%" >
                                        <tr valign="top">
                                            <td align="left"  > 
                                            <div id="titulo_painel">
                                            <table cellpadding="0" cellspacing="0" style="width:100%;height:25px;" >
                                                <tr>
                                                    <td align="left" style="padding-left:20px;" >                                                                                      
                                                     <p style="font-size:17px;color:White;">   Painel de Controle Operador</p>                                             
                                                    </td>
                                                    <td style="width:130px;"><b> <span style="color:White;font-size:small;">Meu Status:</span>  </b></td>
                                                    <td style="width:90px;padding-right:10px">


                                                        <dxe:ASPxButton ID="btnStatusOperador" runat="server" Text="Online"  
                                                       onclick="btnStatusOperador_Click">
                                                        </dxe:ASPxButton>   
                                                        
                                                        
                                                                                                      
                                                    </td>
                                                </tr>
                                            </table>                                   
                                                </div>                                                                           
                                            </td>
                                        </tr>       
                                        <tr valign="top">
                                            <td align="left" >
                                                <table class="dxgvControl_PlasticBlue" cellspacing="0" cellpadding="0" id="clt_NOCOperador1_dGridMainStatusNoc" border="0" style="width:740px;border-collapse:collapse;border-collapse:separate;">
	                                                <tr>
		                                                <td>
                                                            <div id="clt_NOCOperador1_dGridMainMeusAtend_DXTDgrouppanel" class="bg-primary">
			                                                    Atendimentos Pedentes
		                                                    </div>
		                                                </td>
		                                            </tr>
		                                        </table>
                                                <dxe:ASPxGridView ID="dGridMain" runat="server" KeyFieldName="id_atendimento" 
                                                   AutoGenerateColumns="False" Width="740px" >
                                                   
                                                  
                                                     <SettingsLoadingPanel ShowImage="False" Text="Carregando&amp;hellip;" />
                                                    <SettingsPager ShowDefaultImages="False">
                                                        <AllButton Text="All">
                                                        </AllButton>
                                                        <NextPageButton Text="Next &gt;">
                                                        </NextPageButton>
                                                        <PrevPageButton Text="&lt; Prev">
                                                        </PrevPageButton>
                                                    </SettingsPager>

                                                  

                                                    <SettingsText EmptyDataRow="Não há registros para a consulta." 
                                                        GroupPanel="Atendimentos Pedentes" />
                                                    <Columns>
                                                        <dxe:GridViewDataTextColumn Caption=" " Width="220px" VisibleIndex="0">
                                                        <DataItemTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                                </tr>
                                                            </table>
                                                        </DataItemTemplate>
                                                        </dxe:GridViewDataTextColumn>
                                                        <dxe:GridViewDataTextColumn Caption="Noc" FieldName="Noc" VisibleIndex="1"
                                                            GroupIndex="0" SortIndex="0" SortOrder="Ascending">
                                                        </dxe:GridViewDataTextColumn>
                                                        <dxe:GridViewDataTextColumn FieldName="Usuario" Caption="Usuário" VisibleIndex="2">
                                                            <CellStyle HorizontalAlign="Left" ></CellStyle>
                                                        </dxe:GridViewDataTextColumn>
                                                         <dxe:GridViewDataDateColumn FieldName="dt_inicio" Caption="data de Inicio" VisibleIndex="3" Width="100px" >
                                                         <CellStyle HorizontalAlign="Center" ></CellStyle>
                                                        </dxe:GridViewDataDateColumn>                                                
                                                        <dxe:GridViewDataTextColumn Caption="Ações"  VisibleIndex="4" Width="80px" >
                                                           <DataItemTemplate>
                                                               <a href="javascript:void(0);" onclick='PassarParaMeusAtendimentos(&#039;<%# Container.KeyValue %>&#039;)'>Abrir</a>
                                                           </DataItemTemplate>
                                                           <CellStyle HorizontalAlign="Center">
                                                           </CellStyle>
                                                        </dxe:GridViewDataTextColumn>
                                                    </Columns>
                                                    <StylesEditors>
                                                        <ProgressBar Height="25px">
                                                        </ProgressBar>
                                                    </StylesEditors>
                                                </dxe:ASPxGridView>
                                            </td>
                                        </tr>                    
                                    </table>                          
                                </td>
                            </tr>      
                            <tr valign="top">
                                <td align="left" style="padding-top:20px" >                
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr valign="top">
                                            <td align="left" >
                                            </td>
                                        </tr>       
                                        <tr valign="top">
                                            <td align="left" >
                                                <dxe:ASPxGridView ID="dGridMainMeusAtend" runat="server" 
                                                    AutoGenerateColumns="False" KeyFieldName="id_atendimento"
                                               Width="740px">
                                                  

                                                    <SettingsPager ShowDefaultImages="False">
                                                        <AllButton Text="All">
                                                        </AllButton>
                                                        <NextPageButton Text="Next &gt;">
                                                        </NextPageButton>
                                                        <PrevPageButton Text="&lt; Prev">
                                                        </PrevPageButton>
                                                    </SettingsPager>
                                                    
                                                    <SettingsText EmptyDataRow="Não há registros para a consulta." GroupPanel="Meus Atendimentos" />
                                                    <Columns>
                                                           <dxe:GridViewDataTextColumn Caption="Noc" FieldName="Noc" VisibleIndex="0">
                                                           </dxe:GridViewDataTextColumn>                                                  
                                                           <dxe:GridViewDataTextColumn Caption="Data do Inicio" FieldName="dt_inicio" 
                                                                VisibleIndex="2" Width="80px">
                                                               <CellStyle HorizontalAlign="Center" >
                                                               </CellStyle>
                                                           </dxe:GridViewDataTextColumn>
                                                           <dxe:GridViewDataTextColumn Caption="Data do Fim" FieldName="dt_fim" 
                                                                VisibleIndex="3" Width="80px">
                                                               <CellStyle HorizontalAlign="Center">
                                                               </CellStyle>
                                                           </dxe:GridViewDataTextColumn>
                                                           <dxe:GridViewDataTextColumn Caption="Mensagens" FieldName="Mensagens" 
                                                                VisibleIndex="4" Width="80px">
                                                               <CellStyle HorizontalAlign="Center">
                                                               </CellStyle>
                                                           </dxe:GridViewDataTextColumn>
                                                           <dxe:GridViewDataTextColumn Caption="Status" FieldName="Status" 
                                                                VisibleIndex="5" Width="80px">
                                                               <CellStyle HorizontalAlign="Center">
                                                               </CellStyle>
                                                           </dxe:GridViewDataTextColumn>
                                                           <dxe:GridViewDataTextColumn Caption="Ações" VisibleIndex="6" Width="60px">
                                                               <DataItemTemplate>
                                                                    <a href="javascript:void(0);" onclick='ShowWindow(&#039; /EbtChat/PopupOperador(&#039;,&#039;<%# Container.KeyValue %>&#039;)'>Exibir</a>
                                                               </DataItemTemplate>
                                                               <CellStyle HorizontalAlign="Center">
                                                               </CellStyle>
                                                           </dxe:GridViewDataTextColumn>
                                                       </Columns>
                                                    <Settings ShowGroupPanel="True" />
                                                    <StylesEditors>
                                                        <ProgressBar Height="25px">
                                                        </ProgressBar>
                                                    </StylesEditors>
                                                </dxe:ASPxGridView>
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
 


 

<dxe:ASPxTimer ID="tAtualiza" runat="server" ClientInstanceName="tAtualiza" 
    Interval="5000" Enabled="True">
    <ClientSideEvents Tick="function(s, e) {
	AlertaVisual(s,e);
}" />
</dxe:ASPxTimer>




 
        <asp:HiddenField ID="HField2" runat="server" />