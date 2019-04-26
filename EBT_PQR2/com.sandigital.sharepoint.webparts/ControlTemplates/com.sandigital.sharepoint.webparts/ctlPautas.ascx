<%@ Assembly Name="com.sandigital.sharepoint.webparts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=3f3cab3e36284eb0" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI.WebControls" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="com.sandigital.sharepoint.webparts.Modelos" %>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlPautas.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts.ctlPautas" EnableViewState="true"  %>


<%@ Register assembly="DevExpress.Web.ASPxGridView.v12.1.Export, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>


<style type="text/css">
    .ms-formbody
    {
        vertical-align: top;
        background: #f6f6f6; 
        border-top: 1px solid #d8d8d8;
        padding: 3px 6px 4px 6px;
    }

    .ms-formlabel
    {
        text-align: left;
        font-family: verdana;
        border-top: 1px solid #d8d8d8;
        padding-top: 3px;
        padding-right: 8px;
        padding-bottom: 6px;
        color: #525252;
        font-weight: bold;
    }

    .TituloPauta
    {
    }




    

.tb_anexos {
	width:100%;  border-collapse:collapse;
	}

.tb_anexos_tr {
	padding:0;
}
.tb_anexos_icon {
	padding-right:10px;
	/*border-bottom:1px #808080 solid;*/
	width:26px;
	
	}

.tb_anexos_link {
	
 
	border-bottom:1px #808080 solid;
}




</style>

<asp:Label ID="lblErro" runat="server" Visible="false" />



<h4 class="TituloPauta">
<asp:Label ID="lblTituloGrid" runat="server" Visible="true" />
</h4>





<!-- Inicio do Grid de Pautas -->

