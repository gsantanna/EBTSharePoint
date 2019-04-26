using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using com.sandigital.sharepoint.dal;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web;


namespace com.sandigital.sharepoint.webparts.PainelOperador
{
    [ToolboxItemAttribute(false)]
    public partial class PainelOperador : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public PainelOperador()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }


        protected string _strErro = string.Empty;
        public enum StatusOperador { Online = 1, Offline = 0 }

        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = Page.Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1];

            //Verificar se o usuario pertence a algum noc 
            if (!Page.IsPostBack)
            {
                VerificaOperador();
                BuscaStatusOperador(usuario);
            }
            else
            {
                CarregaGrids();
            }


            if (ViewState["OP"] != null)
                CarregaGrids();

            if (Page.Request.Form["__EVENTTARGET"] == "MeusAtendimentos")
            {

                PassaParaMeusAtendimentosOperador(Page.Request.Form["__EVENTARGUMENT"].ToString(), usuario);
            }
        }

        protected void TAtualizaGrids_Tick(object sender, EventArgs e)
        {
            CarregaGrids();
        }

        protected void CarregaGrids()
        {
            //Declare ASPxGridView
            // DevExpress.Web.ASPxGridView.ASPxGridView dGridMain = this.FindControl("dGridMain") as DevExpress.Web.ASPxGridView.ASPxGridView;
            // DevExpress.Web.ASPxGridView.ASPxGridView dGridMainMeusAtend = this.FindControl("dGridMainMeusAtend") as DevExpress.Web.ASPxGridView.ASPxGridView;

            //DataBind Atendimento Pendente
            List<EVT_ConsultaPendenciaNocOperadorResultado> lsPendente = CarregaPainelAtendimentoPendente(ViewState["OP"].ToString());

            dGridMain.DataSource = lsPendente;
            dGridMain.DataBind();

            

            if (ViewState["qtdPendente"] != null)
            {
                if (lsPendente.Count() > Convert.ToInt32(ViewState["qtdPendente"])) //Existe novos 
                {
                    //pula a página
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Inicio", "<script> self.focus(); document.title='Nova mensagem! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + "' </script>");
                }
            }

            ViewState["qtdPendente"] = lsPendente.Count();


            //DataBind Meus Atendimentos
            dGridMainMeusAtend.DataSource = CarregaPainelMeusAtendimentos(ViewState["OP"].ToString());
            dGridMainMeusAtend.DataBind();
        }

        protected void CarregaGridEventoDetalhe(DevExpress.Web.ASPxGridView.ASPxGridView objGrid, string strUsuario, int intComunidade, string strFiltro)
        {
            try
            {
                EventoRedeDataContext objDc = new EventoRedeDataContext();
                objGrid.DataSource = objDc.EVT_ConsultaPainelOperador("").ToList();
                objGrid.DataBind();
            }
            catch { }
        }

        //Verificar se o usuario logado pertence a algum noc
        protected void VerificaOperador()
        {
            try
            {
                EventoRedeDataContext objDc = new EventoRedeDataContext();
                evt_chat_operador Op = (from o in objDc.evt_chat_operador
                                        where o.operador.Equals(Page.Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1])
                                        select o).FirstOrDefault<evt_chat_operador>();

                if (Op == null)
                {
                    //botar o erro aqui 
                    string vstrScript = string.Empty;
                    //montando o script
                    vstrScript = "<script language='javascript'> " +
                        "alert('O Usuário :" + Page.Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1] + "' nao esta cadastrado como operador.);history.go(-1);" +
                        " <|script> ".ToString().Replace("|", "/");

                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Mensagem", vstrScript);

                }
                else
                {
                   
                    ViewState.Add("OP", Op.operador);

                    //chamar o carregamento da pagina aqui               
                    CarregaGrids();
                }
            }
            catch (Exception ex)
            {
                this.lblErro.Text = ex.Message;
            }
        }

        //Painel Status Noc 
        protected System.Collections.Generic.List<evt_chat_noc_status> CarregaStatusNoc()
        {
            try
            {
                EventoRedeDataContext objDc = new EventoRedeDataContext();
                return objDc.evt_chat_noc_status.ToList();
            }
            catch { return null; }
        }

        //Painel Meus Atendimentos
        protected System.Collections.Generic.List<com.sandigital.sharepoint.dal.PainelOperador> CarregaPainelMeusAtendimentos(string operador)
        {
            try
            {
                EventoRedeDataContext objDc = new EventoRedeDataContext();
                return objDc.EVT_ConsultaPainelOperador(operador).OrderBy(f => f.Status).OrderByDescending(f => f.dt_inicio).ToList<com.sandigital.sharepoint.dal.PainelOperador>();
            }
            catch { return null; }
        }

        //Painel Atendimento Pendente
        protected System.Collections.Generic.List<EVT_ConsultaPendenciaNocOperadorResultado> CarregaPainelAtendimentoPendente(string operador)
        {
            try
            {
                EventoRedeDataContext objDc = new EventoRedeDataContext();
                return objDc.EVT_ConsultaPendenciaNocOperador(operador).OrderBy(f => f.dt_inicio).ToList();
            }
            catch { return null; }
        }

        protected void BuscaStatusOperador(string operador)
        {
            try
            {
                //Declare ASPxGridView
                HiddenField HField = this.FindControl("HField") as HiddenField;

                int intStatus = 0;

                EventoRedeDataContext objDc = new EventoRedeDataContext();

                var operadorStatus = from o in objDc.evt_chat_operador
                                     where o.operador.Equals(operador)
                                     select o;

                foreach (evt_chat_operador o in operadorStatus)
                    intStatus = (int)o.status;



                DevExpress.Web.ASPxEditors.ASPxButton objBtn = this.FindControl("btnStatusOperador") as DevExpress.Web.ASPxEditors.ASPxButton;

                switch (intStatus)
                {
                    case (0):
                        {
                            objBtn.Text = "Offline";
                            ViewState["StatusOperador"] = "Online";
                            break;
                        }
                    default:
                        {
                            objBtn.Text = "Online";
                            ViewState["StatusOperador"] = "Offline";
                            break;
                        }
                }

                HField.Value = intStatus.ToString();

            }
            catch (Exception ex) { this.lblErro.Text = ex.Message; }
        }

        protected void SetaStatusOperador(string operador, StatusOperador s)
        {
            try
            {
                EventoRedeDataContext objDc = new EventoRedeDataContext();

                var operadorStatus = from o in objDc.evt_chat_operador
                                     where o.operador.Equals(operador)
                                     select o;

                foreach (evt_chat_operador o in operadorStatus)
                    o.status = (int)s;

                objDc.SubmitChanges();

                BuscaStatusOperador(operador);
            }
            catch (Exception ex)
            {
                this.lblErro.Text = ex.Message;

            }
        }

        protected void PassaParaMeusAtendimentosOperador(string id_atendimento, string operador)
        {
            try
            {
                EventoRedeDataContext objDc = new EventoRedeDataContext();

                var meusAtendimentos = from o in objDc.evt_chat_atendimento
                                       where o.id_atendimento.Equals(id_atendimento)
                                       select o;

                foreach (evt_chat_atendimento o in meusAtendimentos)
                    o.Operador = operador;

                objDc.SubmitChanges();
            }
            catch { }
            finally
            {
                CarregaGrids();
            }
        }

        protected void btnStatusOperador_Click(object sender, EventArgs e)
        {
            if (ViewState["StatusOperador"] == null) ViewState["StatusOperador"] = "Offline";


            switch (ViewState["StatusOperador"].ToString())
            {
                case ("Offline"):
                    {
                        ViewState["StatusOperador"] = "Online";
                        SetaStatusOperador(ViewState["OP"].ToString(), StatusOperador.Offline);
                        break;
                    }
                default:
                    {
                        ViewState["StatusOperador"] = "Offline";
                        SetaStatusOperador(ViewState["OP"].ToString(), StatusOperador.Online);
                        break;
                    }
            }
        }
		
		
		


















































        



















    }
}
