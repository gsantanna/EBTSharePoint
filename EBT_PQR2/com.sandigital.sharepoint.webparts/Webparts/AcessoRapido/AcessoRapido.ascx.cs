using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace com.sandigital.sharepoint.webparts.Webparts.AcessoRapido
{
    [ToolboxItemAttribute(false)]
    public partial class AcessoRapido : WebPart
    {

        string _strLista = string.Empty;

        [WebBrowsable(true)]
        [WebDisplayName("ENDEREÇO DA  BIBLIOTECA")]
        [WebDescription("Digite o url relativo da lista ou biblioteca utilizada para montar a webpart.")]
        [Personalizable(PersonalizationScope.User)]
        [Category("CONFIGURACAO")]
        public string Lista
        {
            get { return _strLista; }
            set { _strLista = value; }
        }




        public AcessoRapido()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        private static string html = @"<a href=""{url}"" title=""{title}""><img border=""0"" src=""{img}"" alt=""{title}"" /></a>";

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(_strLista))
                {
                    this.divAcessoRapido.InnerHtml = "Lista não configurada, edite a webpart e configure a lista que alimentará o acesso rápido";
                    return;
                }


                if (!Page.IsPostBack)
                {

                    spsWrapper2 objWrapper = new spsWrapper2();


                    var Query = @"<OrderBy><FieldRef Name='Posicao' Ascending='True' /></OrderBy>";
                    var itens = objWrapper.RetornaListaPorUrl(_strLista, Query);

                    if (itens == null)
                    {
                        this.divAcessoRapido.InnerHtml = "Biblioteca inválida ou não compatível com a Webpart";
                        return;
                    }


                    string output = "";


                    foreach (SPListItem item in itens)
                    {
                        object url = item["URL"];

                        output += html
                            .Replace("{url}", url != null ? new SPFieldUrlValue(url.ToString()).Url : "#")
                            .Replace("{img}", item.Url)
                            .Replace("{title}", item.Title);

                    }


                    divAcessoRapido.InnerHtml = output;


                    //verifica se a quantidade é suficiente para encher a tela (habilitar script0 
                    string strScript = @"<script type='text/javascript'>
	                    // Initialize the plugin with no custom options
	                    $(document).ready(function () {

                        var qtdRegistros = "+ itens.Count.ToString() + @";
                        var tamanhoContainer = $('#dvContainerAcessoRapido').width();
                        $('.acessoRapido').width(tamanhoContainer);
                            
                            if(qtdRegistros * 56 > tamanhoContainer + 30) 
	                        $('.acessoRapido').smoothDivScroll({
	                            autoScrollingMode: ''
	                        });
	                    });
                    </script>";


                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "AcessoRapido", strScript);




                }


            }
            catch (Exception ex)
            {
                this.divAcessoRapido.InnerHtml = "Erro ao carregar a webpart. o erro foi :  " + ex.Message;



            }



        }

    }










}
