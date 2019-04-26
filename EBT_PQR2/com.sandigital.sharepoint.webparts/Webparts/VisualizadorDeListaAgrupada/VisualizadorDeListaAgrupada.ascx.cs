using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using Microsoft.SharePoint;
using System.Data;
using com.sandigital.sharepoint.webparts.Webparts.VisualizadorDeListaAgrupada;
using DevExpress.Web.ASPxGridView;
using System.Web;


namespace com.sandigital.sharepoint.webparts.VisualizadorDeListaAgrupada
{

    [ToolboxItemAttribute(false)]
    public partial class VisualizadorDeListaAgrupada : WebPart, IWebEditable
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public VisualizadorDeListaAgrupada()
        {
        }


        private ConfigurationItem _configuratonItem;

        [Personalizable(PersonalizationScope.Shared)]
        [Browsable(false)]
        public ConfigurationItem configurationItem
        {
            get
            {
                if (this._configuratonItem == null) this._configuratonItem = new ConfigurationItem();
                return this._configuratonItem;
            }
            set
            {
                this._configuratonItem = value;
            }
        }

        public override object WebBrowsableObject
        {
            get
            {
                return this;
            }
        }


        ///<summary>
        /// Needed to add custom editor parts to page
        ///</summary>
        ///<returns>Editor part collection containing said parts</returns>
        public override EditorPartCollection CreateEditorParts()
        {

            VisualizadorDeListaAgrupadaConfiguration editorPart = new VisualizadorDeListaAgrupadaConfiguration();
            editorPart.ID = this.ID + "_VisualizadorConfiguration";
            editorPart.Visible = true;
            List<EditorPart> editors = new List<EditorPart> { editorPart };
            return new EditorPartCollection(base.CreateEditorParts(), editors);




        }

        public void SaveChanges()
        {

            this.SetPersonalizationDirty();
        }





        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblErro.Text = string.Empty;

