using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using com.sandigital.sharepoint.dal;
using System.Collections.Generic;
using System.Linq;
namespace com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts
{
    public partial class ctl_ChatOperador : UserControl
    {

        

        protected string _strErro = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox txtMessage = this.FindControl("txtMessage") as TextBox;
                DevExpress.Web.ASPxEditors.ASPxButton btnSend = this.FindControl("btnSend") as DevExpress.Web.ASPxEditors.ASPxButton;
                DevExpress.Web.ASPxEditors.ASPxButton btnFinalizar = this.FindControl("btnFinalizar") as DevExpress.Web.ASPxEditors.ASPxButton;
                DevExpress.Web.ASPxEditors.ASPxButton btnReabir = this.FindControl("btnReabir") as DevExpress.Web.ASPxEditors.ASPxButton;

                string srtUsuario = Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1];

                if (Request.QueryString["id"] == null)
                {
                    ViewState.Add("id_atendimento", "0");
                }
                else
                {
                    ViewState.Add("id_atendimento", Request.QueryString["id"].ToString());

                    Label lblNoc = this.FindControl("lblNoc") as Label;
                    Label lblUsuario = this.FindControl("lblUsuario") as Label;
                    BuscaTitulo(lblNoc, lblUsuario, ViewState["id_atendimento"].ToString());

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
                    CarregaMsg();
                }
            }
        }

        public void CarregaMsg()
        {
           // Page.RegisterClientScriptBlock("Inicio", "<script> self.focus(); document.title='Nova mensagem! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + "' </script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Inicio", "<script> self.focus(); document.title='Nova mensagem! " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + "' </script>");

            //Declare
            Label lblNoc = this.FindControl("lblNoc") as Label;
            Label lblOperador = this.FindControl("lblOperador") as Label;
            string srtUsuario = Request.ServerVariables["REMOTE_USER"].Split(char.Parse("\\"))[1];
            

            DevExpress.Web.ASPxEditors.ASPxListBox lstMsgs = this.FindControl("lstMsgs") as DevExpress.Web.ASPxEditors.ASPxListBox;



            TextBox txtMessage = this.FindControl("txtMessage") as TextBox;
            DevExpress.Web.ASPxEditors.ASPxButton btnSend = this.FindControl("btnSend") as DevExpress.Web.ASPxEditors.ASPxButton;
            DevExpress.Web.ASPxEditors.ASPxButton btnFinalizar = this.FindControl("btnFinalizar") as DevExpress.Web.ASPxEditors.ASPxButton;
            DevExpress.Web.ASPxEditors.ASPxButton btnReabir = this.FindControl("btnReabir") as DevExpress.Web.ASPxEditors.ASPxButton;

            
            //Carrega as mensagens
            System.Collections.Generic.List<evt_chat_msg> objMsgs = BuscaMensagem(ViewState["id_atendimento"].ToString());

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
                    lstMsgs.Items.Add(data.ToShortTimeString() + " " + c.de + " diz: " + c.msg);
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

        protected void btnSend_Click(object sender, EventArgs e)
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

        public void BuscaTitulo(System.Web.UI.WebControls.Label lblNoc, System.Web.UI.WebControls.Label lblUsuario, string strAtendimento)
        {
            EventoRedeDataContext db = new EventoRedeDataContext();

            var atendimentos = (from a in db.evt_chat_atendimento
                                join n in db.evt_chat_noc on a.id_noc equals n.id_noc
                                where a.id_atendimento == Convert.ToInt32(strAtendimento)
                                select new { a, n.descricao }).FirstOrDefault();

            lblNoc.Text = atendimentos.descricao;
            lblUsuario.Text = ((atendimentos.a.Usuario != null) ? atendimentos.a.Usuario : "Pendente");
        }

        public bool BuscaFinalizado(string intAtendimento)
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

        public List<evt_chat_msg> BuscaMensagem(string strAtendimento)
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

        public void InserirMensagem(string strAtendimento, string text, string srtUsuario)
        {
            EventoRedeDataContext db = new EventoRedeDataContext();

            db.EVT_InserirMsg(Convert.ToInt32(strAtendimento), srtUsuario, text);
        }

        public void ReabirAtendimento(string strAtendimento, string strUsuario)
        {
            EventoRedeDataContext db = new EventoRedeDataContext();

            db.EVT_ReabrirAtendimento(Convert.ToInt32(strAtendimento), strUsuario);
        }

        public void FinalizarAtendimento(string strAtendimento, string strUsuario)
        {
            EventoRedeDataContext db = new EventoRedeDataContext();

            db.EVT_FinalizarAtendimento(Convert.ToInt32(strAtendimento), strUsuario);
        }






        protected void tVerificaMsgs_Tick(object sender, EventArgs e)
        {
            this.tVerificaMsgs.Enabled = false;
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
            this.tVerificaMsgs.Enabled = false;
            this.tAtualizaGrid.Enabled = false;
            CarregaMsg();
            this.tVerificaMsgs.Enabled = true;


        }




    }
}
