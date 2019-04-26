using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Linq;


namespace com.sandigital.sharepoint.webparts.ParticipantesReuniao
{
    [ToolboxItemAttribute(false)]
    public partial class ParticipantesReuniao : WebPart
    {



        spsWrapper2 objWrapper = new spsWrapper2();



        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public ParticipantesReuniao()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Page.IsPostBack)
            {
                CarregaListaReunioes();
            }

            bool adm = spsWrapper.Utilidades.Administrador();

            this.grid.Columns[1].Visible = adm;
            this.pppAdd.Visible = adm;
            this.btnIncluir.Visible = adm;
            this.pnlAdd.Visible = adm;



        }



        #region Reunioes



        private void CarregaListaReunioes()
        {

            try
            {
                string strViewRef = "<FieldRef Name=\"Title\" /><FieldRef Name=\"EventDate\" /><FieldRef Name=\"Title\" />";
                string strQuery = "<Where></Where>";

                var Saida = (from SPListItem item in objWrapper.RetornaLista("Reunioes", strQuery, strViewRef, SPContext.Current.Web.ID)
                             where ((DateTime)item["EventDate"]).Date >= DateTime.Now.Date
                             select new { dt_evento = ((DateTime)item["EventDate"]).ToString("dd/MM/yyyy"), ID = item.ID, Titulo = item.Title });



                this.cboReunioes.DataSource = Saida;
                this.cboReunioes.DataBind();
                if (this.cboReunioes.Items.Count > 0) this.cboReunioes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                this.lblErro.Text = "Erro ao carregar a lista de reunião o erro foi " + ex.Message;
                this.lblErro.Visible = true;
            }


        }

        #endregion

        #region DataSourceGridParticipantes
        [Serializable]
        public class Usuario
        {
            public string id_usuario { get; set; }
            public string id_reuniao { get; set; }
            public int id_registro { get; set; }
            public string nome { get; set; }
        }
        public List<Usuario> ListaUsuarios(string id_reuniao)
        {

            var Saida = (from SPListItem item in
                             objWrapper.RetornaLista("ParticipantesReuniao", new string[] { "Title", "id_usuario" }, SPContext.Current.Web.ID)
                         where item["Title"].Equals(id_reuniao)
                         select new Usuario { id_usuario = item["id_usuario"].ToString(), nome = spsWrapper.Utilidades.NomeUsuario(item["id_usuario"].ToString()), id_registro = item.ID, id_reuniao = item.Title }).ToList();




            return Saida;







        }




        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {


            objWrapper.DeletaItem("ParticipantesReuniao", Convert.ToInt32(e.Keys[0]));

            grid.DataBind();

            e.Cancel = true;
            //Remover o usuário!


        }

        #endregion


        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        protected void btnIncluir_Click(object sender, EventArgs e)
        {

            if (pppAdd.ResolvedEntities.Count <= 0) return; //nenhum usuario selecionado 



            foreach (Microsoft.SharePoint.WebControls.PickerEntity Pessoa in pppAdd.ResolvedEntities)
            {

                //verifica se o usuario já foi adicionado na reunião
                if ((from SPListItem u in objWrapper.RetornaLista("ParticipantesReuniao", new string[] { "id_usuario", "Title" }, SPContext.Current.Web.ID)
                     where
                     u.Title == this.cboReunioes.SelectedItem.Value.ToString() &&
                     u["id_usuario"].ToString() == Pessoa.Key
                     select u).Count() == 0)
                {


                    //monta o dicionario de valores
                    Dictionary<string, object> dicItem = new Dictionary<string, object>();

                    dicItem.Add("id_usuario", Pessoa.Key);
                    dicItem.Add("Title", this.cboReunioes.SelectedItem.Value.ToString());

                    //Carrega a pessoa 
                    SPUser usrP =
                    SPContext.Current.Web.EnsureUser(Pessoa.Key);


                    // dicItem.Add("Participante",  (new SPFieldUserValue(SPContext.Current.Web, Convert.ToInt32(Pessoa.EntityData["SPUserID"]), Pessoa.Key))  );
                    dicItem.Add("Participante", (new SPFieldUserValue(SPContext.Current.Web, usrP.ID, Pessoa.Key)));

                    objWrapper.AdicionaItemLista("ParticipantesReuniao", dicItem);


                }
            }


            //Limpa o epp
            pppAdd.ResolvedEntities.Clear();

            //força a atualização do grid
            grid.DataBind();


        }









































    }
}