            try
            {
                if (this.configurationItem.Columns == null || this.configurationItem.Columns.Count == 0)
                {
                    this.lblErro.Text = "Webpart não configurada. Utilize o painel lateral para selecionar as colunas para exibir.";
                    return;
                }


                if (this.configurationItem.VisibleColumns.Count == 0 || this.configurationItem.GroupedColumns.Count >= this.configurationItem.VisibleColumns.Count)
                {
                    lblErro.Text = "É necessário selecionar pelo menos um campo  não agrupdo para exibir";
                    return;
                }

                CarregaLista();




            }
            catch (Exception ex)
            {
                this.lblErro.Text = "Erro ao carregar esta webpart. o erro foi: " + ex.Message;
            }

        }


        void CarregaLista()
        {
            try
            {

                //Monta um array com todas as colunas
                var arcolunas = this.configurationItem.Columns.Where(f => f.Visible || f.Grouped).OrderBy(f => f.Order).Select(f => f.Id).ToArray();

                spsWrapper2 objWrapper = new spsWrapper2();
                var objLista = objWrapper.RetornaLista(SPContext.Current.Web.ID, this.configurationItem.Lista);


                this.lblHack.Text = string.Format("<div class='ag_hackTitulo' titulo='{0}' url='{1}'></div>",
                    this.Title,
                    objWrapper.RetornaUrlLista(SPContext.Current.Web.ID, this.configurationItem.Lista)
                    );




                if (objLista == null)
                {
                    lblErro.Text = "Lista não localizada!";
                    return;
                }

                //Cria o datatable e carrega a tabela
                DataTable dtDs = new DataTable();

                arcolunas.ToList().ForEach(f => dtDs.Columns.Add(f));

                dtDs.Columns.Add("ORDENACAO", typeof(string));

                

                List<DataColumn> dtmp = new List<DataColumn>();
              
                //string strOrderBy = "";                
                //foreach ( var col in arcolunas )
               // {
                   // dtDs.Columns.Add(new DataColumn(col + "_SORT"));
                  //  strOrderBy += col + "_SORT ,";
               // } //Cria as colunas 




              //  strOrderBy = strOrderBy.Substring(0,strOrderBy.LastIndexOf(","));





                //para cada item na lista...
                
                foreach (SPListItem item in objLista)
                {
                    

                    DataRow r = dtDs.NewRow();
                    string strTmpOrdenacao = "";

                    //para cada campo (visivel ou agrupado)
                    //foreach (string s in arcolunas)
                    for(int i=0;i< arcolunas.Length;i++)
                    {
                        string s = arcolunas[i];

                        try { r[s] = formataValor(item[new Guid(s)], item.Fields[new Guid(s)], item); }
                        catch { r[s] = "Campo não localizado"; }

                        //try { r[s + "_SORT"] = getExpSortIndex( formataValor(item[new Guid(s)], item.Fields[new Guid(s)], item) )  ; }
                        //catch { r[s] = "Campo não localizado"; }

                        try { strTmpOrdenacao += getExpSortIndex(formataValor(item[new Guid(s)], item.Fields[new Guid(s)], item)) + "_"; }
                        catch { strTmpOrdenacao += "Campo não localizado_"; }
                    }


                    r["ORDENACAO"] = strTmpOrdenacao;

                    dtDs.Rows.Add(r);
                }







                dtDs.DefaultView.Sort = "ORDENACAO";
                dtDs = dtDs.DefaultView.ToTable();

                //Joga a saida já ordenada para o grid 



                this.dGridMain.DataSource = dtDs;
                this.dGridMain.DataBind();
                this.dGridMain.Visible = true;

                for (int i = 0; i < this.configurationItem.GroupedColumns.Count; i++)
                {   
                    

               
                   dGridMain.GroupBy(dGridMain.Columns[this.configurationItem.GroupedColumns[i].Id], i);                       
                   // dGridMain.SortBy(dGridMain.Columns[this.configurationItem.GroupedColumns[i].Id + "_SORT"], i);                   
                }

                dGridMain.Columns["ORDENACAO"].Visible = false;


                foreach (var c in this.dGridMain.AllColumns)
                {


                  //  if (c.ToString().EndsWith("_SORT"))
                    //    c.Visible = false;
                }
                foreach (var c in this.configurationItem.Columns.Where(f => f.Visible || f.Grouped))
                {
                    dGridMain.Columns[c.Id].Caption = c.DisplayName;
                    
                    (dGridMain.Columns[c.Id] as DevExpress.Web.ASPxGridView.GridViewDataTextColumn).PropertiesTextEdit.EncodeHtml = false;


                }



            }
            catch (Exception ex)
            {

                lblErro.Text = "Erro ao carregar a Webpart. Lista:" + this.configurationItem.Lista.ToString() + " o Erro foi: " + ex.Message;

            }


        }

        
        private string getExpSortIndex(string strParam)
        {            
            strParam = strParam.ToUpper();
            string ret = strParam;

            var meses = new string[] {
                "JAN","JANEIRO",
                "FEV","FEVEREIRO",
                "MAR","MARÇO","MARCO",
                "ABR","ABRIL",
                "MAI","MAIO",
                "JUN","JUNHO",
                "JUL","JULHO",
                "AGO","AGOSTO",
                "SET","SETEMBRO",
                "OUT","OUTUBRO",
                "NOV","NOVEMBRO",
                "DEZ","DEZEMBRO"
            };

            if (meses.Contains(strParam)) {
                ret = Array.IndexOf(meses, strParam).ToString().PadLeft(2, '0');   
            };

            return ret;
        }


        private string formataValor(object p, string tipo)
        {
            if (p == null) return string.Empty;

            if (tipo == "U")
            {

                return p.ToString().Split('#')[1];
            }
            else if (tipo == "D")
            {
                return (p as DateTime?).Value.ToString("dd/MM/yyyy");
            }

            return p.ToString();



        }

        private string formataValor(object p, SPField campo, SPItem item)
        {
            if (p == null) return string.Empty;

            if (campo.InternalName == "Edit")
            {
                string strLink = string.Format("<a href='{0}?id={1}&source={2}'> <img border='0' alt='Editar' src='/_layouts/images/edititem.gif'></a>",
                    campo.ParentList.DefaultEditFormUrl
                    , item.ID,
                    HttpContext.Current.Request.Url.ToString()
                    );

                return strLink;

            }

            if (campo.InternalName.Contains("Link") || campo.InternalName.Contains( "Title") || campo.InternalName.Contains("Name"))  
            {
                string strLink = string.Format("<a href='{0}?id={1}&source={2}'>{3}</a>",
                    campo.ParentList.DefaultDisplayFormUrl
                    , item.ID,
                    HttpContext.Current.Request.Url.ToString()
                    ,  p
                    );

                return strLink;

            }



            if (campo.Type == SPFieldType.User)
            {
                //  "_layouts/userdisp.aspx?ID={{id}}";
                return p.ToString().Split('#')[1];
            }
            else if (campo.InternalName == "Title") //montar o dispform
            {

            }
            else if (campo.Type == SPFieldType.DateTime || campo.InternalName.ToLower().Contains("_date"))
            {
                try
                {
                    var saida = Convert.ToDateTime(p);
                    if (saida.Second > 0 || saida.Minute > 0 || saida.Millisecond > 0)
                    {
                        return saida.ToString("dd/MM/yyyy hh:mm");
                    }
                    else
                    {
                        return saida.ToString("dd/MM/yyyy");
                    }
                }
                catch
                {
                    return string.Empty;
                }
            }

            return p.ToString();
        }

        protected void dGridMain_CustomColumnSort(object sender, DevExpress.Web.ASPxGridView.CustomColumnSortEventArgs e)
        {
            

            if (e.Column != null && e.Column.GroupIndex > 0  )
            {
                ASPxGridView Grd = sender as ASPxGridView;

                string campo = "ORDENACAO";//e.Column.FieldName;

            
                var i1 = getExpSortIndex(e.GetRow1Value( campo).ToString()     );
                var i2 = getExpSortIndex(e.GetRow2Value( campo).ToString()      );
                e.Handled = true;
                e.Result = System.Collections.Comparer.Default.Compare(i1, i2);

            }
             
          


        }

        protected void dGridMain_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {

        }







    }
}
