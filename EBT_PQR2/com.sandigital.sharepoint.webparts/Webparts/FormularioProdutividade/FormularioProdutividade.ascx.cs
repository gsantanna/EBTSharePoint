using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;


namespace com.sandigital.sharepoint.webparts.FormularioProdutividade
{
    [ToolboxItemAttribute(false)]
    public partial class FormularioProdutividade : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public FormularioProdutividade()
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string strErro = string.Empty ;

            if (string.IsNullOrEmpty(txtRecs.Text)) strErro = "Favor informar o n da rec";

            if (string.IsNullOrEmpty(this.cboCausa.Text) || !(this.cboCausa.SelectedIndex > 0)) strErro = "Favor selecionar a causa";

            if (cboCausa.Text == "Rec indevida pela NET" && !(cboTratamento.SelectedIndex > 0)) strErro = "Favor selecionar o tratamento";


            if (!string.IsNullOrEmpty(strErro))
            {
                this.lblErro.Text = strErro;
                this.pnlFalha.Visible = true;
                this.pnlSucesso.Visible = false;
                return;
            }
            else
            {
                this.pnlFalha.Visible = false;
            }


            spsWrapper2 objWrapper = new spsWrapper2();
            //Cria o item de insert 

            Dictionary<string, object> objInsert = new Dictionary<string, object>(); 
            objInsert.Add("Usuario", SPContext.Current.Web.CurrentUser.LoginName);
            objInsert.Add("Title",  txtRecs.Text);
            objInsert.Add("Causa", cboCausa.Text);

            if (cboCausa.Text == "Rec indevida pela NET") objInsert.Add("Tratamento", this.cboTratamento.Text);


            objWrapper.AdicionaItemLista("Produtividade", objInsert);

            this.pnlSucesso.Visible = true;
            this.pnlFalha.Visible = false;

            this.txtRecs.Text = string.Empty;

        }

    


    }
}