<asp:HiddenField ID="hfTIPO" runat="server"  />
<dx:ASPxGridView ID="dGridPautas" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" ClientInstanceName="dGridPautas" EnableCallBacks="True">

    <SettingsPager Visible="False" Mode="ShowAllRecords" />


    <Columns>

        <dx:GridViewDataTextColumn FieldName="ID" Visible="False" VisibleIndex="0" />



        <dx:GridViewDataTextColumn FieldName="Titulo" VisibleIndex="1" Width="100%">

            <DataItemTemplate>

                <span class="pautaTitulo">
                    <asp:Literal ID="litLinkModal" runat="server" Text='<%# Eval("ID","<a href=\"#\" data-toggle=\"modal\" data-target=\"#MDL{0}\" > ") %>' />
                    <asp:Label ID="lblTitulo" runat="server" Text='<%# Eval("Titulo") %>' />
                    </a>
                            &nbsp;
                            <asp:HyperLink Visible='<%# com.sandigital.sharepoint.spsWrapper.Utilidades.Administrador()  %>' ID="lnkEditPauta" runat="server" NavigateUrl='<%# Eval("ID", "/ComunidadePreventivasVoc/Lists/Pautas/EditForm.aspx?ID={0}&Source=/ComunidadePreventivasVoc/Paginas/Reuniao.aspx")  %>'><img  alt="Editar" src="/images/Editar.png" /></asp:HyperLink>
                </span>



                <!-- inicio do Modal -->
                <div class="modal fade" id='<%# Eval("ID","MDL{0}" ) %>' tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                <h4 class="modal-title" id="myModalLabel">Detalhes da pauta:
                                    <asp:Label ID="lbldPautaTituloCab" runat="server" Text='<%#Eval("Titulo") %>' />
                                </h4>
                            </div>
                            <div class="modal-body">
                                <table class="ms-formtable" style="width: 100%;">
                                    <tbody>

                                        <tr>

                                            <td class="ms-formlabel" style="width: 180px;">Assunto:</td>
                                            <td class="ms-formbody">
                                                <asp:Label ID="lbldPautaTitulo" runat="server" Text='<%#Eval("Titulo") %>' /></td>

                                        </tr>

                                        <tr>

                                            <td class="ms-formlabel">Observações: </td>
                                            <td class="ms-formbody">
                                                <asp:Label ID="lbldObservações" runat="server" Text='<%#Eval("Observacoes") %>' /></td>

                                        </tr>

                                        <tr>
                                            <td class="ms-formlabel">Responsável: </td>
                                            <td>
                                                <asp:Label ID="lbldResponsavel" runat="server" Text='<%#Eval("Responsavel") %>' /></td>
                                        </tr>

                                        <tr>
                                            <td>Status: </td>
                                            <td>
                                                <asp:Label ID="lbldStatus" runat="server" Text='<%#Eval("Status") %>' /></td>
                                        </tr>

                                        <tr>
                                            <td>Data da Reunião: </td>
                                            <td>
                                                <asp:Label ID="lbldReuniao" runat="server" Text='<%#Eval("DataReuniao","{0:dd/MM/yyyy}") %>' /></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lblAnexosPauta" runat="server" Text="Anexos" Visible='<%# !String.IsNullOrEmpty(  Eval("Anexos").ToString())  %>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAnexos" runat="server" Text='<%# Eval("Anexos") %>' />
                                            </td>
                                        </tr>

                                    </tbody>

                                </table>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Fechar</button>
                            </div>
                        </div>
                    </div>
                </div>









                <!-- Fim do modal -->

                <asp:HiddenField ID="ctl_id_pauta" runat="server" Value='<%# Eval("ID") %>' />

            </DataItemTemplate>

        </dx:GridViewDataTextColumn>





    </Columns>


    <SettingsBehavior AllowSort="False" />

    <SettingsPager PageSize="200" />


    <Settings GridLines="None" ShowColumnHeaders="False" />
    <SettingsText EmptyDataRow="Sem pautas carregadas" CommandDelete="Deletar Pauta" CommandEdit="Editar Pauta" CommandUpdate="Salvar" ConfirmDelete="Deseja mesmo remover esta pauta e todas as suas tarefas? Atenção: esta operação não tem retorno!" CustomizationWindowCaption="Editar" PopupEditFormCaption="Editar Pauta" />
    <SettingsLoadingPanel Text="Aguarde&amp;hellip;" />
    <SettingsDetail ShowDetailRow="true" ShowDetailButtons="true" AllowOnlyOneMasterRowExpanded="True" />


    <Templates>

        <DetailRow>
            <!-- inicio do detailrow do grid pautas -->
            <asp:HiddenField ID="ctl_id_pauta" runat="server" Value='<%# Eval("ID") %>' />

            <asp:ObjectDataSource ID="dsTarefas" runat="server" SelectMethod="ListaTarefasGrid" UpdateMethod="AtualizaTarefaGrid" InsertMethod="AdicionaTarefaGrid" DeleteMethod="DeletaTarefaGrid" DataObjectTypeName="com.sandigital.sharepoint.webparts.Modelos.Tarefa" TypeName="com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts.ctlPautas">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ctl_id_pauta" DefaultValue="" Name="id_pauta" PropertyName="Value" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <dx:ASPxGridView ID="dGridTarefas" Border-BorderStyle="None" runat="server" DataSourceID="dsTarefas" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" ClientInstanceName="dGridTarefas" EnableCallBacks="True">

                <SettingsBehavior AllowSort="False" />
                <SettingsPager Visible="False" Mode="ShowAllRecords" />


                <Settings GridLines="None" />
                <SettingsText EmptyDataRow="Sem Tarefas" />
                <SettingsLoadingPanel Text="Aguarde&amp;hellip;" />
                <SettingsDetail ShowDetailRow="true" ShowDetailButtons="true" AllowOnlyOneMasterRowExpanded="True" />
                <Border BorderStyle="None" />

                <Columns>

                    <dx:GridViewDataTextColumn Name="ID" FieldName="ID" Visible="false" VisibleIndex="0" />

                    <dx:GridViewDataTextColumn Name="Titulo" FieldName="Titulo" Visible="true" VisibleIndex="1" />

                    <dx:GridViewDataTextColumn Name="Atrib" Caption="Atribuido á" FieldName="Atribuidaa" Visible="true" VisibleIndex="2" />

                    <dx:GridViewDataTextColumn FieldName="Status" Caption="Status" VisibleIndex="3" />

                    <dx:GridViewDataDateColumn FieldName="DataPrevista" Caption="Data Prevista" VisibleIndex="4" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy">

                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>

                    </dx:GridViewDataDateColumn>

                    <dx:GridViewDataColumn Caption=" " VisibleIndex="5">
                        <DataItemTemplate>
                            <asp:HyperLink Visible='<%# com.sandigital.sharepoint.spsWrapper.Utilidades.Administrador()  %>' ID="lnkEditTarefa" runat="server" NavigateUrl='<%# Eval("ID", "/ComunidadePreventivasVoc/Lists/Tarefas da Pauta/EditForm.aspx?ID={0}&Source=/ComunidadePreventivasVoc/Paginas/Reuniao.aspx")  %>'><img  alt="Editar" src="/images/Editar.png" /></asp:HyperLink>
                        </DataItemTemplate>
                        <HeaderStyle BackColor="White">
                            <Border BorderStyle="None" />
                        </HeaderStyle>
                    </dx:GridViewDataColumn>

                </Columns>

                <Templates>
                    <DetailRow>


                        <table style="width: 100%">
                            <tr>
                                <td class="ms-formlabel">Detalhes da tarefa
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <!-- inicio do detailrow do detalhe das tarefas  -->
                                    <table class="ms-formtable" style="width: 100%;">

                                        <tbody>

                                           
                                            

                                            <tr>

                                                <td class="ms-formlabel">Descrição: </td>
                                                <td class="ms-formbody">
                                                    <asp:Label ID="Label1" runat="server" Text='<%#  Eval("Descricao") %>' /></td>

                                            </tr>

                                            <tr>
                                                <td class="ms-formlabel">Detalhes:  

                                                    

                                                </td>
                                                <td class="ms-formbody">
                                            
                                            <!-- inicio do ultimo detalhamento -->

                                                      <asp:HiddenField ID="ctl_id_tarefa" runat="server" Value='<%# Eval("ID") %>' />
                                    

                                                    

                                                    <asp:ObjectDataSource ID="dsItemTarefa" runat="server" SelectMethod="ListaItemTarefasGrid" InsertMethod="AdicionaItemTarefa" UpdateMethod="AtualizaItemTarefa" DeleteMethod="DeletaItemTarefa"  TypeName="com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts.ctlPautas" DataObjectTypeName="com.sandigital.sharepoint.webparts.Modelos.ItemTarefa">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="ctl_id_pauta" Name="id_pauta" PropertyName="Value" Type="Int32" />
                                                            <asp:ControlParameter ControlID="ctl_id_tarefa" Name="id_tarefa" PropertyName="Value" Type="Int32" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>


                                                    <dx:ASPxGridView ID="dGridItemTarefa" Width="100%" runat="server" DataSourceID="dsItemTarefa" KeyFieldName="ID" AutoGenerateColumns="False" OnRowInserting="dGridItemTarefa_RowInserting" OnRowDeleted="dGridItemTarefa_RowDeleted" OnRowInserted="dGridItemTarefa_RowInserted" OnRowUpdated="dGridItemTarefa_RowUpdated"  OnRowUpdating="dGridItemTarefa_RowUpdating" EnableCallBacks="False" OnCommandButtonInitialize="dGridItemTarefa_CommandButtonInitialize" >
                                                        
                                                        <settingsbehavior allowsort="False" ConfirmDelete="True" />
                                                         <settingspager visible="False" Mode="ShowAllRecords" />
                                                         <settingsediting editformcolumncount="1" />
                                                         <settings gridlines="Horizontal" showcolumnheaders="True" ShowTitlePanel="True" />
                                                         <settingstext emptydatarow="Sem detalhes adicionados" ConfirmDelete="Deseja mesmo excluir este item? Esta operação não tem retorno!" CommandCancel="Fechar" CommandDelete="Remover" CommandEdit="Editar" CommandUpdate="Salvar" />
                                                         <settingsloadingpanel text="Aguarde&amp;hellip;" />
                         

                                                        <Columns>
                                                              <dx:GridViewCommandColumn ButtonType="Image" Caption="  " VisibleIndex="7" Width="50px"    >
                                                                  <editbutton   Visible="true" >
                                                                      <image alternatetext="Editar" url="~/images/Editar.png" />
                                                                  </editbutton>
                                                                  <deletebutton visible="True">
                                                                    <image url="~/images/Excluir.png" />
                                                                  </deletebutton>
                                                                  <cancelbutton>
                                                                      <image url="~/images/Excluir.png"/>
                                                                  </cancelbutton>
                                                                  <updatebutton>
                                                                      <image url="~/images/Salvar.png"/>
                                                                  </updatebutton>
                                                              </dx:GridViewCommandColumn>
                                            
                                                              <dx:GridViewDataTextColumn FieldName="ID" Visible="False" VisibleIndex="0"  />
                                            
                                                              <dx:GridViewDataTextColumn FieldName="ID_TAREFA" Visible="False" VisibleIndex="1" />

                                                                <dx:GridViewDataDateColumn FieldName="dt_reuniao" Caption="Reunião" VisibleIndex="1" Width="40px">

                                                                   
                                                                    <PropertiesDateEdit DisplayFormatInEditMode="True" DisplayFormatString="dd/MM/yyyy" Width="150px">
                                                                    </PropertiesDateEdit>
                                                                    <EditFormSettings Caption="Data da reunião" />

                                                                   
                                                                </dx:GridViewDataDateColumn>

                                                              <dx:GridViewDataComboBoxColumn FieldName="Status" VisibleIndex="2" Width="60px">
                                                            
                                                                   <propertiescombobox width="150px">
                                                                       <Items>
                                                                            




