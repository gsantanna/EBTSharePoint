﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5485
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace com.sandigital.sharepoint.webparts.PlacarQualidade {
    using System.Web;
    using System.Text.RegularExpressions;
    using Microsoft.SharePoint.WebPartPages;
    using Microsoft.SharePoint.WebControls;
    using System.Web.Security;
    using Microsoft.SharePoint.Utilities;
    using System.Web.UI;
    using System;
    using System.Web.UI.WebControls;
    using System.Collections.Specialized;
    using Microsoft.SharePoint;
    using System.Collections;
    using System.Web.Profile;
    using System.Text;
    using System.Web.Caching;
    using System.Configuration;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.SessionState;
    using System.Web.UI.HtmlControls;
    
    
    public partial class PlacarQualidade {
        
        protected global::System.Web.UI.WebControls.Repeater rptIndicadores;
        
        protected global::System.Web.UI.WebControls.Repeater rptItens;
        
        protected global::System.Web.UI.WebControls.Label lblErro;
        
        public static implicit operator global::System.Web.UI.TemplateControl(PlacarQualidade target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.DataBoundLiteralControl @__BuildControl__control3() {
            global::System.Web.UI.DataBoundLiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.DataBoundLiteralControl(2, 1);
            @__ctrl.SetStaticString(0, "\r\n\r\n    <div id=\"placar\" style=\'width:100%;max-width:");
            @__ctrl.SetStaticString(1, ";\' class=\"carousel slide\" data-interval=\"4000\" data-ride=\"carousel\">\r\n    ");
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBind__control3);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        public void @__DataBind__control3(object sender, System.EventArgs e) {
            System.Web.UI.Control Container;
            System.Web.UI.DataBoundLiteralControl target;
            target = ((System.Web.UI.DataBoundLiteralControl)(sender));
            Container = ((System.Web.UI.Control)(target.BindingContainer));
            target.SetDataBoundString(0, System.Convert.ToString(Eval("Tamanho"), System.Globalization.CultureInfo.CurrentCulture));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control4(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n          <!-- Carousel indicators -->\r\n        <ol class=\"carousel-indicators\"" +
                        ">\r\n    "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.DataBoundLiteralControl @__BuildControl__control6() {
            global::System.Web.UI.DataBoundLiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.DataBoundLiteralControl(3, 2);
            @__ctrl.TemplateControl = this;
            @__ctrl.SetStaticString(0, "\r\n            <li data-target=\"#placar\" data-slide-to=\'");
            @__ctrl.SetStaticString(1, "\' class=\'");
            @__ctrl.SetStaticString(2, "\' ></li>\r\n    ");
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBind__control6);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        public void @__DataBind__control6(object sender, System.EventArgs e) {
            System.Web.UI.WebControls.RepeaterItem Container;
            System.Web.UI.DataBoundLiteralControl target;
            target = ((System.Web.UI.DataBoundLiteralControl)(sender));
            Container = ((System.Web.UI.WebControls.RepeaterItem)(target.BindingContainer));
            target.SetDataBoundString(0, System.Convert.ToString(Eval("ID"), System.Globalization.CultureInfo.CurrentCulture));
            target.SetDataBoundString(1, System.Convert.ToString(Eval("css"), System.Globalization.CultureInfo.CurrentCulture));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control5(System.Web.UI.Control @__ctrl) {
            global::System.Web.UI.DataBoundLiteralControl @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control6();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control7(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n             </ol>  \r\n    "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Repeater @__BuildControlrptIndicadores() {
            global::System.Web.UI.WebControls.Repeater @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Repeater();
            this.rptIndicadores = @__ctrl;
            @__ctrl.HeaderTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control4));
            @__ctrl.ItemTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control5));
            @__ctrl.FooterTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control7));
            @__ctrl.ID = "rptIndicadores";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control8(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n       <!-- Carousel items -->\r\n        <div class=\"carousel-inner\">\r\n         " +
                        "   "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.DataBoundLiteralControl @__BuildControl__control12() {
            global::System.Web.UI.DataBoundLiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.DataBoundLiteralControl(5, 4);
            @__ctrl.SetStaticString(0, "\r\n                 <img style=\'width:");
            @__ctrl.SetStaticString(1, ";max-width:");
            @__ctrl.SetStaticString(2, "\' src=\'");
            @__ctrl.SetStaticString(3, "\' alt=\'");
            @__ctrl.SetStaticString(4, "\' />");
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBind__control12);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        public void @__DataBind__control12(object sender, System.EventArgs e) {
            System.Web.UI.WebControls.RepeaterItem Container;
            System.Web.UI.DataBoundLiteralControl target;
            target = ((System.Web.UI.DataBoundLiteralControl)(sender));
            Container = ((System.Web.UI.WebControls.RepeaterItem)(target.BindingContainer));
            target.SetDataBoundString(0, System.Convert.ToString(Eval("Tamanho"), System.Globalization.CultureInfo.CurrentCulture));
            target.SetDataBoundString(1, System.Convert.ToString(Eval("Tamanho"), System.Globalization.CultureInfo.CurrentCulture));
            target.SetDataBoundString(2, System.Convert.ToString(Eval("Imagem"), System.Globalization.CultureInfo.CurrentCulture));
            target.SetDataBoundString(3, System.Convert.ToString(Eval("Titulo"), System.Globalization.CultureInfo.CurrentCulture));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.HyperLink @__BuildControl__control11() {
            global::System.Web.UI.WebControls.HyperLink @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.HyperLink();
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "lnk";
            global::System.Web.UI.DataBoundLiteralControl @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control12();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBinding__control11);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        public void @__DataBinding__control11(object sender, System.EventArgs e) {
            System.Web.UI.WebControls.HyperLink dataBindingExpressionBuilderTarget;
            System.Web.UI.WebControls.RepeaterItem Container;
            dataBindingExpressionBuilderTarget = ((System.Web.UI.WebControls.HyperLink)(sender));
            Container = ((System.Web.UI.WebControls.RepeaterItem)(dataBindingExpressionBuilderTarget.BindingContainer));
            dataBindingExpressionBuilderTarget.NavigateUrl = System.Convert.ToString(Eval("Link") , System.Globalization.CultureInfo.CurrentCulture);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControl__control13() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "lblDescr";
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBinding__control13);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        public void @__DataBinding__control13(object sender, System.EventArgs e) {
            System.Web.UI.WebControls.Label dataBindingExpressionBuilderTarget;
            System.Web.UI.WebControls.RepeaterItem Container;
            dataBindingExpressionBuilderTarget = ((System.Web.UI.WebControls.Label)(sender));
            Container = ((System.Web.UI.WebControls.RepeaterItem)(dataBindingExpressionBuilderTarget.BindingContainer));
            dataBindingExpressionBuilderTarget.Text = System.Convert.ToString(Eval("Titulo") , System.Globalization.CultureInfo.CurrentCulture);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.HtmlControls.HtmlGenericControl @__BuildControl__control10() {
            global::System.Web.UI.HtmlControls.HtmlGenericControl @__ctrl;
            @__ctrl = new global::System.Web.UI.HtmlControls.HtmlGenericControl("div");
            @__ctrl.TemplateControl = this;
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n                "));
            global::System.Web.UI.WebControls.HyperLink @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control11();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n                  <p> "));
            global::System.Web.UI.WebControls.Label @__ctrl2;
            @__ctrl2 = this.@__BuildControl__control13();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("  </p>\r\n            "));
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBinding__control10);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        public void @__DataBinding__control10(object sender, System.EventArgs e) {
            System.Web.UI.HtmlControls.HtmlGenericControl dataBindingExpressionBuilderTarget;
            System.Web.UI.WebControls.RepeaterItem Container;
            dataBindingExpressionBuilderTarget = ((System.Web.UI.HtmlControls.HtmlGenericControl)(sender));
            Container = ((System.Web.UI.WebControls.RepeaterItem)(dataBindingExpressionBuilderTarget.BindingContainer));
            ((System.Web.UI.IAttributeAccessor)(dataBindingExpressionBuilderTarget)).SetAttribute("class", System.Convert.ToString( Eval("css") + " item" , System.Globalization.CultureInfo.CurrentCulture));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control9(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n                \r\n            "));
            global::System.Web.UI.HtmlControls.HtmlGenericControl @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control10();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control14(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n                </div>\r\n            "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Repeater @__BuildControlrptItens() {
            global::System.Web.UI.WebControls.Repeater @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Repeater();
            this.rptItens = @__ctrl;
            @__ctrl.HeaderTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control8));
            @__ctrl.ItemTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control9));
            @__ctrl.FooterTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control14));
            @__ctrl.ID = "rptItens";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.HtmlControls.HtmlGenericControl @__BuildControl__control2() {
            global::System.Web.UI.HtmlControls.HtmlGenericControl @__ctrl;
            @__ctrl = new global::System.Web.UI.HtmlControls.HtmlGenericControl("div");
            ((System.Web.UI.IAttributeAccessor)(@__ctrl)).SetAttribute("class", "placarContainer");
            global::System.Web.UI.DataBoundLiteralControl @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control3();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
            global::System.Web.UI.WebControls.Repeater @__ctrl2;
            @__ctrl2 = this.@__BuildControlrptIndicadores();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        "));
            global::System.Web.UI.WebControls.Repeater @__ctrl3;
            @__ctrl3 = this.@__BuildControlrptItens();
            @__parser.AddParsedSubObject(@__ctrl3);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl(@"
        <!-- Carousel nav -->
        <a class=""carousel-control left"" href=""#placar"" data-slide=""prev"">
            <span class=""glyphicon glyphicon-chevron-left""></span>
        </a>
        <a class=""carousel-control right"" href=""#placar"" data-slide=""next"">
            <span class=""glyphicon glyphicon-chevron-right""></span>
        </a>
    </div>

"));
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControllblErro() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.lblErro = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "lblErro";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::com.sandigital.sharepoint.webparts.PlacarQualidade.PlacarQualidade @__ctrl) {
            global::System.Web.UI.HtmlControls.HtmlGenericControl @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control2();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n<p>\r\n    "));
            global::System.Web.UI.WebControls.Label @__ctrl2;
            @__ctrl2 = this.@__BuildControllblErro();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n</p>\r\n\r\n\r\n"));
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
