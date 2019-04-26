using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using com.sandigital.sharepoint.dal;
using System.Linq;
using Microsoft.SharePoint;

namespace com.sandigital.sharepoint.webparts.ChatNoc
{
    [ToolboxItemAttribute(false)]
    public partial class ChatNoc : WebPart
    {

        string strBibliotecaChat = "EbtChat";


        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public ChatNoc()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            CarregaCombo(ddlNoc);
           
        }



        #region Métodos 
        
        public void IniciaAtendimento(string strUsuario, int intNoc)
        {
            using (
            EventoRedeDataContext db = new EventoRedeDataContext())
            {
                db.EVT_IniciaAtendimento(strUsuario, intNoc);
            }



        }

        public void CarregaCombo(DropDownList ddlNoc)
        {

            using (
            EventoRedeDataContext db = new EventoRedeDataContext())
            {

                var noc = (from m in db.evt_chat_noc
                           where m.ativo
                           select m);

                if (noc != null)
                {
                    ddlNoc.DataTextField = "descricao";
                    ddlNoc.DataValueField = "id_noc";
                    ddlNoc.DataSource = noc;
                    ddlNoc.DataBind();

                }
                else
                {
                }

            }




        }

        protected int BuscaAtendimento(string intNoc, string strUsuario)
        {

            EventoRedeDataContext db = new EventoRedeDataContext();
            int intAtendimento = 0;

            var atendimentos = (from a in db.evt_chat_atendimento
                                where a.id_noc == Convert.ToInt32(intNoc) && a.Usuario == strUsuario
                                select a);

            foreach (var atendimento in atendimentos)
            {
                intAtendimento = atendimento.id_atendimento;
            }

            return intAtendimento;
        }


        protected void btnSelecionar_Click(object sender, EventArgs e)
        {


            string srtUsuario = "NoC";

            //alterado por Rodrigo 03/09 - Mudanças Chat.
            //verifica se ha algum operador online, caso contrário, redireciona para formulário de mensagens
            EventoRedeDataContext objDs = new EventoRedeDataContext();

            if (!(objDs.evt_chat_noc_status_detalhe.Where(f => f.id_noc.Equals(Convert.ToInt32(ddlNoc.SelectedValue))).Count() > 0))//não ha nenhum operador do Noc selecionado online.
            {
                //monta o script com o redirecionamento 
                System.Text.StringBuilder strScript = new System.Text.StringBuilder();
                strScript.AppendLine("<script language=\"javascript\" > ");
                strScript.AppendFormat(" Redireciona('{0}/{1}/formularioChat.aspx');",  SPContext.Current.Web.Url,  strBibliotecaChat    );
                strScript.AppendLine(@"</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "RedirecionaPaginaNovaAtendimento", strScript.ToString());
                return;
            }


            IniciaAtendimento(srtUsuario, Convert.ToInt32(ddlNoc.SelectedValue));
            //TODO:Passar isto para variável da webpart ou para uma classe de configuração global.
            string popupChatUrl =  string.Format( "{0}/{1}/popupUsuario.aspx",  SPContext.Current.Web.Url, strBibliotecaChat );

            string painelUsuarioUrl = string.Format("{0}/{1}/PainelUsuario.aspx", SPContext.Current.Web.Url, strBibliotecaChat);

            int intAtendimento = BuscaAtendimento(ddlNoc.SelectedValue, srtUsuario);

            string vstrScript = string.Empty;
            //montando o script (Hugo Thomaz)
            vstrScript = "<script language='javascript'> " +
                "if (ShowWindow('" + popupChatUrl + "','" + intAtendimento + "'))" +
                "{" +
                " Redireciona('" + painelUsuarioUrl + "');" +
                "} " +
                " <|script> ".ToString().Replace("|", "/");

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Mensagem", vstrScript);


        }


        //TODO:Verificar se realmente precisa disto.

        //classe estatica de apoio
        public static class InicioChat
        {
            public static string GetConnectionString()
            {

                EventoRedeDataContext objDs = new EventoRedeDataContext();
                return objDs.Connection.ConnectionString;



            }

            public static void ProcessaLoginOperador(string strLogin)
            {

                EventoRedeDataContext objDs = new EventoRedeDataContext();


                foreach (evt_chat_operador o in objDs.evt_chat_operador.Where(f => f.operador.Equals(strLogin)))
                {
                    o.status = 1;
                    objDs.SubmitChanges();
                }



            }


        }//fim da classe Iniciochat





        #endregion








    }
}
