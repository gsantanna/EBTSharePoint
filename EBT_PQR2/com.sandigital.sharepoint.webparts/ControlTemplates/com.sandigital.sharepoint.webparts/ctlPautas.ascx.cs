using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using com.sandigital.sharepoint.webparts.Modelos;
using System.Linq;
using DevExpress.Web.ASPxGridView;
using Microsoft.SharePoint;
using System.Web;
using System.ComponentModel;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebControls;
using DevExpress.Utils;


namespace com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts
{
    public partial class ctlPautas : UserControl
    {

        #region Propriedades
        
        string _TipoPautas;

        [Browsable(true),
        Category("Miscellaneous"),
        DefaultValue("Em Andamento"),
        WebPartStorage(Storage.Personal),
        FriendlyName("TipoPautas"),
        Description("Tipo da Pauta")]
        public string TipoPautas
        {
            get
            {
                return _TipoPautas;
                //return this.hfTIPO.Value.ToString();
            }
            set{
                _TipoPautas=value;
            }

        }

                  

        public List<Pauta> getPautas()
        {
            //return Pauta.Pautas();
            lock (_lock)
            {
                if (SPContext.Current.Site.Cache["Pautas"] == null || SPContext.Current.Site.Cache["Pautas"].ToString() == "RELOAD")
                {
                    AtualizaCache();
                }

                return SPContext.Current.Site.Cache["Pautas"] as List<Pauta>;
            }
        }



        #endregion

