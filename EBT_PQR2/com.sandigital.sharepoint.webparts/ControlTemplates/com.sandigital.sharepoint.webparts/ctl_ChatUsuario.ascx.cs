using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using com.sandigital.sharepoint.dal;
using System.Linq;
using System.Collections.Generic;



namespace com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts
{
    public partial class ctl_ChatUsuario : UserControl
    {


        #region "Load"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string srtUsuario = Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1];
                Label lblNoc = this.FindControl("lblNoc") as Label;
                Label lblOperador = this.FindControl("lblOperador") as Label;
                System.Web.UI.Timer tVerificaMsgs = this.FindControl("tVerificaMsgs") as System.Web.UI.Timer;
                System.Web.UI.Timer tAtualizaGrid = this.FindControl("tAtualizaGrid") as System.Web.UI.Timer;
                DevExpress.Web.ASPxGridView.ASPxGridView dGridMain = this.FindControl("dGridMain") as DevExpress.Web.ASPxGridView.ASPxGridView;

                if ((Request.QueryString["id_atendimento"] == null))
                {
                    tAtualizaGrid.Enabled = false;
                    tVerificaMsgs.Enabled = false;

                    ViewState["id_atendimento"] = "0";
                    tVerificaMsgs.Enabled = true;
                }
                else
                {
                    TextBox txtMessage = this.FindControl("txtMessage") as TextBox;
                    DevExpress.Web.ASPxEditors.ASPxButton btnSend = this.FindControl("btnSend") as DevExpress.Web.ASPxEditors.ASPxButton;
                    DevExpress.Web.ASPxEditors.ASPxButton btnFinalizar = this.FindControl("btnFinalizar") as DevExpress.Web.ASPxEditors.ASPxButton;
                    DevExpress.Web.ASPxEditors.ASPxButton btnReabir = this.FindControl("btnReabir") as DevExpress.Web.ASPxEditors.ASPxButton;

                    tVerificaMsgs.Enabled = true;
                    ///PageControl.ActiveTabIndex = 0;                                        
                    ViewState.Add("id_atendimento", Request.QueryString["id_atendimento"].ToString());

                    BuscaTitulo(lblNoc, lblOperador, ViewState["id_atendimento"].ToString());
                    if (BuscaFinalizado(ViewState["id_atendimento"].ToString()))
                    {
                        btnFinalizar.Visible = false;
                        btnSend.Visible = false;
                        txtMessage.Visible = false;
                        btnReabir.Visible = true;
                    }
                    else
                    {
                        btnFinalizar.Visible = true;
                        btnSend.Visible = true;
                        txtMessage.Visible = true;
                        btnReabir.Visible = false;
                    }

                    //new tVerificaMsgs_Tick(this, e);
                    tVerificaMsgs.Enabled = true;

                    CarregaMsg();
                }
            }


