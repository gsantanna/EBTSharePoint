<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlPainelProdutividade.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts.ctlPainelProdutividade" %>


<%@ Register Assembly="DevExpress.XtraCharts.v12.1.Web, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>















<%@ Register assembly="DevExpress.Web.ASPxGridView.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v12.1.Export, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>















<h2 class="text-center">Painel Produtividade</h2>




<!-- Painel 1 -->

<div style="width: 1000px; padding-left: 10px; padding-top: 10px; padding-bottom: 10px; margin: auto; vertical-align: top; border: 1px solid #b0b0b0; background-color: #ededed" class="text-center">

    <table>
        <tr>
            <td>Data Inicio:</td>

            <td style="width: 10px;"></td>
            <td>
                <dx:ASPxDateEdit ID="cboDtInicio" runat="server" Width="100px">
                    <ValidationSettings ErrorText="*">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxDateEdit>
            </td>
            <td style="width: 10px;"></td>
            <td>Data Fim: </td>
            <td style="width: 10px;"></td>

            <td>
                <dx:ASPxDateEdit ID="cboDtFim" runat="server" Width="100px">
                    <ValidationSettings ErrorText="*">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxDateEdit>
            </td>
            <td style="width: 10px">&nbsp;</td>
            <td>
                <asp:Button runat="server" ID="btnGerar" CssClass="btn btn-sm btn-primary" Text="Gerar" OnClick="btnGerar_Click" />
            <asp:LinkButton  ID="btnExportarExcel"  CssClass="btn btn-sm btn-primary " runat="server" OnClick="btnExportarExcel_Click">
                <span class="glyphicon glyphicon-floppy-disk" style="color:white;">
                Exportar</span>
            </asp:LinkButton>
            
            </td>
            <td style="width: 10px">&nbsp;</td>
            <td>
                <asp:Label ID="lblAviso" runat="server"></asp:Label></td>



        </tr>
    </table>