<dx:ListEditItem Text="Não Iniciada" Value="Não Iniciada"></dx:ListEditItem>
                                                                           
                                                                            




<dx:ListEditItem Text="Informação" Value="Informação" />
                                                                           
                                                                            




<dx:ListEditItem Text="Aguardando Outra Pessoa" Value="Aguardando Outra Pessoa"></dx:ListEditItem>
                                                                           
                                                                            




<dx:ListEditItem Text="Em Andamento" Value="Em Andamento"></dx:ListEditItem>
                                                                           
                                                                            




<dx:ListEditItem Text="Adiado" Value="Adiado"></dx:ListEditItem>
                                                                           
                                                                            




<dx:ListEditItem Text="Concluído" Value="Concluído"></dx:ListEditItem>

                                                                       
                                                                        




</Items>

<validationsettings>
<requiredfield isrequired="True" />
</validationsettings>
</propertiescombobox>
                                                               
                                                               </dx:GridViewDataComboBoxColumn>




                                                          
                                                            <dx:GridViewDataDateColumn FieldName="Prazo" Caption="Prazo" VisibleIndex="3" Width="40px">
                                                            <PropertiesDateEdit DisplayFormatInEditMode="True" DisplayFormatString="dd/MM/yyyy" Width="150px">
                                                            </PropertiesDateEdit>
                                                            <EditFormSettings Caption="Prazo" />
                                                            </dx:GridViewDataDateColumn>





                                                              <dx:GridViewDataTextColumn Caption="Responsável" FieldName="Responsavel" Name="Responsavel" ShowInCustomizationForm="True" VisibleIndex="4" Width="60px">
                                                                  <dataitemtemplate>
                                                                      <asp:Label ID="lblDispUsuario" runat="server" Text='<%#    Convert.ToString( Eval("LoginResponsavel")).Replace("EMBRATEL\\","")    %>'></asp:Label>
                                                                  </dataitemtemplate>

                                                                  <EditItemTemplate>
                                                                      
                                                                      <SharePoint:PeopleEditor ID="pppAdd"    SelectionSet="User" runat="server" MultiSelect="false" Width="100%"  BorderStyle="Solid" BorderColor="Black" BorderWidth="1"     CommaSeparatedAccounts='<%#Eval("Responsavel") %>' />
                                                                   
                                                                  </EditItemTemplate>


                                                              </dx:GridViewDataTextColumn>



                                                              <dx:GridViewDataTextColumn Caption="Título" FieldName="Titulo" VisibleIndex="5">
                                                                  <propertiestextedit maxlength="255"></propertiestextedit>
                                                                  
                                                                  
                                                                  <editformsettings caption="Título" />

                                                                  


                                                                  <dataitemtemplate>
                                                                     
                                                             
                                                                      <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("ID","<a href=\"#\" data-toggle=\"modal\" data-target=\"#MDL2{0}\" > ") %>' />
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Titulo") %>' />
                    </a>
                            &nbsp;
                                                                               
                                                                      
                                                                      
                                                                      <!-- inicio do Modal de detalhe do ItemTarefa -->
                <div class="modal fade" id='<%# Eval("ID","MDL2{0}" ) %>' tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Fechar</span></button>
                                <h4 class="modal-title" id="H1">Detalhes da tarefa:
                                    <asp:Label ID="lbldPautaTituloCab2" runat="server" Text='<%#Eval("Titulo") %>' />
                                </h4>
                            </div>
                            <div class="modal-body">
		                	<asp:Label id="bllDet" runat="server" Text='<%# Convert.ToString( Eval("Detalhes")).Replace("\n", @"<br/>") %>' />

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Fechar</button>
                            </div>
                        </div>
                    </div>
                </div>






                                                                  </dataitemtemplate>

                                                                  


                                                              </dx:GridViewDataTextColumn>




                                                              <dx:GridViewDataMemoColumn FieldName="Detalhes" VisibleIndex="6"  Caption="Detalhes" Visible="False" >
                                                                  <propertiesmemoedit height="250px"></propertiesmemoedit>
                                                                  <EditFormSettings Caption="Detalhes" CaptionLocation="Top" Visible="True" />
                                                              </dx:GridViewDataMemoColumn>

                                                             
                                        
                                                          </Columns>
                                                                    
                                                         
                                                        <Templates>

                                                            <TitlePanel>
                                                                 <div style="float:right;"> 
                                                                      <asp:LinkButton ID="lnkAddNewItemTarefa" runat="server" CssClass="more" OnClick="lnkAddNewItemTarefa_Click" CommandArgument='<%#Eval("ID") %>' Text="Adicionar novo" />
                                                                 </div>
                                                           </TitlePanel>

                                                        </Templates>



                                                    </dx:ASPxGridView>





                                            <!-- fim do utlimo detalhamento -->
                                                    </td>
                                                </tr>







                                        </tbody>

                                    </table>

                                 
                                   
                                    


                                    <br />
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="" style="width: 140px">
                                                <asp:Label ID="lblAnexosTarefa" runat="server" Text="Anexos" Visible='<%# !String.IsNullOrEmpty(  Eval("Anexos").ToString())  %>' />
                                            </td>
                                            <td class="">
                                                <asp:Label ID="lblAnexos" runat="server" Text='<%# Eval("Anexos") %>' />
                                            </td>
                                        </tr>
                                    </table>


                                    <!-- fim do detailrow do detalhe das tarefas -->

                                </td>
                            </tr>
                        </table>








                    </DetailRow>
                </Templates>



            </dx:ASPxGridView>






            <!-- fim do detailrow do grid pautas-->
        </DetailRow>

    </Templates>



</dx:ASPxGridView>



<!-- Fim do Grid de Pautas -->







