﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace com.sandigital.sharepoint.webparts.EventosDeRedeListagem {
    using DevExpress.Web.ASPxMenu;
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
    
    
    public partial class EventosDeRedeListagem {
        
        protected global::DevExpress.Web.ASPxGridView.ASPxGridView dGridEvento;
        
        protected global::System.Web.UI.WebControls.Label lblErro;
        
        public static implicit operator global::System.Web.UI.TemplateControl(EventosDeRedeListagem target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control3(DevExpress.Web.ASPxPager.AllButtonProperties @__ctrl) {
            @__ctrl.Text = "All";
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control4(DevExpress.Web.ASPxPager.NextButtonProperties @__ctrl) {
            @__ctrl.Text = "Next >";
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control5(DevExpress.Web.ASPxPager.PrevButtonProperties @__ctrl) {
            @__ctrl.Text = "< Prev";
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control2(DevExpress.Web.ASPxGridView.ASPxGridViewPagerSettings @__ctrl) {
            @__ctrl.ShowDefaultImages = false;
            this.@__BuildControl__control3(@__ctrl.AllButton);
            this.@__BuildControl__control4(@__ctrl.NextPageButton);
            this.@__BuildControl__control5(@__ctrl.PrevPageButton);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control7() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.Caption = "Pai";
            @__ctrl.FieldName = "id_pai";
            @__ctrl.GroupIndex = 0;
            @__ctrl.SortIndex = 0;
            @__ctrl.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            @__ctrl.VisibleIndex = 0;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control9(DevExpress.Web.ASPxGridView.GridColumnEditFormSettings @__ctrl) {
            @__ctrl.Visible = DevExpress.Utils.DefaultBoolean.False;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control8() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.Caption = "Codigo";
            @__ctrl.FieldName = "id_evento";
            @__ctrl.ReadOnly = true;
            @__ctrl.VisibleIndex = 1;
            this.@__BuildControl__control9(@__ctrl.EditFormSettings);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControl__control12() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            @__ctrl.TemplateControl = this;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "lblEventttt";
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBinding__control12);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        public void @__DataBinding__control12(object sender, System.EventArgs e) {
            System.Web.UI.WebControls.Label dataBindingExpressionBuilderTarget;
            DevExpress.Web.ASPxGridView.GridViewDataItemTemplateContainer Container;
            dataBindingExpressionBuilderTarget = ((System.Web.UI.WebControls.Label)(sender));
            Container = ((DevExpress.Web.ASPxGridView.GridViewDataItemTemplateContainer)(dataBindingExpressionBuilderTarget.BindingContainer));
            dataBindingExpressionBuilderTarget.Text = System.Convert.ToString( Eval("Evento1") , System.Globalization.CultureInfo.CurrentCulture);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control11(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n                           "));
            global::System.Web.UI.WebControls.Label @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control12();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n                           \r\n            "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control10() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.DataItemTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control11));
            @__ctrl.Caption = "Evento";
            @__ctrl.FieldName = "Evento1";
            @__ctrl.VisibleIndex = 2;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxEditors.ASPxLabel @__BuildControl__control15() {
            global::DevExpress.Web.ASPxEditors.ASPxLabel @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxEditors.ASPxLabel();
            @__ctrl.TemplateControl = this;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ApplyStyleSheetThemeInternal();
            @__ctrl.ID = "ASPxLabel1";
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBinding__control15);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        public void @__DataBinding__control15(object sender, System.EventArgs e) {
            DevExpress.Web.ASPxEditors.ASPxLabel dataBindingExpressionBuilderTarget;
            DevExpress.Web.ASPxGridView.GridViewDataItemTemplateContainer Container;
            dataBindingExpressionBuilderTarget = ((DevExpress.Web.ASPxEditors.ASPxLabel)(sender));
            Container = ((DevExpress.Web.ASPxGridView.GridViewDataItemTemplateContainer)(dataBindingExpressionBuilderTarget.BindingContainer));
            dataBindingExpressionBuilderTarget.Text = System.Convert.ToString(   
                (DataBinder.Eval(Container.DataItem, "TipoEvento").ToString().Equals("3"))? "Normalizado":"Andamento"
                        , System.Globalization.CultureInfo.CurrentCulture);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control14(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n                "));
            global::DevExpress.Web.ASPxEditors.ASPxLabel @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control15();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n                \r\n            "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control13() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.DataItemTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control14));
            @__ctrl.Caption = "Tipo";
            @__ctrl.FieldName = "TipoEvento";
            @__ctrl.VisibleIndex = 3;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control16() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "Descricao";
            @__ctrl.VisibleIndex = 4;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control17() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "Causa";
            @__ctrl.VisibleIndex = 5;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataDateColumn @__BuildControl__control18() {
            global::DevExpress.Web.ASPxGridView.GridViewDataDateColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataDateColumn();
            @__ctrl.FieldName = "Inicio";
            @__ctrl.VisibleIndex = 6;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataDateColumn @__BuildControl__control19() {
            global::DevExpress.Web.ASPxGridView.GridViewDataDateColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataDateColumn();
            @__ctrl.FieldName = "Fim";
            @__ctrl.VisibleIndex = 7;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control20() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "Localidades";
            @__ctrl.VisibleIndex = 8;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control21() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "ImpactoLocal";
            @__ctrl.VisibleIndex = 9;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control22() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "ImpactoLDN";
            @__ctrl.VisibleIndex = 10;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control23() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "Status";
            @__ctrl.VisibleIndex = 11;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control24() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "Responsavel";
            @__ctrl.VisibleIndex = 12;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control25() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "Ral";
            @__ctrl.VisibleIndex = 13;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control26() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "EnviadoPor";
            @__ctrl.VisibleIndex = 14;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__BuildControl__control27() {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
            @__ctrl.FieldName = "EnviadoPor2";
            @__ctrl.VisibleIndex = 15;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control6(DevExpress.Web.ASPxGridView.GridViewColumnCollection @__ctrl) {
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control7();
            @__ctrl.Add(@__ctrl1);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl2;
            @__ctrl2 = this.@__BuildControl__control8();
            @__ctrl.Add(@__ctrl2);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl3;
            @__ctrl3 = this.@__BuildControl__control10();
            @__ctrl.Add(@__ctrl3);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl4;
            @__ctrl4 = this.@__BuildControl__control13();
            @__ctrl.Add(@__ctrl4);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl5;
            @__ctrl5 = this.@__BuildControl__control16();
            @__ctrl.Add(@__ctrl5);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl6;
            @__ctrl6 = this.@__BuildControl__control17();
            @__ctrl.Add(@__ctrl6);
            global::DevExpress.Web.ASPxGridView.GridViewDataDateColumn @__ctrl7;
            @__ctrl7 = this.@__BuildControl__control18();
            @__ctrl.Add(@__ctrl7);
            global::DevExpress.Web.ASPxGridView.GridViewDataDateColumn @__ctrl8;
            @__ctrl8 = this.@__BuildControl__control19();
            @__ctrl.Add(@__ctrl8);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl9;
            @__ctrl9 = this.@__BuildControl__control20();
            @__ctrl.Add(@__ctrl9);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl10;
            @__ctrl10 = this.@__BuildControl__control21();
            @__ctrl.Add(@__ctrl10);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl11;
            @__ctrl11 = this.@__BuildControl__control22();
            @__ctrl.Add(@__ctrl11);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl12;
            @__ctrl12 = this.@__BuildControl__control23();
            @__ctrl.Add(@__ctrl12);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl13;
            @__ctrl13 = this.@__BuildControl__control24();
            @__ctrl.Add(@__ctrl13);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl14;
            @__ctrl14 = this.@__BuildControl__control25();
            @__ctrl.Add(@__ctrl14);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl15;
            @__ctrl15 = this.@__BuildControl__control26();
            @__ctrl.Add(@__ctrl15);
            global::DevExpress.Web.ASPxGridView.GridViewDataTextColumn @__ctrl16;
            @__ctrl16 = this.@__BuildControl__control27();
            @__ctrl.Add(@__ctrl16);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control28(DevExpress.Web.ASPxGridView.ASPxGridViewSettings @__ctrl) {
            @__ctrl.ShowFilterRow = true;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control30(DevExpress.Web.ASPxEditors.ProgressBarStyle @__ctrl) {
            @__ctrl.Height = new System.Web.UI.WebControls.Unit(25, System.Web.UI.WebControls.UnitType.Pixel);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control29(DevExpress.Web.ASPxGridView.GridViewEditorStyles @__ctrl) {
            this.@__BuildControl__control30(@__ctrl.ProgressBar);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxGridView.ASPxGridView @__BuildControldGridEvento() {
            global::DevExpress.Web.ASPxGridView.ASPxGridView @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxGridView.ASPxGridView();
            this.dGridEvento = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ApplyStyleSheetThemeInternal();
            @__ctrl.ID = "dGridEvento";
            @__ctrl.ClientInstanceName = "dGridEvento";
            @__ctrl.AutoGenerateColumns = false;
            @__ctrl.KeyFieldName = "id_evento";
            @__ctrl.Width = new System.Web.UI.WebControls.Unit(100, System.Web.UI.WebControls.UnitType.Percentage);
            this.@__BuildControl__control2(@__ctrl.SettingsPager);
            this.@__BuildControl__control6(@__ctrl.Columns);
            this.@__BuildControl__control28(@__ctrl.Settings);
            this.@__BuildControl__control29(@__ctrl.StylesEditors);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControllblErro() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.lblErro = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "lblErro";
            @__ctrl.Visible = false;
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::com.sandigital.sharepoint.webparts.EventosDeRedeListagem.EventosDeRedeListagem @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n<style type=\"text/css\">\r\n    .style1\r\n    {\r\n        fo" +
                        "nt-size: 11px;\r\n    }\r\n</style>\r\n\r\n\r\n\r\n"));
            global::DevExpress.Web.ASPxGridView.ASPxGridView @__ctrl1;
            @__ctrl1 = this.@__BuildControldGridEvento();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n\r\n"));
            global::System.Web.UI.WebControls.Label @__ctrl2;
            @__ctrl2 = this.@__BuildControllblErro();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n<p class=\"style1\">\r\n    EBT Eventos 3.0</p>\r\n"));
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