</div>
<div style="height: 10px; min-height: 10px; width: 100%;">
</div>
<asp:Panel runat="server" ID="pnlMain" Visible="false">

    <div style="width: 1000px; margin: auto; vertical-align: top;" class="text-center">

        <dxchartsui:WebChartControl ID="chartTop" runat="server" Height="350px" PaletteName="Flow" Width="1000px">
            <emptycharttext text="Sem dados" />
            <smallcharttext text="Aumente a área para o gráfico ficar visivel" />
            <fillstyle><OptionsSerializable><cc1:SolidFillOptions></cc1:SolidFillOptions></OptionsSerializable></fillstyle>

            <legend visible="True"></legend>

            <seriestemplate><ViewSerializable><cc1:SideBySideBarSeriesView></cc1:SideBySideBarSeriesView></ViewSerializable><LabelSerializable><cc1:SideBySideBarSeriesLabel LineVisible="True"><FillStyle><OptionsSerializable><cc1:SolidFillOptions></cc1:SolidFillOptions></OptionsSerializable></FillStyle><PointOptionsSerializable><cc1:PointOptions></cc1:PointOptions></PointOptionsSerializable></cc1:SideBySideBarSeriesLabel></LabelSerializable><LegendPointOptionsSerializable><cc1:PointOptions></cc1:PointOptions></LegendPointOptionsSerializable></seriestemplate>

            <titles><cc1:ChartTitle Text="Produtividade Noc" /></titles>

            <crosshairoptions><CommonLabelPositionSerializable><cc1:CrosshairMousePosition></cc1:CrosshairMousePosition></CommonLabelPositionSerializable></crosshairoptions>

            <tooltipoptions><ToolTipPositionSerializable><cc1:ToolTipMousePosition></cc1:ToolTipMousePosition></ToolTipPositionSerializable></tooltipoptions>
        </dxchartsui:WebChartControl>

        <div style="height: 10px; min-height: 10px; width: 100%;"></div>


        

        
        <dxchartsui:WebChartControl ID="chrEvolDiaria" runat="server" Width="1000px">
            <diagramserializable>
                <cc1:XYDiagram>
                    <axisx visibleinpanesserializable="-1">
                        <scalebreakoptions sizeinpixels="3" />
                        <range sidemarginsenabled="True" />
                    </axisx>
                    <axisy visibleinpanesserializable="-1">
                        <range sidemarginsenabled="True" />
                    </axisy>
                </cc1:XYDiagram>
            </diagramserializable>
            <fillstyle>
                <optionsserializable>
                    <cc1:SolidFillOptions />
                </optionsserializable>
            </fillstyle>
            <legend visible="False"></legend>
            <seriesserializable>
                <cc1:Series LabelsVisibility="True" Name="Series 1">
                    <viewserializable>
                        <cc1:SideBySideBarSeriesView BarWidth="0.2">
                        </cc1:SideBySideBarSeriesView>
                    </viewserializable>
                    <labelserializable>
                        <cc1:SideBySideBarSeriesLabel LineVisible="True" ShowForZeroValues="True">
                            <fillstyle>
                                <optionsserializable>
                                    <cc1:SolidFillOptions />
                                </optionsserializable>
                            </fillstyle>
                            <pointoptionsserializable>
                                <cc1:PointOptions>
                                </cc1:PointOptions>
                            </pointoptionsserializable>
                        </cc1:SideBySideBarSeriesLabel>
                    </labelserializable>
                    <legendpointoptionsserializable>
                        <cc1:PointOptions>
                        </cc1:PointOptions>
                    </legendpointoptionsserializable>
                </cc1:Series>
            </seriesserializable>
            <seriestemplate>
                <viewserializable>
                    <cc1:SideBySideBarSeriesView>
                    </cc1:SideBySideBarSeriesView>
                </viewserializable>
                <labelserializable>
                    <cc1:SideBySideBarSeriesLabel LineVisible="True">
                        <fillstyle>
                            <optionsserializable>
                                <cc1:SolidFillOptions />
                            </optionsserializable>
                        </fillstyle>
                        <pointoptionsserializable>
                            <cc1:PointOptions>
                            </cc1:PointOptions>
                        </pointoptionsserializable>
                    </cc1:SideBySideBarSeriesLabel>
                </labelserializable>
                <legendpointoptionsserializable>
                    <cc1:PointOptions>
                    </cc1:PointOptions>
                </legendpointoptionsserializable>
            </seriestemplate>
            <titles>
                <cc1:ChartTitle Text="Evolução Diária" />
            </titles>
            <crosshairoptions>
                <commonlabelpositionserializable>
                    <cc1:CrosshairMousePosition />
                </commonlabelpositionserializable>
            </crosshairoptions>
            <tooltipoptions>
                <tooltippositionserializable>
                    <cc1:ToolTipMousePosition />
                </tooltippositionserializable>
            </tooltipoptions>
        </dxchartsui:WebChartControl>


        <div style="height: 10px; min-height: 10px; width: 100%;"></div>

        


        <!-- cards -->
        <div style="width: 600px; float: left;">

            <div style="width: 590px; min-height: 500px; overflow-y: auto; border: 1px solid #727272">

                <h2>Ranking de Produtividade Mensal</h2>

                <style type="text/css">
                    .tabelaBsc {
                        border-spacing: 0px;
                        border-collapse: separate;
                        width: 580px;
                        padding-left: 5px;
                        vertical-align: top;
                        border: 1px solid #727272;
                    }

                    .tabelaBscPeriodo {
                        border: 1px solid #727272;
                    }

                    .tabelaBscFoto {
                        border: 1px solid #727272;
                        background-color: #eaeaea;
                        font-weight: bold;
                    }

                    .tabelaBscNome {
                        width: 180px;
                        vertical-align: top;
                        padding-top: 20px;
                    }

                    .tabelaBscMiniGrafico {
                    }
                </style>

                <table class="tabelaBsc">
                    <tr>
                        <td style="width: 75px"></td>
                        <td class=""></td>


                        
                                <td class="tabelaBscPeriodo"></td>
                          



                    </tr>




                    <asp:Repeater ID="rptBscItens" runat="server">

                        <ItemTemplate>


                            <tr>

                                <td class="tabelaBscFoto "><%# Eval("Rank") %><br />
                                    <img style="width: 75px; height: 90px;" alt='<%#Eval("Funcionario" ) %>' src='<%#Eval("Foto") %>' />

                                </td>

                                <td class="tabelaBscNome">

                                    <strong><%#Eval("Funcionario") %></strong>

                                    <table style="width: 100%; text-align: left; margin-left: 10px;">


                                        <tr>
                                            <td>Horas:</td>
                                            <td><%#Eval("qtdHoras") %></td>
                                        </tr>

                                        <tr>
                                            <td>Recs:</td>
                                            <td><%#Eval("qtdRecs") %></td>
                                        </tr>

                                        <tr>
                                            <td>Prod:</td>
                                            <td><%# Eval("Prod","{0:0.00}") %></td>
                                        </tr>


                                    </table>


                                </td>

                                <td  class="tabelaBscMiniGrafico">







                                    <dxchartsui:WebChartControl ID="MiniGrafico" runat="server"
                                        DataSourceID="dsMiniGrafico" SeriesDataMember="Funcionario" Height="100px" Width="320px" AppearanceNameSerializable="Gray" PaletteBaseColorNumber="1" PaletteName="Office">




                                        <diagramserializable>
                                            <cc1:XYDiagram>
                                                
                                                
