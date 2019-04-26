using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using com.sandigital.sharepoint.dal;
using Microsoft.SharePoint;
using System.Collections.Generic;
using DevExpress.Web.ASPxGridView;


namespace com.sandigital.sharepoint.webparts.PainelUsuario
{
    [ToolboxItemAttribute(false)]
    public partial class PainelUsuario : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public PainelUsuario()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string srtUsuario = Page.Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1];
                System.Web.UI.Timer tAtualizaGrid = this.FindControl("tAtualizaGrid") as System.Web.UI.Timer;
               // DevExpress.Web.ASPxGridView.ASPxGridView dGridMain = this.FindControl("dGridMain") as DevExpress.Web.ASPxGridView.ASPxGridView;

                CarregaGrid(dGridMain, srtUsuario);
                tAtualizaGrid.Enabled = true;                
            }
            else
            {
                string srtUsuario = Page.Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1];
                DevExpress.Web.ASPxGridView.ASPxGridView dGridMain = this.FindControl("dGridMain") as DevExpress.Web.ASPxGridView.ASPxGridView;

                CarregaGrid(dGridMain, srtUsuario);
            }

            if (Page.Request.Form["__EVENTTARGET"] == "Open")
            {
                //Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["EVT_CHAT_INICIO"].ToString());

               

            }
        }


        #region "Timer"        

        protected void tAtualizaGrid_Tick(object sender, EventArgs e)
        {
            System.Web.UI.Timer tAtualizaGrid = this.FindControl("tAtualizaGrid") as System.Web.UI.Timer;
            tAtualizaGrid.Enabled = true;

            string srtUsuario = Page.Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1];
            DevExpress.Web.ASPxGridView.ASPxGridView dGridMain = this.FindControl("dGridMain") as DevExpress.Web.ASPxGridView.ASPxGridView;

            CarregaGrid(dGridMain, srtUsuario);
        }


        #endregion       
       
        #region "Metodos"

        protected void CarregaGrid(ASPxGridView objGrid, string strUsuario)
        {
            try
            {
                EventoRedeDataContext db = new EventoRedeDataContext();
                objGrid.DataSource = db.EVT_ConsultaPainelUsuario(strUsuario);
                objGrid.DataBind();
            }
            catch { }
        }
                   
        #endregion







    }
}
