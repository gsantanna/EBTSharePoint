﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5485
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace com.sandigital.sharepoint.webparts.Webparts.AcessoRapido {
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
    
    
    public partial class AcessoRapido {
        
        protected global::System.Web.UI.HtmlControls.HtmlGenericControl divAcessoRapido;
        
        public static implicit operator global::System.Web.UI.TemplateControl(AcessoRapido target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.HtmlControls.HtmlGenericControl @__BuildControldivAcessoRapido() {
            global::System.Web.UI.HtmlControls.HtmlGenericControl @__ctrl;
            @__ctrl = new global::System.Web.UI.HtmlControls.HtmlGenericControl("div");
            this.divAcessoRapido = @__ctrl;
            @__ctrl.ID = "divAcessoRapido";
            ((System.Web.UI.IAttributeAccessor)(@__ctrl)).SetAttribute("class", "acessoRapido text-center");
            ((System.Web.UI.IAttributeAccessor)(@__ctrl)).SetAttribute("style", "text-align:center;");
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n    "));
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::com.sandigital.sharepoint.webparts.Webparts.AcessoRapido.AcessoRapido @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl(@"




<link rel=""stylesheet"" type=""text/css"" href=""/css/smoothDivScroll.css"">

<style type=""text/css"">
    .acessoRapido {
      
        position: relative;
        background: #075181;
        border-radius: 10px;
        clear: both;
        text-align: center;
        height: 65px;

        text-align: justify;
        -ms-text-justify: distribute-all-lines;
        text-justify: distribute-all-lines;

    }

    .acessoRapidodiv.scrollableArea img {
        position: relative;
        /*float: left;*/
        margin: 0;
        padding: 0;
        -webkit-user-select: none;
        -khtml-user-select: none;
        -moz-user-select: none;
        -o-user-select: none;
        user-select: none;







    }
</style>

<div id=""dvContainerAcessoRapido"" style=""width: 100%; text-align:center;"" class=""text-center"">
    "));
            global::System.Web.UI.HtmlControls.HtmlGenericControl @__ctrl1;
            @__ctrl1 = this.@__BuildControldivAcessoRapido();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl(@"
</div>





	<script src=""/js/jquery-ui-1.10.3.custom.min.js"" type=""text/javascript""></script>
	
	
	<script src=""/js/jquery.mousewheel.min.js"" type=""text/javascript""></script>

	
	<script src=""/js/jquery.kinetic.min.js"" type=""text/javascript""></script>

	<script src=""/js/jquery.smoothdivscroll-1.3-min.js"" type=""text/javascript""></script>

"));
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
