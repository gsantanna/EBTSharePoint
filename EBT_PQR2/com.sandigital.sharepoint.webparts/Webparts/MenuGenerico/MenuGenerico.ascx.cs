using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;


namespace com.sandigital.sharepoint.webparts.MenuGenerico
{
    [ToolboxItemAttribute(false)]
    public partial class MenuGenerico : WebPart
    {


        #region Propriedades

        string _strLinks = string.Empty;

        [WebBrowsable(true)]
        [WebDisplayName("Links")]
        [WebDescription("Digite os Links no formato: Item1|URL|NomeJanela[S/N];Item2|URL2|S;Item3|URL|N")]
        [Personalizable(PersonalizationScope.User)]
        [Category("CONFIGURACAO")]
        public string Links
        {
            get { return _strLinks; }
            set { _strLinks = value; }
        }





        #endregion






        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public MenuGenerico()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {   
            //Monta o datasource
            if (string.IsNullOrEmpty(Links))
            {
                this.lblErro.Text = "Configure a lista de links na opção Configuração/Links da Webpart no formato Item1|Url1;Item2|Url2;Item3|Url3";
                return;
            }

            List<LinksDataSource> objDs = new List<LinksDataSource>();

            foreach (string si in Links.Split(';'))
            {

                string[] sl = si.Split('|');
                try
                {
                    LinksDataSource Link = new LinksDataSource();
                    Link.Texto = sl[0].ToString();
                    Link.Link = sl[1].ToString();
                    Link.NovaJanela = (sl.Length == 3 && (sl[2].ToString().ToUpper().Equals("S") || sl[2].ToString().ToUpper().Equals("SIM")));
                    objDs.Add(Link);

                }
                catch (Exception ex)
                {
                    lblErro.Text = "Erro ao processar os menus. o erro foi: " + ex.Message;
                    lblErro.Visible = true;
                    break;
                        
                }
            }



            this.rptMain.DataSource = objDs;
            this.rptMain.DataBind();


        }





        #region Classe de apoio

        [Serializable]
        class LinksDataSource
        {
            public string Texto { get; set; }
            public string Link { get; set; }
            public bool NovaJanela { get; set; }
        }
        

        #endregion






































    }
}
