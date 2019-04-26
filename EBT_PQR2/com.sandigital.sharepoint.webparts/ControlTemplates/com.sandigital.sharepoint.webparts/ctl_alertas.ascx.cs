using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using Microsoft.SharePoint;

namespace com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts
{
    public partial class ctl_alertas : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack) CarregaAlertas();
            }
            catch (Exception ex)
            {
                lblErro.Text = string.Format(" <!-- Erro ao carregar ALERTAS, o erro foi {0} -->", ex.Message);
 
            }
        }

        private void CarregaAlertas()
        {
            spsWrapper2 objWrapper = new spsWrapper2();



            var ds = from f in objWrapper.RetornaLista("Alertas", new []{"Title","DataInicio","DataFim"}, SPContext.Current.Site.AllWebs["ComunidadeOperacoesVoc"].ID )
                     where (DateTime.Now.Date >= Convert.ToDateTime(f["DataInicio"]).Date) &&
                        (DateTime.Now.Date <= Convert.ToDateTime(f["DataFim"]).Date)
                     select new
                     {
                         Titulo = f.Title,
                         Inicio = Convert.ToDateTime(f["DataInicio"]),
                         Fim = Convert.ToDateTime(f["DataFim"])
                     };

            if (ds.Count() > 0)
            {
                this.rptMain.DataSource = ds;
                this.rptMain.DataBind();
                this.pnlAlertas.Visible = true;
            };




        }

    }
}
