using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;


namespace com.sandigital.sharepoint.webparts.ParticipantesReuniaoLista
{
    [ToolboxItemAttribute(false)]
    public partial class ParticipantesReuniaoLista : WebPart
    {

        spsWrapper2 objWrapper = new spsWrapper2();


        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public ParticipantesReuniaoLista()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregaListaReunioes();
                CarregaGrid();
            }
           
        }


        private void CarregaListaReunioes()
        {

            try
            {
                string strViewRef = "<FieldRef Name=\"Title\" /><FieldRef Name=\"EventDate\" /><FieldRef Name=\"Title\" />";
                string strQuery = "<Where></Where>";

                var Saida = (from SPListItem item in objWrapper.RetornaLista("Reunioes", strQuery, strViewRef, SPContext.Current.Web.ID)
                             select new { dt_evento = ((DateTime)item["EventDate"]).ToString("dd/MM/yyyy"), ID = item.ID, Titulo = item.Title });



                this.cboReunioes.DataSource = Saida;
                this.cboReunioes.DataBind();

                if (Saida.Count() >0 )  this.cboReunioes.SelectedIndex = 0;

               
            }
            catch (Exception ex)
            {
                this.lblErro.Text = "Erro ao carregar a lista de reunião o erro foi " + ex.Message;
                this.lblErro.Visible = true;
            }


        }

        protected void cboReunioes_SelectedIndexChanged(object sender, EventArgs e)
        {

            CarregaGrid();


        }


        private void CarregaGrid()
        {
            if (this.cboReunioes.SelectedItem == null) return;

            var objParticipantes = (from SPListItem i in
                                        objWrapper.RetornaLista("ParticipantesReuniao", new string[] { "id_reuniao", "Participante", "id_usuario" }, SPContext.Current.Web.ID)
                                   where Convert.ToInt32(this.cboReunioes.SelectedItem.Value) == Convert.ToInt32( i.Title)
                                        // where Convert.ToInt32(i["id_reuniao"]) == Convert.ToInt32(this.cboReunioes.SelectedItem.Value)
                                    select new
                                    {
                                        Titulo = i.Title,
                                        Pessoa =  Convert.ToString(i["Participante"]).Split('#')[1],
                                        id_usuario = Convert.ToString(i["id_usuario"])
                                    }).ToList();



            grdMain.DataSource = objParticipantes;
            grdMain.DataBind();

            if (objParticipantes.Count() == 0)
            {
                lblErro.Text = "Nenhum participante encontrado";
            }
            else
            {
                lblErro.Text = string.Empty;

            }
        
        
        
        }










        
    }
}
