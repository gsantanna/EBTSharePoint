using com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts;
using com.sandigital.sharepoint.webparts.Webparts.VisualizadorDeListaAgrupada;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace com.sandigital.sharepoint.webparts.VisualizadorDeListaAgrupada
{

    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Unrestricted)]
    public class VisualizadorDeListaAgrupadaConfiguration : EditorPart
    {
     
        //Controle.
        VisualizadorDeListaAgrupadaEditor configuradorUserControl;

       // TextBox txTeste;


        public VisualizadorDeListaAgrupadaConfiguration()
        {
            this.Title = "Configurações";
        }
         
        public ConfigurationItem configurationItem {get;set;}
       

        ///<summary>
        /// Saves configuration back to web part
        ///</summary>
        ///<returns>true</returns>
        public override bool ApplyChanges()
        {
            if (this.configurationItem == null) this.configurationItem = new ConfigurationItem();

            configuradorUserControl.AtualizaSelecao();

            //this.configurationItem.Lista = new Guid(txTeste.Text);
            this.configurationItem = configuradorUserControl.configurationItem;  
          
            VisualizadorDeListaAgrupada wp = (VisualizadorDeListaAgrupada)WebPartToEdit;

            wp.configurationItem = this.configurationItem;
            wp.SaveChanges();
            return true;
        }

        ///<summary>
        /// Load configuration, method is unused
        ///</summary>
        public override void SyncChanges()
        {

                // sync with the new property changes here
                EnsureChildControls();
                VisualizadorDeListaAgrupada wp = (VisualizadorDeListaAgrupada)WebPartToEdit;
                if (wp != null)
                {
                    this.configurationItem = wp.configurationItem;
                    this.configuradorUserControl.configurationItem = this.configurationItem;
                    // this.txTeste.Text = wp.configurationItem.Lista.ToString();

                }
         

        }




        ///<summary>
        /// Create controls for tool part
        ///</summary>
        protected override void CreateChildControls()
        {
            try
            {
                base.CreateChildControls();
                ToolPane pane = this.Zone as ToolPane;
                if (pane != null)
                {
                    pane.Cancel.CausesValidation = false;
                    pane.Cancel.Click += new EventHandler(Cancel_Click);
                }



                //        const string caminhoControle = @"~/_CONTROLTEMPLATES/com.sandigital.sharepoint.webparts/VisualizadorDeListaAgrupadaEditor.ascx";

                this.configuradorUserControl = this.Page.LoadControl("~/_CONTROLTEMPLATES/com.sandigital.sharepoint.webparts/VisualizadorDeListaAgrupadaEditor.ascx") as VisualizadorDeListaAgrupadaEditor;
                this.configuradorUserControl.ID = WebPartToEdit.ID + "ctl_Editor";
                this.Controls.Add(configuradorUserControl);
            }
            catch 
            {
                
                
            }
        }

        void Cancel_Click(object sender, EventArgs e)
        {

        }




    }


}
