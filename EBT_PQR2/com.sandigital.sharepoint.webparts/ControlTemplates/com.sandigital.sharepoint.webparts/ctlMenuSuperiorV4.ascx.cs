using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts
{
    public partial class ctlMenuSuperiorV4 : UserControl
    {
        public string Lista { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {

            //carrega o menu superior
            if (string.IsNullOrEmpty(Lista))
            {
                this.lblErro.Visible = true;
                this.lblErro.Text = "Erro, lista não configurada!";
                return;
            }
            else
            {

                if (!IsPostBack)
                {
                    CarregaMenu();

                }

            }

            
        }


        private string getCssClass(string Link)
        {
            if (
                Request.Url.LocalPath.ToUpper() == Link.ToUpper())
            {
                return "active";
            }
            else
            {
                return "inativo";
            }


        }
        public void CarregaMenu()
        {
            //tenta carregar a lista configurada.
            spsWrapper.spsWrapper objSps = new spsWrapper.spsWrapper();

            try
            { 

                List<MenuDataSource> objDs = new List<MenuDataSource>();

                foreach (SPListItem sp in objSps.RetornaListaLocal(Lista))
                {
                    objDs.Add(new MenuDataSource
                    {
                        Link = sp["Link"].ToString(),
                        Texto = sp["Texto"].ToString(), 
                        Classe = getCssClass(  sp["Link"].ToString() )

                    });   

                }

                this.rptMain.DataSource = objDs;
                this.rptMain.DataBind();

            }
            catch (Exception ex)
            {
                this.lblErro.Text = "<!-- Erro ao carregar este controle, o erro foi: " + ex.Message + "-->";

            }








        }

        #region Classe de Apoio

        [Serializable]
        class MenuDataSource
        {
            public string Texto { get; set; }
            public string Link { get; set; }
            public string Classe { get; set; }
            public bool NovaJanela { get; set; }
        }

        #endregion















    }
}
