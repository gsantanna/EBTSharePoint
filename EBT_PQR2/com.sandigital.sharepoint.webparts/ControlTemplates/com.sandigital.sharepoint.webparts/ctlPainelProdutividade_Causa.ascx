<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlPainelProdutividade_Causa.ascx.cs" Inherits="com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts.ctlPainelProdutividade_Causa" %>


<%@ Register Assembly="DevExpress.XtraCharts.v12.1.Web, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>















<h2 class="text-center">Painel Produtividade - Análise de Causas</h2>




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

        





          <dxchartsui:WebChartControl ID="chartCausas" runat="server" Height="300px" PaletteName="EBT_Primaria" Width="1000px">
            <diagramserializable>
                <cc1:XYDiagram PaneDistance="8">
                    <axisx visibleinpanesserializable="-1">
                        <range sidemarginsenabled="True" />
                    </axisx>
                    <axisy visibleinpanesserializable="-1">
                        <range sidemarginsenabled="True" />
                    </axisy>
                    <margins left="1" right="1" />
                </cc1:XYDiagram>
            </diagramserializable>
<FillStyle><OptionsSerializable>
<cc1:SolidFillOptions></cc1:SolidFillOptions>
</OptionsSerializable>
</FillStyle>

            <legend alignmenthorizontal="Center" alignmentvertical="BottomOutside" direction="LeftToRight" equallyspaceditems="False" markersize="10, 10"></legend>
            <seriesserializable>
                <cc1:Series Name="Series 1">
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
                </cc1:Series>
                <cc1:Series Name="Series 2">
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
                </cc1:Series>
            </seriesserializable>

<SeriesTemplate><ViewSerializable>
<cc1:SideBySideBarSeriesView></cc1:SideBySideBarSeriesView>
</ViewSerializable>
<LabelSerializable>
<cc1:SideBySideBarSeriesLabel LineVisible="True">
<FillStyle><OptionsSerializable>
<cc1:SolidFillOptions></cc1:SolidFillOptions>
</OptionsSerializable>
</FillStyle>
<PointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</PointOptionsSerializable>
</cc1:SideBySideBarSeriesLabel>
</LabelSerializable>
<LegendPointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</LegendPointOptionsSerializable>
</SeriesTemplate>

            <titles>
                <cc1:ChartTitle Text="Causas" />
            </titles>
            <palettewrappers>
                <dxchartsui:PaletteWrapper Name="EBT_Primaria" ScaleMode="Repeat">
                     <palette>
                        <cc1:PaletteEntry Color="79, 129, 189" Color2="51, 90, 136" />
                        <cc1:PaletteEntry Color="192, 80, 77" Color2="139, 52, 49" />
                        <cc1:PaletteEntry Color="155, 187, 89" Color2="111, 137, 56" />
                        <cc1:PaletteEntry Color="128, 100, 162" Color2="89, 69, 115" />
                        <cc1:PaletteEntry Color="75, 172, 198" Color2="46, 124, 145" />
                        <cc1:PaletteEntry Color="128, 0, 64" Color2="128, 0, 64" />
                        <cc1:PaletteEntry Color="186, 252, 188" Color2="186, 252, 188" />
                        <cc1:PaletteEntry Color="234, 117, 0" Color2="234, 117, 0" />
                        <cc1:PaletteEntry Color="Yellow" Color2="Yellow" />
                        <cc1:PaletteEntry Color="128, 128, 255" Color2="128, 128, 255" />
                        <cc1:PaletteEntry Color="255, 128, 192" Color2="255, 128, 192" />
                        <cc1:PaletteEntry Color="0, 128, 255" Color2="0, 128, 255" />
                        <cc1:PaletteEntry Color="64, 128, 128" Color2="64, 128, 128" />
                        <cc1:PaletteEntry Color="Red" Color2="Red" />
                        <cc1:PaletteEntry Color="Lime" Color2="Lime" />
                        <cc1:PaletteEntry Color="164, 164, 164" Color2="164, 164, 164" />
                        <cc1:PaletteEntry Color="Blue" Color2="Blue" />
                        <cc1:PaletteEntry Color="217, 241, 180" Color2="217, 241, 180" />
                        <cc1:PaletteEntry Color="255, 0, 128" Color2="255, 0, 128" />
                        <cc1:PaletteEntry Color="154, 133, 252" Color2="154, 133, 252" />
                        <cc1:PaletteEntry Color="0, 64, 64" Color2="0, 64, 64" />
                        <cc1:PaletteEntry Color="Olive" Color2="Olive" />
                    </palette>




                </dxchartsui:PaletteWrapper>
            </palettewrappers>

<CrosshairOptions><CommonLabelPositionSerializable>
<cc1:CrosshairMousePosition></cc1:CrosshairMousePosition>
</CommonLabelPositionSerializable>
</CrosshairOptions>