            if (Request.Form["__EVENTTARGET"] == "Open")
            {
                ViewState["id_atendimento"] = Request.Form["__EVENTARGUMENT"].ToString();
                CarregaMsg();
            }
            //ScriptManager1.Focus();        
        }

        #endregion

        #region "Botoes"

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox txtMessage = this.FindControl("txtMessage") as TextBox;
                if (txtMessage.Text.Length > 0)
                {
                    string srtUsuario = Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1];
                    InserirMensagem(ViewState["id_atendimento"].ToString(), txtMessage.Text, srtUsuario);
                    CarregaMsg();
                    txtMessage.Text = String.Empty;
                    //ScriptManager1.SetFocus(txtMessage.ClientID);





                }
            }
            catch { }
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            TextBox txtMessage = this.FindControl("txtMessage") as TextBox;
            DevExpress.Web.ASPxEditors.ASPxButton btnSend = this.FindControl("btnSend") as DevExpress.Web.ASPxEditors.ASPxButton;
            DevExpress.Web.ASPxEditors.ASPxButton btnFinalizar = this.FindControl("btnFinalizar") as DevExpress.Web.ASPxEditors.ASPxButton;
            DevExpress.Web.ASPxEditors.ASPxButton btnReabir = this.FindControl("btnReabir") as DevExpress.Web.ASPxEditors.ASPxButton;
            string srtUsuario = Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1];

            FinalizarAtendimento(ViewState["id_atendimento"].ToString(), srtUsuario);
            CarregaMsg();
            txtMessage.Text = String.Empty;
            btnSend.Visible = false;
            btnFinalizar.Visible = false;
            txtMessage.Visible = false;
            btnReabir.Visible = true;
        }

        protected void btnReabir_Click(object sender, EventArgs e)
        {
            TextBox txtMessage = this.FindControl("txtMessage") as TextBox;
            DevExpress.Web.ASPxEditors.ASPxButton btnSend = this.FindControl("btnSend") as DevExpress.Web.ASPxEditors.ASPxButton;
            DevExpress.Web.ASPxEditors.ASPxButton btnFinalizar = this.FindControl("btnFinalizar") as DevExpress.Web.ASPxEditors.ASPxButton;
            DevExpress.Web.ASPxEditors.ASPxButton btnReabir = this.FindControl("btnReabir") as DevExpress.Web.ASPxEditors.ASPxButton;
            string srtUsuario = Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1];

            ReabirAtendimento(ViewState["id_atendimento"].ToString(), srtUsuario);
            CarregaMsg();
            txtMessage.Text = String.Empty;
            btnSend.Visible = true;
            btnFinalizar.Visible = true;
            txtMessage.Visible = true;
            btnReabir.Visible = false;
        }

        #endregion

        #region "Timer"

        protected void tVerificaMsgs_Tick(object sender, EventArgs e)
        {
            System.Web.UI.Timer tVerificaMsgs = this.FindControl("tVerificaMsgs") as System.Web.UI.Timer;
            System.Web.UI.Timer tAtualizaGrid = this.FindControl("tAtualizaGrid") as System.Web.UI.Timer;

            tVerificaMsgs.Enabled = false;
            int qtdMsg = Convert.ToInt32(ViewState["qtdMsg"]);


            if (qtdMsg != BuscaMensagem(ViewState["id_atendimento"].ToString()).Count)
            {
                tAtualizaGrid.Enabled = true;
                tVerificaMsgs.Enabled = false;
            }
            else
            {
                tVerificaMsgs.Enabled = true;
            }


        }

        protected void tAtualizaGrid_Tick(object sender, EventArgs e)
        {
            System.Web.UI.Timer tVerificaMsgs = this.FindControl("tVerificaMsgs") as System.Web.UI.Timer;
            System.Web.UI.Timer tAtualizaGrid = this.FindControl("tAtualizaGrid") as System.Web.UI.Timer;

            tVerificaMsgs.Enabled = false;
            tAtualizaGrid.Enabled = false;
            CarregaMsg();
            tVerificaMsgs.Enabled = true;

            //Page.RegisterClientScriptBlock("Inicio", "<script> self.focus(); document.title='Nova mensagem! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + "' </script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(),"Inicio", "<script> self.focus(); document.title='Nova mensagem! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + "' </script>");



        }

        #endregion

        #region "Metodos"

        public void CarregaMsg()
        {
            try
            {
                //Declare
                Label lblNoc = this.FindControl("lblNoc") as Label;
                Label lblOperador = this.FindControl("lblOperador") as Label;
                string srtUsuario = Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1];
                DevExpress.Web.ASPxGridView.ASPxGridView dGridMain = this.FindControl("dGridMain") as DevExpress.Web.ASPxGridView.ASPxGridView;
                //ListBox lstMsgs = this.FindControl("lstMsgs") as ListBox;
                DevExpress.Web.ASPxEditors.ASPxListBox lstMsgs = this.FindControl("lstMsgs") as DevExpress.Web.ASPxEditors.ASPxListBox;


                TextBox txtMessage = this.FindControl("txtMessage") as TextBox;
                DevExpress.Web.ASPxEditors.ASPxButton btnSend = this.FindControl("btnSend") as DevExpress.Web.ASPxEditors.ASPxButton;
                DevExpress.Web.ASPxEditors.ASPxButton btnFinalizar = this.FindControl("btnFinalizar") as DevExpress.Web.ASPxEditors.ASPxButton;
                DevExpress.Web.ASPxEditors.ASPxButton btnReabir = this.FindControl("btnReabir") as DevExpress.Web.ASPxEditors.ASPxButton;

                BuscaTitulo(lblNoc, lblOperador, ViewState["id_atendimento"].ToString());

                //Carrega as mensagens
                List<evt_chat_msg> objMsgs = BuscaMensagem(ViewState["id_atendimento"].ToString());

                //Limpa a lista 
                lstMsgs.Items.Clear();

                //Atualiza o viewstate com a quantidade         
                ViewState["qtdMsg"] = objMsgs.Count;

                //Adiciona os items de traz pra frente 
                foreach (evt_chat_msg c in objMsgs)
                {
                    DateTime data = (c.data == null ? DateTime.MinValue : (DateTime)c.data);

                    if (data.ToShortDateString() != DateTime.Now.ToShortDateString())
                    {
                        lstMsgs.Items.Add(data.ToShortDateString() + " " + data.ToShortTimeString() + " " + c.de + " diz: " + c.msg.Replace("\n", "<br>"));
                    }
                    else
                    {
                        lstMsgs.Items.Add(data.ToShortTimeString() + " " + c.de + " diz: " + c.msg.Replace("\n", "<br>"));
                    }
                }



                //seleciona o primeiro item 
                lstMsgs.SelectedIndex = lstMsgs.Items.Count - 1;

                if ((lstMsgs.Items.Count > 0))
                {
                    txtMessage.Text = String.Empty;
                    btnSend.Visible = true;
                    btnFinalizar.Visible = true;
                    txtMessage.Visible = true;
                    btnReabir.Visible = false;

                    if ((lstMsgs.Items[lstMsgs.Items.Count - 1].Text.IndexOf("Chat Finalizado") != -1))
                    {
                        txtMessage.Text = String.Empty;
                        btnSend.Visible = false;
                        btnFinalizar.Visible = false;
                        txtMessage.Visible = false;
                        btnReabir.Visible = true;
                    }
                }
                else
                {
                    txtMessage.Text = String.Empty;
                    btnSend.Visible = true;
                    btnFinalizar.Visible = true;
                    txtMessage.Visible = true;
                    btnReabir.Visible = false;
                }
            }
            catch { }
        }



        protected void BuscaTitulo(System.Web.UI.WebControls.Label lblNoc, System.Web.UI.WebControls.Label lblOperador, string strAtendimento)
        {
            try
            {
                EventoRedeDataContext db = new EventoRedeDataContext();

                var atendimentos = (from a in db.evt_chat_atendimento
                                    join n in db.evt_chat_noc on a.id_noc equals n.id_noc
                                    where a.id_atendimento == Convert.ToInt32(strAtendimento)
                                    select new { a, n.descricao }).FirstOrDefault();

                lblNoc.Text = atendimentos.descricao;
                lblOperador.Text = ((atendimentos.a.Operador != null) ? atendimentos.a.Operador : "Pendente");
            }
            catch { }
        }

        protected bool BuscaFinalizado(string intAtendimento)
        {
            try
            {
                EventoRedeDataContext db = new EventoRedeDataContext();
                DateTime dt_fim = DateTime.MinValue;

                var atendimentos = (from a in db.evt_chat_atendimento
                                    where a.id_atendimento == Convert.ToInt32(intAtendimento)
                                    select a);

                foreach (var atendimento in atendimentos)
                {
                    dt_fim = (atendimento.dt_fim == null ? DateTime.MinValue : (DateTime)atendimento.dt_fim);
                }
                return (dt_fim != DateTime.MinValue);
            }
            catch { return false; }

        }

        protected List<evt_chat_msg> BuscaMensagem(string strAtendimento)
        {
            try
            {
                EventoRedeDataContext objMsg = new EventoRedeDataContext();

                var messages = (from m in objMsg.evt_chat_msg
                                where m.id_atendimento == Convert.ToInt32(strAtendimento)
                                orderby m.data ascending
                                select m);

                List<evt_chat_msg> objSaida = new List<evt_chat_msg>();
                objSaida = messages.ToList<evt_chat_msg>();

                objMsg.Dispose();

                return objSaida;
            }
            catch { return null; }

        }

        protected void InserirMensagem(string strAtendimento, string text, string srtUsuario)
        {
            EventoRedeDataContext db = new EventoRedeDataContext();

            db.EVT_InserirMsg(Convert.ToInt32(strAtendimento), srtUsuario, text);
        }

        protected void ReabirAtendimento(string strAtendimento, string strUsuario)
        {
            EventoRedeDataContext db = new EventoRedeDataContext();

            db.EVT_ReabrirAtendimento(Convert.ToInt32(strAtendimento), strUsuario);
        }

        protected void FinalizarAtendimento(string strAtendimento, string strUsuario)
        {
            EventoRedeDataContext db = new EventoRedeDataContext();

            db.EVT_FinalizarAtendimento(Convert.ToInt32(strAtendimento), strUsuario);
        }

        #endregion


























    }
}
