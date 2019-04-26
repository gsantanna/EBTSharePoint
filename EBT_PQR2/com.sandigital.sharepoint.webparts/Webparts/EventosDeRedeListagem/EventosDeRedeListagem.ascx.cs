using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;


namespace com.sandigital.sharepoint.webparts.EventosDeRedeListagem
{
    [ToolboxItemAttribute(false)]
    public partial class EventosDeRedeListagem : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public EventosDeRedeListagem()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
         
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                dal.EventoRedeDataContext objDs = new dal.EventoRedeDataContext();
                this.dGridEvento.DataSource = objDs.Evento.OrderByDescending(f => f.Inicio).ToList();
                this.dGridEvento.DataBind();
            }
            catch (Exception ex)
            {
                lblErro.Visible = true;
                lblErro.Text = "Erro ao carregar esta webpart! o erro foi: " + ex.Message;


            }

        }


    }
}