<ToolTipOptions><ToolTipPositionSerializable>
<cc1:ToolTipMousePosition></cc1:ToolTipMousePosition>
</ToolTipPositionSerializable>
</ToolTipOptions>
        </dxchartsui:WebChartControl>
        <br />
 
        <dxchartsui:WebChartControl ID="chartTratamento" runat="server" Height="300px" PaletteName="EBT_Primaria" Width="1000px">
            <diagramserializable>
                <cc1:XYDiagram PaneDistance="8">
                    <axisx visibleinpanesserializable="-1">
                        <range sidemarginsenabled="True" />
                    </axisx>
                    <axisy visibleinpanesserializable="-1">
                        <range sidemarginsenabled="True" />
                    </axisy>
                    <margins left="1" right="1" />
                </cc1:XYDiagram>
            </diagramserializable>
<FillStyle><OptionsSerializable>
<cc1:SolidFillOptions></cc1:SolidFillOptions>
</OptionsSerializable>
</FillStyle>

            <legend alignmenthorizontal="Center" alignmentvertical="BottomOutside" direction="LeftToRight" equallyspaceditems="False" markersize="10, 10"></legend>
            <seriesserializable>
                <cc1:Series Name="Series 1">
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
                </cc1:Series>
                <cc1:Series Name="Series 2">
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
                </cc1:Series>
            </seriesserializable>

<SeriesTemplate><ViewSerializable>
<cc1:SideBySideBarSeriesView></cc1:SideBySideBarSeriesView>
</ViewSerializable>
<LabelSerializable>
<cc1:SideBySideBarSeriesLabel LineVisible="True">
<FillStyle><OptionsSerializable>
<cc1:SolidFillOptions></cc1:SolidFillOptions>
</OptionsSerializable>
</FillStyle>
<PointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</PointOptionsSerializable>
</cc1:SideBySideBarSeriesLabel>
</LabelSerializable>
<LegendPointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</LegendPointOptionsSerializable>
</SeriesTemplate>

            <titles>
                <cc1:ChartTitle Text="Rec indevida pela NET" />
            </titles>
            <palettewrappers>
                <dxchartsui:PaletteWrapper Name="EBT_Primaria" ScaleMode="Repeat">
                    <palette>
 
                        <cc1:PaletteEntry Color="79, 129, 189" Color2="51, 90, 136" />
                        <cc1:PaletteEntry Color="192, 80, 77" Color2="139, 52, 49" />
                        <cc1:PaletteEntry Color="155, 187, 89" Color2="111, 137, 56" />
                        <cc1:PaletteEntry Color="128, 100, 162" Color2="89, 69, 115" />
                        <cc1:PaletteEntry Color="75, 172, 198" Color2="46, 124, 145" />
                        <cc1:PaletteEntry Color="128, 0, 64" Color2="128, 0, 64" />
                        <cc1:PaletteEntry Color="186, 252, 188" Color2="186, 252, 188" />
                        <cc1:PaletteEntry Color="234, 117, 0" Color2="234, 117, 0" />
                        <cc1:PaletteEntry Color="Yellow" Color2="Yellow" />
                        <cc1:PaletteEntry Color="128, 128, 255" Color2="128, 128, 255" />
                        <cc1:PaletteEntry Color="255, 128, 192" Color2="255, 128, 192" />
                        <cc1:PaletteEntry Color="0, 128, 255" Color2="0, 128, 255" />
                        <cc1:PaletteEntry Color="64, 128, 128" Color2="64, 128, 128" />
                        <cc1:PaletteEntry Color="Red" Color2="Red" />
                        <cc1:PaletteEntry Color="Lime" Color2="Lime" />
                        <cc1:PaletteEntry Color="164, 164, 164" Color2="164, 164, 164" />
                        <cc1:PaletteEntry Color="Blue" Color2="Blue" />
                        <cc1:PaletteEntry Color="217, 241, 180" Color2="217, 241, 180" />
                        <cc1:PaletteEntry Color="255, 0, 128" Color2="255, 0, 128" />
                        <cc1:PaletteEntry Color="154, 133, 252" Color2="154, 133, 252" />
                        <cc1:PaletteEntry Color="0, 64, 64" Color2="0, 64, 64" />
                        <cc1:PaletteEntry Color="Olive" Color2="Olive" />
                    </palette>

                 
                </dxchartsui:PaletteWrapper>
            </palettewrappers>

<CrosshairOptions><CommonLabelPositionSerializable>
<cc1:CrosshairMousePosition></cc1:CrosshairMousePosition>
</CommonLabelPositionSerializable>
</CrosshairOptions>

<ToolTipOptions><ToolTipPositionSerializable>
<cc1:ToolTipMousePosition></cc1:ToolTipMousePosition>
</ToolTipPositionSerializable>
</ToolTipOptions>
        </dxchartsui:WebChartControl>
 


        <br />
        





    </div>


</asp:Panel>









