﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace com.sandigital.sharepoint.webparts.EventosDeRede {
    using DevExpress.Web.ASPxEditors;
    using System.Web.Security;
    using DevExpress.Web.ASPxGridView;
    using System.Web.UI.WebControls;
    using System.Web;
    using Microsoft.SharePoint.Utilities;
    using System.Text.RegularExpressions;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using Microsoft.SharePoint.WebPartPages;
    using Microsoft.SharePoint;
    using System.Configuration;
    using System;
    using System.Text;
    using System.Web.Profile;
    using System.Web.Caching;
    using System.Collections;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.SharePoint.WebControls;
    using System.Collections.Specialized;
    using System.Web.SessionState;
    
    
    public partial class EventosDeRede {
        
        protected global::System.Web.UI.WebControls.LinqDataSource dsEventos;
        
        protected global::DevExpress.Web.ASPxGridView.ASPxGridView dGridEventos;
        
        public static implicit operator global::System.Web.UI.TemplateControl(EventosDeRede target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.LinqDataSource @__BuildControldsEventos() {
            global::System.Web.UI.WebControls.LinqDataSource @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.LinqDataSource();
            this.dsEventos = @__ctrl;
            @__ctrl.ID = "dsEventos";
            @__ctrl.ContextTypeName = "com.sandigital.sharepoint.dal.EventoRedeDataContext";
            @__ctrl.TableName = "Evento";
            @__ctrl.OrderBy = "Inicio desc";
            @__ctrl.Where = "Inicio >= DateTime.Now.AddDays(-7)";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control3(DevExpress.Web.ASPxGridView.GridViewHeaderStyle @__ctrl) {
            @__ctrl.CssClass = "vEventosHeader";
            @__ctrl.Font.Bold = true;
            @__ctrl.ForeColor = ((System.Drawing.Color)(System.Drawing.Color.FromArgb(0, 61, 117)));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control4(DevExpress.Web.ASPxGridView.GridViewCellStyle @__ctrl) {
            @__ctrl.CssClass = "vEventosCell";
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control2(DevExpress.Web.ASPxGridView.GridViewStyles @__ctrl) {
            this.@__BuildControl__control3(@__ctrl.Header);
            this.@__BuildControl__control4(@__ctrl.Cell);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control6(DevExpress.Web.ASPxPager.SummaryProperties @__ctrl) {
            @__ctrl.AllPagesText = "Páginas: {0} - {1} ({2} Eventos)";
            @__ctrl.Text = "Página {0} de {1} ({2} Eventos)";
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control5(DevExpress.Web.ASPxGridView.ASPxGridViewPagerSettings @__ctrl) {
            @__ctrl.Mode = DevExpress.Web.ASPxGridView.GridViewPagerMode.ShowPager;
            @__ctrl.Visible = true;
            this.@__BuildControl__control6(@__ctrl.Summary);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.ASPxGridViewTemplateReplacement @__BuildControl__control9() {
            global::DevExpress.Web.ASPxGridView.ASPxGridViewTemplateReplacement @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.ASPxGridViewTemplateReplacement();
            @__ctrl.TemplateControl = this;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "ASPxGridViewTemplateReplacement1";
            @__ctrl.ReplacementType = DevExpress.Web.ASPxGridView.GridViewTemplateReplacementType.Pager;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control8(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n                       \r\n                        <table style=\"width:100%\">\r\n  " +
                        "                      <tr>\r\n                        <td>"));
            global::DevExpress.Web.ASPxGridView.ASPxGridViewTemplateReplacement @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control9();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl(@"</td>
                        
                        <td style=""width:80px; text-align:right;""> <a href=""//SitePages/Eventos.aspx"">Histórico >></a></td>
                        
                        <td style=""width:10px""> </td>
                        </tr>
                        
                        </table>

                     
                    "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control7(DevExpress.Web.ASPxGridView.GridViewTemplates @__ctrl) {
            @__ctrl.PagerBar = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control8));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control10(DevExpress.Web.ASPxClasses.BorderWrapper @__ctrl) {
            @__ctrl.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control13(DevExpress.Web.ASPxGridView.GridViewHeaderStyle @__ctrl) {
            @__ctrl.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control14(DevExpress.Web.ASPxGridView.GridViewCellStyle @__ctrl) {
            @__ctrl.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control12() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "id_evento";
            @__ctrl.ReadOnly = true;
            @__ctrl.Visible = false;
            @__ctrl.VisibleIndex = 0;
            this.@__BuildControl__control13(@__ctrl.HeaderStyle);
            this.@__BuildControl__control14(@__ctrl.CellStyle);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControl__control18() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "lblEvnt";
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBinding__control18);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        public void @__DataBinding__control18(object sender, System.EventArgs e) {
            System.Web.UI.WebControls.Label dataBindingExpressionBuilderTarget;
            DevExpress.Web.ASPxGridView.GridViewDataItemTemplateContainer Container;
            dataBindingExpressionBuilderTarget = ((System.Web.UI.WebControls.Label)(sender));
            Container = ((DevExpress.Web.ASPxGridView.GridViewDataItemTemplateContainer)(dataBindingExpressionBuilderTarget.BindingContainer));
            dataBindingExpressionBuilderTarget.Text = System.Convert.ToString( Eval("Evento1") , System.Globalization.CultureInfo.CurrentCulture);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.HyperLink @__BuildControl__control17() {
            global::System.Web.UI.WebControls.HyperLink @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.HyperLink();
            @__ctrl.TemplateControl = this;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "lnkEvt";
            global::System.Web.UI.WebControls.Label @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control18();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBinding__control17);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        public void @__DataBinding__control17(object sender, System.EventArgs e) {
            System.Web.UI.WebControls.HyperLink dataBindingExpressionBuilderTarget;
            DevExpress.Web.ASPxGridView.GridViewDataItemTemplateContainer Container;
            dataBindingExpressionBuilderTarget = ((System.Web.UI.WebControls.HyperLink)(sender));
            Container = ((DevExpress.Web.ASPxGridView.GridViewDataItemTemplateContainer)(dataBindingExpressionBuilderTarget.BindingContainer));
            dataBindingExpressionBuilderTarget.NavigateUrl = System.Convert.ToString( string.Format("http://2k8rjoapp007:8080/Registro.aspx?IdControle={0}", Eval("id_evento")  ) , System.Globalization.CultureInfo.CurrentCulture);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control16(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.HyperLink @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control17();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            \r\n            \r\n            "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control19(DevExpress.Web.ASPxGridView.GridViewHeaderStyle @__ctrl) {
            @__ctrl.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control20(DevExpress.Web.ASPxGridView.GridViewCellStyle @__ctrl) {
            @__ctrl.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
            @__ctrl.Wrap = DevExpress.Utils.DefaultBoolean.True;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control15() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.DataItemTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control16));
            @__ctrl.Caption = "Evento";
            @__ctrl.FieldName = "Evento1";
            @__ctrl.VisibleIndex = 0;
            this.@__BuildControl__control19(@__ctrl.HeaderStyle);
            this.@__BuildControl__control20(@__ctrl.CellStyle);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control22(DevExpress.Web.ASPxEditors.DateEditProperties @__ctrl) {
            @__ctrl.DisplayFormatString = "dd/MMM HH:mm";
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control23(DevExpress.Web.ASPxGridView.GridViewHeaderStyle @__ctrl) {
            @__ctrl.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control24(DevExpress.Web.ASPxGridView.GridViewCellStyle @__ctrl) {
            @__ctrl.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataDateColumn @__BuildControl__control21() {
            global::DevExpress.Web.ASPxGridView.GridViewDataDateColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataDateColumn();
            @__ctrl.FieldName = "Inicio";
            @__ctrl.VisibleIndex = 1;
            this.@__BuildControl__control22(@__ctrl.PropertiesDateEdit);
            this.@__BuildControl__control23(@__ctrl.HeaderStyle);
            this.@__BuildControl__control24(@__ctrl.CellStyle);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control26(DevExpress.Web.ASPxGridView.GridViewHeaderStyle @__ctrl) {
            @__ctrl.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control27(DevExpress.Web.ASPxGridView.GridViewCellStyle @__ctrl) {
            @__ctrl.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
            @__ctrl.Wrap = DevExpress.Utils.DefaultBoolean.True;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control25() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "Localidades";
            @__ctrl.VisibleIndex = 2;
            this.@__BuildControl__control26(@__ctrl.HeaderStyle);
            this.@__BuildControl__control27(@__ctrl.CellStyle);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control29(DevExpress.Web.ASPxGridView.GridViewHeaderStyle @__ctrl) {
            @__ctrl.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control30(DevExpress.Web.ASPxGridView.GridViewCellStyle @__ctrl) {
            @__ctrl.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Left;
            @__ctrl.Wrap = DevExpress.Utils.DefaultBoolean.True;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control28() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "Responsavel";
            @__ctrl.Caption = "Responsável";
            @__ctrl.VisibleIndex = 3;
            this.@__BuildControl__control29(@__ctrl.HeaderStyle);
            this.@__BuildControl__control30(@__ctrl.CellStyle);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control11(DevExpress.Web.ASPxGridView.GridViewColumnCollection @__ctrl) {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control12();
            @__ctrl.Add(@__ctrl1);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl2;
            @__ctrl2 = this.@__BuildControl__control15();
            @__ctrl.Add(@__ctrl2);
            global::DevExpress.Web.ASPxGridView.GridViewDataDateColumn @__ctrl3;
            @__ctrl3 = this.@__BuildControl__control21();
            @__ctrl.Add(@__ctrl3);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl4;
            @__ctrl4 = this.@__BuildControl__control25();
            @__ctrl.Add(@__ctrl4);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl5;
            @__ctrl5 = this.@__BuildControl__control28();
            @__ctrl.Add(@__ctrl5);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control31(DevExpress.Web.ASPxGridView.ASPxGridViewSettings @__ctrl) {
            @__ctrl.GridLines = System.Web.UI.WebControls.GridLines.None;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.ASPxGridView @__BuildControldGridEventos() {
            global::DevExpress.Web.ASPxGridView.ASPxGridView @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.ASPxGridView();
            this.dGridEventos = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ApplyStyleSheetThemeInternal();
            @__ctrl.ID = "dGridEventos";
            @__ctrl.AutoGenerateColumns = false;
            @__ctrl.DataSourceID = "dsEventos";
            @__ctrl.KeyFieldName = "id_evento";
            @__ctrl.SettingsPager.PageSize = 5;
            @__ctrl.Width = new System.Web.UI.WebControls.Unit(100, System.Web.UI.WebControls.UnitType.Percentage);
            this.@__BuildControl__control2(@__ctrl.Styles);
            this.@__BuildControl__control5(@__ctrl.SettingsPager);
            this.@__BuildControl__control7(@__ctrl.Templates);
            this.@__BuildControl__control10(@__ctrl.Border);
            this.@__BuildControl__control11(@__ctrl.Columns);
            this.@__BuildControl__control31(@__ctrl.Settings);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::com.sandigital.sharepoint.webparts.EventosDeRede.EventosDeRede @__ctrl) {
            global::System.Web.UI.WebControls.LinqDataSource @__ctrl1;
            @__ctrl1 = this.@__BuildControldsEventos();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        \r\n        \r\n        \r\n\r\n\r\n\r\n<table style=\"width:100%\">\r\n<tr>\r\n\r\n<td>\r\n " +
                        "     "));
            global::DevExpress.Web.ASPxGridView.ASPxGridView @__ctrl2;
            @__ctrl2 = this.@__BuildControldGridEventos();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n\r\n\r\n\r\n            \r\n        \r\n        \r\n        </td>\r\n\r\n        \r\n        </" +
                        "tr>\r\n</table>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n        \r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n        \r\n\r\n\r\n\r\n\r\n\r\n\r\n\r" +
                        "\n"));
        }
        
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}