<AxisY VisibleInPanesSerializable="-1" visible="False">
<Range SideMarginsEnabled="False"></Range></AxisY>



                                                
                                                <margins bottom="10" left="0" right="0" top="10" /></cc1:XYDiagram></diagramserializable>

                                        <fillstyle><OptionsSerializable><cc1:SolidFillOptions></cc1:SolidFillOptions></OptionsSerializable></fillstyle>

                                        <legend visible="False"></legend>
                                        <seriestemplate labelsvisibility="True"
                                            argumentdatamember="Periodo"
                                            valuedatamembersserializable="QtdRecs">
                                            
                                            <viewserializable><cc1:LineSeriesView></cc1:LineSeriesView></viewserializable>
                                            <labelserializable><cc1:PointSeriesLabel LineVisible="True">
                                                <fillstyle>
                                                    <optionsserializable>
                                                        <cc1:SolidFillOptions />
                                                           </optionsserializable></fillstyle>
                                                <pointoptionsserializable><cc1:PointOptions></cc1:PointOptions></pointoptionsserializable></cc1:PointSeriesLabel>

                                            </labelserializable><legendpointoptionsserializable><cc1:PointOptions></cc1:PointOptions></legendpointoptionsserializable></seriestemplate>

                                        <crosshairoptions><CommonLabelPositionSerializable><cc1:CrosshairMousePosition></cc1:CrosshairMousePosition></CommonLabelPositionSerializable></crosshairoptions>

                                        <tooltipoptions><ToolTipPositionSerializable><cc1:ToolTipMousePosition></cc1:ToolTipMousePosition></ToolTipPositionSerializable></tooltipoptions>




                                    </dxchartsui:WebChartControl>

                                    <asp:HiddenField ID="hUsuario" runat="server" Value='<%#Eval("id_usuario") %>' />
                                    <asp:HiddenField runat="server" ID="hdt_ini" Value='<%# Eval("Dt_Inicio") %>' />
                                    <asp:HiddenField runat="server" ID="hdt_fim" Value='<%# Eval("Dt_Fim") %>' />

                                    <asp:ObjectDataSource runat="server" SelectMethod="GetEvolucaoMensal" ID="dsMiniGrafico" TypeName="com.sandigital.sharepoint.webparts.Modelos.Produtividade">

                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="hdt_ini" Name="dt_ini" PropertyName="Value" Type="DateTime" />
                                            <asp:ControlParameter ControlID="hdt_fim" Name="dt_fim" PropertyName="Value" Type="DateTime" />
                                            <asp:ControlParameter ControlID="hUsuario" Name="id_usuario" PropertyName="Value" Type="String" />
                                        </SelectParameters>

                                    </asp:ObjectDataSource>










                                </td>






                            </tr>

                        </ItemTemplate>

                    </asp:Repeater>









                </table>

            </div>


        </div>







        <!-- Right -->
        <div style="width: 390px; float: right">
            <!-- Geral -->
            <dxchartsui:WebChartControl ID="chartRight" runat="server" AppearanceNameSerializable="Gray" Height="260px" PaletteBaseColorNumber="6" PaletteName="Urban" Width="390px">
                <emptycharttext text="Sem dados
" />
                <diagramserializable><cc1:XYDiagram><axisx visibleinpanesserializable="-1"><range sidemarginsenabled="True" /></axisx><axisy visibleinpanesserializable="-1"><range sidemarginsenabled="True" AlwaysShowZeroLevel="False" /></axisy></cc1:XYDiagram></diagramserializable>
                <fillstyle><OptionsSerializable><cc1:SolidFillOptions></cc1:SolidFillOptions></OptionsSerializable></fillstyle>

                <legend visible="False"></legend>
                <seriesserializable><cc1:Series Name="Evolucao"><viewserializable><cc1:LineSeriesView></cc1:LineSeriesView></viewserializable><labelserializable><cc1:PointSeriesLabel LineVisible="True"><fillstyle><optionsserializable><cc1:SolidFillOptions /></optionsserializable></fillstyle><pointoptionsserializable><cc1:PointOptions></cc1:PointOptions></pointoptionsserializable></cc1:PointSeriesLabel></labelserializable><legendpointoptionsserializable><cc1:PointOptions></cc1:PointOptions></legendpointoptionsserializable></cc1:Series></seriesserializable>
                <seriestemplate><viewserializable><cc1:LineSeriesView></cc1:LineSeriesView></viewserializable><labelserializable><cc1:PointSeriesLabel LineVisible="True"><fillstyle><optionsserializable><cc1:SolidFillOptions /></optionsserializable></fillstyle><pointoptionsserializable><cc1:PointOptions></cc1:PointOptions></pointoptionsserializable></cc1:PointSeriesLabel></labelserializable><legendpointoptionsserializable><cc1:PointOptions></cc1:PointOptions></legendpointoptionsserializable></seriestemplate>

                <titles><cc1:ChartTitle Text="Geral" /></titles>

                <crosshairoptions><CommonLabelPositionSerializable><cc1:CrosshairMousePosition></cc1:CrosshairMousePosition></CommonLabelPositionSerializable></crosshairoptions>

                <tooltipoptions><ToolTipPositionSerializable><cc1:ToolTipMousePosition></cc1:ToolTipMousePosition></ToolTipPositionSerializable></tooltipoptions>
            </dxchartsui:WebChartControl>
        </div>


        <div style="width: 390px; height: 10px; float: right"></div>

        <!-- Right 2 -->
        <div style="width: 390px; float: right">
          
            
            


        </div>
        <!-- fim right 2-->





    </div>


</asp:Panel>









<p>
    &nbsp;</p>










<dx:ASPxGridView ID="dGridExport" runat="server" Visible="False">
</dx:ASPxGridView>
<dx:ASPxGridViewExporter ID="dGridExportExporter" runat="server" GridViewID="dGridExport" PreserveGroupRowStates="True">
</dx:ASPxGridViewExporter>











