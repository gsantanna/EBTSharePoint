using com.sandigital.sharepoint.webparts.VisualizadorDeListaAgrupada;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using com.sandigital.sharepoint.webparts.Webparts.VisualizadorDeListaAgrupada;
using Microsoft.SharePoint;
using System.Collections.Generic;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

namespace com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts
{
    public partial class VisualizadorDeListaAgrupadaEditor : UserControl
    {


        #region Propriedades

        private VisualizadorDeListaAgrupadaConfiguration parentEditorPart;
        spsWrapper2 objWrapper = new spsWrapper2();

        public ConfigurationItem configurationItem
        {
            get
            {
                if (ViewState["_ctl_ConfigurationItem"] == null)
                {
                    ViewState["_ctl_ConfigurationItem"] = parentEditorPart.configurationItem;
                }

                return ViewState["_ctl_ConfigurationItem"] as ConfigurationItem;

            }
            set
            {
                ViewState["_ctl_ConfigurationItem"] = value;
            }
        }

        public void AtualizaSelecao()
        {

            var objCol = this.configurationItem.Columns;
            for (int i = 0; i < objCol.Count; i++)
            {
                objCol[i].Visible = false;
                objCol[i].Grouped = false;
                objCol[i].Order = "0";
               
            }

            for (int rowIndex = 0; rowIndex < dGridConfig.VisibleRowCount; rowIndex++)
            {
                
                var chave = dGridConfig.GetRowValues(rowIndex, "InternalName" );
                var cbExibido = (ASPxCheckBox)dGridConfig.FindRowCellTemplateControl(rowIndex, (GridViewDataColumn)dGridConfig.Columns["Exibido"] , "cbExibido");
                var cbAgrupado = (ASPxCheckBox)dGridConfig.FindRowCellTemplateControl(rowIndex, (GridViewDataColumn)dGridConfig.Columns["Agrupado"], "cbAgrupado");
                var txtOrdem = (ASPxTextBox)dGridConfig.FindRowCellTemplateControl(rowIndex, (GridViewDataColumn)dGridConfig.Columns["Ordem"], "txtOrdem");

                
                var c = objCol.Find(f => f.InternalName == chave.ToString() );
                if (c != null)
                {

                    c.Visible = cbExibido != null && cbExibido.Checked;
                    c.Grouped = cbAgrupado != null && cbAgrupado.Checked;
                    c.Order = txtOrdem != null ? txtOrdem.Text : "0";
                }
                else
                {
                    throw new Exception("A col: " + chave + " não foi encontrada!");

                }

            }

            
            this.configurationItem.Columns = objCol;



        
        }



        #endregion


        #region Eventos Página

        protected void Page_Init(object sender, EventArgs e)
        {
            this.parentEditorPart = this.Parent as VisualizadorDeListaAgrupadaConfiguration;
        }


        protected void Page_Load(object sender, EventArgs e)
        { 
            if (this.hiddenFieldDetectRequest.Value == "0")
            {
                this.hiddenFieldDetectRequest.Value = "1";
                CarregaComboLista();
            }

            CarregaGridLista();


        }

        #endregion

        #region Combo

        private void CarregaComboLista()
        {
            try
            {

                this.cboLista.ValueField = "k";
                this.cboLista.TextField = "v";
                this.cboLista.ValueType = typeof(System.Guid);

                this.cboLista.DataSource = objWrapper.GetLists(SPContext.Current.Web.ID).Select(f => new { k = f.Key, v = f.Value }).ToList();
                this.cboLista.DataBind();

                this.cboLista.Items.Insert(0, new ListEditItem("-Selecione-", new Guid()));
                this.cboLista.SelectedItem = this.cboLista.Items.FindByValue(this.configurationItem.Lista);
            }
            catch (Exception ex)
            {
                lblErro.Text = "Erro ao carregar o editor. o Erro foi: " + ex.Message ; 
            }

        }

        protected void cboLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //lista selecionada.
                if (this.cboLista.SelectedItem != null)
                {
                    this.configurationItem.Lista = (Guid)this.cboLista.SelectedItem.Value;
                    //zera as colunas 
                    this.configurationItem.Columns = null;

                }
                else
                {
                    this.configurationItem = new ConfigurationItem(); //zera toda a configuração
                }



                CarregaGridLista();
            }
            catch (Exception ex)
            {
                this.lblErro.Text = "Erro ao carregar o controle, o erro foi: " + ex.Message;
            }

        } 


        #endregion

        // this.ViewState[StorageViewStateId] 

        #region Grid

        protected void CarregaGridLista()
        {
            if (this.configurationItem.Lista == new Guid()) return;//lista n preenchida

            

            //colunas não carregadas
            if (this.configurationItem.Columns == null || this.configurationItem.Columns.Count == 0)
            {
                SPList lista = objWrapper.GetList(configurationItem.Lista, SPContext.Current.Web.ID);
                this.configurationItem.Columns = new List<ConfigurationItem.ConfigurationItemColumn>();

                foreach (SPField campo in lista.Fields)
                {
                    this.configurationItem.Columns.Add(new ConfigurationItem.ConfigurationItemColumn
                    {
                        Id = campo.Id.ToString(),

                        DisplayName =  getSpecialFieldName(  campo.Title),

                        InternalName = campo.InternalName,
                        StaticName = campo.StaticName,
                        Order = "0",
                        Grouped = false,

                    });

                }


            }

            this.dGridConfig.DataSource = this.configurationItem.Columns;
            this.dGridConfig.DataBind();

        }

        private string getSpecialFieldName(string p)
        {


            switch (p.ToUpper())
            {
                case "LINKTITLE":
                    {
                        return "Título (Link)";
                        
                    } 
                case "DOCICON": 
                        {
                            return "Ícone";
                        }

                default : {
                    return p;
                }
            }
        
        
        
        }

        #endregion







    }
}
