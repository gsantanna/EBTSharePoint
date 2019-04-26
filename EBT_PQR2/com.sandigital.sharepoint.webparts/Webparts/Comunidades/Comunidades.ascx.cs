using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;



namespace com.sandigital.sharepoint.webparts.Comunidades
{
    [ToolboxItemAttribute(false)]
    public partial class Comunidades : WebPart
    {

        protected string _strErro = string.Empty;
        private string _strLista;
        private int _qtdItens;


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

        [WebBrowsable(true)]
        [WebDisplayName("Quantidade de Itens")]
        [WebDescription("Quantidade de Itens que serão exibidos no controle")]
        [Personalizable(PersonalizationScope.User)]
        [Category("DADOS")] 
        public int QtdItens
        {
            get { return _qtdItens; }
            set { _qtdItens = value; }
        }







        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Comunidades()
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














    }
}
