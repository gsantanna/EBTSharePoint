﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5483
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace com.sandigital.sharepoint.webparts.GeradorDeAtas {
    using System.Web;
    using System.Text.RegularExpressions;
    using Microsoft.SharePoint.WebPartPages;
    using System.Web.Security;
    using System.Text;
    using System.Web.SessionState;
    using DevExpress.Web.ASPxEditors;
    using System.Collections.Specialized;
    using Microsoft.SharePoint.WebControls;
    using System.Web.UI.WebControls;
    using System;
    using Microsoft.SharePoint;
    using System.Web.UI;
    using System.Web.Profile;
    using System.Collections;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.Caching;
    using Microsoft.SharePoint.Utilities;
    using System.Configuration;
    using System.Web.UI.HtmlControls;
    
    
    public partial class GeradorDeAtas {
        
        protected global::DevExpress.Web.ASPxEditors.ASPxComboBox cboDataReuniao;
        
        protected global::System.Web.UI.WebControls.Button btnGerar;
        
        protected global::System.Web.UI.WebControls.Label lblResultado;
        
        protected global::System.Web.UI.WebControls.LinkButton btnEnviarEmail;
        
        protected global::System.Web.UI.WebControls.HyperLink btnVisualizar;
        
        protected global::System.Web.UI.WebControls.Panel pnlResultado;
        
        protected global::System.Web.UI.WebControls.Label lblErro;
        
        protected global::System.Web.UI.WebControls.Panel pnlErro;
        
        public static implicit operator global::System.Web.UI.TemplateControl(GeradorDeAtas target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::DevExpress.Web.ASPxEditors.ASPxComboBox @__BuildControlcboDataReuniao() {
            global::DevExpress.Web.ASPxEditors.ASPxComboBox @__ctrl;
            @__ctrl = new global::DevExpress.Web.ASPxEditors.ASPxComboBox();
            this.cboDataReuniao = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ApplyStyleSheetThemeInternal();
            @__ctrl.ID = "cboDataReuniao";
            @__ctrl.TextField = "dt_evento";
            @__ctrl.Width = new System.Web.UI.WebControls.Unit(100, System.Web.UI.WebControls.UnitType.Percentage);
            @__ctrl.ValueField = "ID";
            @__ctrl.ValueType = typeof(int);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Button @__BuildControlbtnGerar() {
            global::System.Web.UI.WebControls.Button @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Button();
            this.btnGerar = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "btnGerar";
            @__ctrl.Text = "Gerar Ata";
            @__ctrl.CssClass = "btn-small btn-primary";
            @__ctrl.Click -= new System.EventHandler(this.btnGerar_Click);
            @__ctrl.Click += new System.EventHandler(this.btnGerar_Click);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Label @__BuildControllblResultado() {
            global::System.Web.UI.WebControls.Label @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Label();
            this.lblResultado = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "lblResultado";
            @__ctrl.Text = "Ata gerada com sucesso! Deseja enviar aos participantes automaticamente?";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.LinkButton @__BuildControlbtnEnviarEmail() {
            global::System.Web.UI.WebControls.LinkButton @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.LinkButton();
            this.btnEnviarEmail = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "btnEnviarEmail";
            @__ctrl.CssClass = "btn btn-primary";
            @__ctrl.Text = "Enviar";
            @__ctrl.Click -= new System.EventHandler(this.btnEnviarEmail_Click);
            @__ctrl.Click += new System.EventHandler(this.btnEnviarEmail_Click);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.HyperLink @__BuildControlbtnVisualizar() {
            global::System.Web.UI.WebControls.HyperLink @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.HyperLink();
            this.btnVisualizar = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "btnVisualizar";
            @__ctrl.CssClass = "btn btn-primary";
            @__ctrl.Text = "Visualizar";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Panel @__BuildControlpnlResultado() {
            global::System.Web.UI.WebControls.Panel @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Panel();
            this.pnlResultado = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "pnlResultado";
            @__ctrl.Visible = false;
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n<div id=\"resultadoGeradorAtas\" class=\"alert alert-success\">\r\n\r\n    <p>\r\n    "));
            global::System.Web.UI.WebControls.Label @__ctrl1;
            @__ctrl1 = this.@__BuildControllblResultado();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n    </p>\r\n \r\n   \r\n\r\n</div>\r\n    \r\n "));
            global::System.Web.UI.WebControls.LinkButton @__ctrl2;
            @__ctrl2 = this.@__BuildControlbtnEnviarEmail();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n    "));
            global::System.Web.UI.WebControls.HyperLink @__ctrl3;
            @__ctrl3 = this.@__BuildControlbtnVisualizar();
            @__parser.AddParsedSubObject(@__ctrl3);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n  \r\n\r\n"));
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
        private global::System.Web.UI.WebControls.Panel @__BuildControlpnlErro() {
            global::System.Web.UI.WebControls.Panel @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Panel();
            this.pnlErro = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this.Page);
            @__ctrl.ID = "pnlErro";
            @__ctrl.Visible = false;
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n    <div class=\"alert alert-danger\" role=\"alert\">\r\n        "));
            global::System.Web.UI.WebControls.Label @__ctrl1;
            @__ctrl1 = this.@__BuildControllblErro();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n    </div>\r\n"));
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::com.sandigital.sharepoint.webparts.GeradorDeAtas.GeradorDeAtas @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n\r\n   \r\n\r\n<table  style=\"width:100%\">\r\n    <tr>\r\n\r\n        <td style=\"padding-" +
                        "right:10px;width:40px;\">Reunião:</td>\r\n\r\n        <td style=\"padding-right:10px;\"" +
                        ">\r\n            "));
            global::DevExpress.Web.ASPxEditors.ASPxComboBox @__ctrl1;
            @__ctrl1 = this.@__BuildControlcboDataReuniao();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n        </td>\r\n\r\n        <td style=\"width:40px;\">\r\n            \r\n            " +
                        ""));
            global::System.Web.UI.WebControls.Button @__ctrl2;
            @__ctrl2 = this.@__BuildControlbtnGerar();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl(" \r\n\r\n        </td>\r\n\r\n    </tr>\r\n\r\n</table>\r\n\r\n\r\n\r\n<p>\r\n    &nbsp;</p>\r\n\r\n\r\n"));
            global::System.Web.UI.WebControls.Panel @__ctrl3;
            @__ctrl3 = this.@__BuildControlpnlResultado();
            @__parser.AddParsedSubObject(@__ctrl3);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n\r\n"));
            global::System.Web.UI.WebControls.Panel @__ctrl4;
            @__ctrl4 = this.@__BuildControlpnlErro();
            @__parser.AddParsedSubObject(@__ctrl4);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n"));
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