        #region Metodos_Pagina 

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack && !Page.IsCallback)
            {   
              //  try
                //{
                  
                    CarregaGridPautas();
               // }
               // catch (Exception ex)
               // {
                 //   this.lblErro.Text = "Erro ao carregar o Grid o erro foi: " + ex.Message;
                //    this.lblErro.Visible = true;
               // }


            }


        }

        public string getNomeUsuario(object strNomeUsuario)
        {
            if (strNomeUsuario == null) return string.Empty;
            return strNomeUsuario.ToString();

            //return spsWrapper.Utilidades.NomeUsuario(  strNomeUsuario.ToString());
        }

        private static object _lock = new object();

        protected void AtualizaCache()
        { 
           // ViewState["Pautas"] = CarregaPautas();
            lock (_lock)
            {   
                SPContext.Current.Site.Cache["Pautas"] = Pauta.Pautas();
            }
        }

       




        #endregion

        #region Métodos Grid 

        protected void CarregaGridPautas()
        {

            List<Pauta> objPautas = getPautas();


            int qtdConfig=  objPautas.Count(f => f.Status.ToUpper().Equals(TipoPautas.ToUpper()));
            int qtdGeral = objPautas.Count();
            float perc = ((float)qtdConfig / (float)qtdGeral);



            //Monta o título 
            this.lblTituloGrid.Text = string.Format("Pautas: {0} - {1:p}", TipoPautas,perc );


            //Carrega as Tarefas (Ocultando as concluídas)

            this.dGridPautas.DataSource =  objPautas.Where(f=>f.Status.ToUpper().Equals(TipoPautas.ToUpper())); 
            this.dGridPautas.DataBind(); 
        }

        protected void lnkAddNewItemTarefa_Click(object sender, EventArgs e)
        {

            ((ASPxGridView)(((LinkButton)sender).Parent).BindingContainer).AddNewRow();

            
        }

        protected void dGridItemTarefa_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView Grid = sender as ASPxGridView;
            PeopleEditor objppp = (PeopleEditor)Grid.FindEditRowCellTemplateControl((GridViewDataColumn)Grid.Columns[6], "pppAdd");
            int ID_TAREFA = Convert.ToInt32((sender as ASPxGridView).GetMasterRowKeyValue());
            e.NewValues["ID_TAREFA"] = ID_TAREFA;

            if(objppp!=null) e.NewValues["Responsavel"] = objppp.CommaSeparatedAccounts;



        }

        protected void dGridItemTarefa_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
            AtualizaCache();
            CarregaGridPautas();
            
        }

        protected void dGridItemTarefa_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
            AtualizaCache();
            CarregaGridPautas();
            
        }

        protected void dGridItemTarefa_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
            AtualizaCache();
            CarregaGridPautas();
        }

        protected void dGridItemTarefa_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            ASPxGridView Grid = sender as ASPxGridView;
            PeopleEditor objppp = (PeopleEditor)Grid.FindEditRowCellTemplateControl((GridViewDataColumn)Grid.Columns[6], "pppAdd");
            
            if(objppp!=null) e.NewValues["Responsavel"] = objppp.CommaSeparatedAccounts;

        }




        
        #endregion

        #region Métodos dos Object datasource

        public List<Tarefa> ListaTarefasGrid(Int32 id_pauta)
        {
            //var objPauta = (Cache["Pautas"] as List<Pauta>).Where(f => f.ID.Equals(id_pauta)).FirstOrDefault();
            var objPauta = this.getPautas().Where(f => f.ID.Equals(id_pauta)).FirstOrDefault();


             //caso a pauta esteja em andamento remove as tarefas concluídas.

            if (objPauta.Status.Equals("Em Andamento"))
            {
                return objPauta.Tarefas.Where(f => f.Status != "Concluído").ToList() ;
            }
            else
            {
                return objPauta.Tarefas.ToList();
            }

        }

        public List<ItemTarefa> ListaItemTarefasGrid(Int32 id_pauta, Int32 id_tarefa)
        {
            try
            {
                return this.getPautas().Where(p => p.ID.Equals(id_pauta)).FirstOrDefault().Tarefas.Where(t => t.ID.Equals(id_tarefa)).FirstOrDefault().Itens;
            }
            catch
            {
                return null;
            }

        }

        public void DeletaItemTarefa(ItemTarefa itemTarefa)
        {
            spsWrapper.spsWrapper objWrapper = new spsWrapper.spsWrapper();
            objWrapper.DeletaItem("Detalhe Tarefa", itemTarefa.ID);

        }

        public void AtualizaItemTarefa(ItemTarefa itemTarefa)
        {
            spsWrapper.spsWrapper objWrapper = new spsWrapper.spsWrapper();
            objWrapper.AtualizaItemLocal("Detalhe Tarefa", itemTarefa.ID, "Status", itemTarefa.Status);
            objWrapper.AtualizaItemLocal("Detalhe Tarefa", itemTarefa.ID, "Title", itemTarefa.Titulo);
            objWrapper.AtualizaItemLocal("Detalhe Tarefa", itemTarefa.ID, "DataReuniao", itemTarefa.dt_reuniao);
            objWrapper.AtualizaItemLocal("Detalhe Tarefa", itemTarefa.ID, "Responsavel", itemTarefa.Responsavel);
            objWrapper.AtualizaItemLocal("Detalhe Tarefa", itemTarefa.ID, "Detalhes", itemTarefa.Detalhes);
            objWrapper.AtualizaItemLocal("Detalhe Tarefa", itemTarefa.ID, "Prazo", itemTarefa.Prazo);

        }

        public void AdicionaItemTarefa(ItemTarefa itemTarefa)
        {
            spsWrapper.spsWrapper objWrapper = new spsWrapper.spsWrapper();
            Dictionary<string, object> Tr = new Dictionary<string, object>();
            Tr.Add("Status", itemTarefa.Status);
            Tr.Add("Title", itemTarefa.Titulo);
            Tr.Add("Tarefa", new SPFieldLookupValue(itemTarefa.ID_TAREFA, null));
            Tr.Add("Responsavel", itemTarefa.Responsavel);
            Tr.Add("DataReuniao", itemTarefa.dt_reuniao);
            Tr.Add("Detalhes", itemTarefa.Detalhes);
            Tr.Add("Prazo", itemTarefa.Prazo);

            objWrapper.AdicionaItemLista("Detalhe Tarefa", Tr);

        }


        
        #endregion

        protected void dGridItemTarefa_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {

            if (!(((ASPxGridView)sender).GetRowValues(e.VisibleIndex, "LoginResponsavel").ToString() ==  SPContext.Current.Web.CurrentUser.LoginName || spsWrapper.Utilidades.Administrador()))
                e.Visible = false;

        }

       

       

        

    }

}
