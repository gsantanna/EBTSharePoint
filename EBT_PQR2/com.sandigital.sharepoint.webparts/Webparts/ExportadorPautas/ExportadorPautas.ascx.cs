using com.sandigital.sharepoint.webparts.Modelos;
using System;
using System.ComponentModel;
using System.IO;
using System.Web.UI.WebControls.WebParts;

namespace com.sandigital.sharepoint.webparts.ExportadorPautas
{
    [ToolboxItemAttribute(false)]
    public partial class ExportadorPautas : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public ExportadorPautas()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }

      

        protected void lnkF_Click(object sender, EventArgs e)
        {

            this.grdMain.DataSource = Pauta.PautasAsDataTable();
            this.grdMain.DataBind();
            this.grdMain.Visible = true;

            MemoryStream msSaida = new MemoryStream();
            this.grdMainExport.WriteXlsx(msSaida);


            Page.Response.Clear();
            Page.Response.ContentType = "application/force-download";
            Page.Response.AddHeader("content-disposition",
                               "attachment; filename=ExportPautasVoc.xlsx");
            Page.Response.BinaryWrite(msSaida.ToArray());
            Page.Response.End();





        }
    }
}
