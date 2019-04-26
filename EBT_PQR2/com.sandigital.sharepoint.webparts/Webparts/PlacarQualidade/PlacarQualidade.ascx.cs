using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using System.Collections.Generic;

namespace com.sandigital.sharepoint.webparts.PlacarQualidade
{
    [ToolboxItemAttribute(false)]
    public partial class PlacarQualidade : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public PlacarQualidade()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }


        string _strBiblioteca;

        [WebBrowsable(true)]
        [WebDisplayName("Biblioteca")]
        [WebDescription("Biblioteca que alimentará a webpart")]
        [Personalizable(PersonalizationScope.User)]
        [Category("DADOS")]
        public string Biblioteca
        {
            get { return _strBiblioteca; }
            set { _strBiblioteca = value; }
        }

        int  _inTamanho;
        [WebBrowsable(true)]
        [WebDisplayName("Tamanho da Imagem")]
        [WebDescription("Tamanho das imagens que serão mostradas na webpart")]
        [Personalizable(PersonalizationScope.User)]
        [Category("DADOS")]
        public int  Tamanho
        {
            get { return _inTamanho; }
            set { _inTamanho = value; }
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Biblioteca))
            {
                this.lblErro.Text = "biblioteca não configurada! configure o nome da biblioteca de imagens na aba DADOS da configuração desta webpart";
                return;
            }


            if (!Page.IsPostBack)
            {
                try
                {
                    CarregaSlider();
                }
                catch (Exception ex)
                {
                    this.lblErro.Visible = true;
                    this.lblErro.Text = "Erro ao carregar esta webpart, verifique as configurações da lista e tente novamente. o Erro foi:  " + ex.Message;

                }
            }



        }



        //Conexão com sharepoint
        private void CarregaSlider()
        {
            //Carrega os itens da lista 

            //Cria o wrapper
            spsWrapper.spsWrapper objWrapper = new spsWrapper.spsWrapper();

            //Carrega a lista 
            var Lista = objWrapper.RetornaLista(Biblioteca, SPContext.Current.Web.ID);


            //Validações:

            //Caso não encontre a lista exibe o erro
            if (Lista == null) throw new Exception(string.Format("A Biblioteca {0} não foi encontrada! verifique se ela existe e tente novamente", Biblioteca));

            //Caso a lista não tenha os campos necessários exibe o erro.
            if (!Lista.Fields.ContainsField("Posicao")) throw new Exception(this.lblErro.Text = string.Format("O Campo Posicao não foi encontrado na biblioteca"));
            if (!Lista.Fields.ContainsField("Link")) throw new Exception(this.lblErro.Text = string.Format("O Campo Link não foi encontrado na biblioteca"));

            int i = 0;
            List<Modelos.Slide> objSlides = new List<Modelos.Slide>();
            foreach (SPListItem item in Lista)
            {
                if (item.File != null)
                {
                    

                    string strLink = Convert.ToString(item["Link"]);

                    strLink = strLink.Contains(',') ?
                        strLink.Split(',')[0] : strLink;



                    objSlides.Add(new Modelos.Slide
                    { 

                        ID = i,
                        Titulo = item.Title,
                        Ordem = Convert.ToInt32(item["Posicao"]),
                        Imagem = string.Format("{0}/{1}", SPContext.Current.Web.Url, item.File.Url),
                        Link = strLink,
                        css = (i == 0) ? "active" : string.Empty,
                        Tamanho = this._inTamanho > 0 ? this._inTamanho.ToString() + "px" : "700px" 

                    });
                    i++;

                }
            }

            //binda os repeaters
            this.rptIndicadores.DataSource = objSlides;
            this.rptIndicadores.DataBind();

            this.rptItens.DataSource = objSlides;
            this.rptItens.DataBind();




        }//Fim caregarSlider();





    } //Fim classe
} //Fim NS
