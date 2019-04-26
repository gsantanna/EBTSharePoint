using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using Microsoft.SharePoint;

namespace com.sandigital.sharepoint.webparts.Blig
{
    [ToolboxItemAttribute(false)]
    public partial class Blig : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Blig()
        {
        }



        #region Propriedades 
      
        string _strLista;


        [WebBrowsable(true)]
        [WebDisplayName("Lista")]
        [WebDescription("Lista que alimentará a webpart")]
        [Personalizable(PersonalizationScope.User)]
        [Category("DADOS")]
        public string Lista
        {
            get { return _strLista; }
            set { _strLista = value; }
        }


        string _strExibicao;

        [WebBrowsable(true)]
        [WebDisplayName("Exibição")]
        [WebDescription("Opcional! - Nome de exibição que alimentará esta WebPart.")]
        [Personalizable(PersonalizationScope.User)]
        [Category("DADOS")]
        public string Exibicao
        {
            get { return _strExibicao; }
            set { _strExibicao = value; }
        }




        string _strSite;

        [WebBrowsable(true)]
        [WebDisplayName("Site")]
        [WebDescription("Site que contem a lista que alimentará a webpart.")]
        [Personalizable(PersonalizationScope.User)]
        [Category("DADOS")]
        public string SiteBlig
        {
            get {
                return string.IsNullOrEmpty(_strSite) ? "Blig" : _strSite;

            }
            set { _strSite = value; }
        }

        



        #endregion






        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Lista) || string.IsNullOrEmpty(this.SiteBlig) )
            {
                lblErro.Text = "Lista não cofigurada. Utilize a propriedade \"Lista\" na aba DADOS das configurações da Webpart";
                this.lblErro.Visible = true;
            }
            else
            {
                this.lblErro.Visible = false;
                CarregaConteudo();
            }

        }

         protected void CarregaConteudo()
        {

            try
            {
                //Cria o wraper do sharepoint
                spsWrapper.spsWrapper objSp = new spsWrapper.spsWrapper();

                //configura o url 
                string strUrl = strUrl = "/{0}/Lists/{1}/Post.aspx?ID={2}";


                
                //Carrega a lista 
                var objSaida = (from SPListItem item in objSp.RetornaLista( _strLista, _strExibicao, "Blig")
                                where item["ImagemHome"] !=null 
                                orderby item["Created"]
                                descending
                                select new {  
                                    ImagemHome  = item["ImagemHome"]  ,
                                    Title = item["Title"], 
                                    ID = item.ID,
                                    Chamada = item["Chamada"],
                                    Url = string.Format(strUrl, "Blig", _strLista, item.ID)
                                }).Take(1);

                




                //Binda o repeater
                this.fvBlig.DataSource = objSaida;
                fvBlig.DataBind();



            }
            catch (Exception ex)
            {
                lblErro.Text = "Erro ao carregar o blig! utilize o código fonte da pagina para o detalhamento do erro" +
                    "  Inicio do Erro \n\n" + ex.ToString() + "\n\n FIM DO ERRO ";
                lblErro.Visible = true;
            }







        }       









    }
}
