﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace com.sandigital.sharepoint.webparts.MenuGenerico {
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
    
    
    public partial class MenuGenerico {
        
        protected global::System.Web.UI.WebControls.Label lblErro;
        
        protected global::System.Web.UI.WebControls.Repeater rptMain;
        
        public static implicit operator global::System.Web.UI.TemplateControl(MenuGenerico target) 
        {
            return target == null ? null : target.TemplateControl;
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
        private void @__BuildControl__control2(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        <div class=\"MenuSuperiorHome\">\r\n    "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.HyperLink @__BuildControl__control4() {
            global::System.Web.UI.WebControls.HyperLink @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.HyperLink();
            @__ctrl.TemplateControl = this;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "lnkMain";
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBinding__control4);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        public void @__DataBinding__control4(object sender, System.EventArgs e) {
            System.Web.UI.WebControls.HyperLink dataBindingExpressionBuilderTarget;
            System.Web.UI.WebControls.RepeaterItem Container;
            dataBindingExpressionBuilderTarget = ((System.Web.UI.WebControls.HyperLink)(sender));
            Container = ((System.Web.UI.WebControls.RepeaterItem)(dataBindingExpressionBuilderTarget.BindingContainer));
            dataBindingExpressionBuilderTarget.NavigateUrl = System.Convert.ToString(Eval("Link") , System.Globalization.CultureInfo.CurrentCulture);
            dataBindingExpressionBuilderTarget.Text = System.Convert.ToString(Eval("Texto") , System.Globalization.CultureInfo.CurrentCulture);
            dataBindingExpressionBuilderTarget.Target = System.Convert.ToString( ((bool)Eval("NovaJanela"))? "_Blank" : "" , System.Globalization.CultureInfo.CurrentCulture);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control3(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n            "));
            global::System.Web.UI.WebControls.HyperLink @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control4();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n     "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control5(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n         <span style=\"padding: 3px; font-weight:bold; font-size:12px; font-fami" +
                        "ly: ARIal, Helvetica, sans-serif; text-transform: uppercase;\">\r\n         &nbsp;|" +
                        "&nbsp; \r\n        </span> \r\n\r\n    "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControl__control6(System.Web.UI.Control @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        </div>\r\n    "));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Repeater @__BuildControlrptMain() {
            global::System.Web.UI.WebControls.Repeater @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Repeater();
            this.rptMain = @__ctrl;
            @__ctrl.HeaderTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control2));
            @__ctrl.ItemTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control3));
            @__ctrl.SeparatorTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control5));
            @__ctrl.FooterTemplate = new System.Web.UI.CompiledTemplateBuilder(new System.Web.UI.BuildTemplateMethod(this.@__BuildControl__control6));
            @__ctrl.ID = "rptMain";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::com.sandigital.sharepoint.webparts.MenuGenerico.MenuGenerico @__ctrl) {
            global::System.Web.UI.WebControls.Label @__ctrl1;
            @__ctrl1 = this.@__BuildControllblErro();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n\r\n"));
            global::System.Web.UI.WebControls.Repeater @__ctrl2;
            @__ctrl2 = this.@__BuildControlrptMain();
            @__parser.AddParsedSubObject(@__ctrl2);
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
