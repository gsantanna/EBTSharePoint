using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Linq;
using com.sandigital.sharepoint.webparts.Modelos;
using System.Drawing;


namespace com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts
{
    public partial class ctlPainelProdutividade_Causa : UserControl
    {
        protected void btnGerarGrid_Click(object sender, EventArgs e)
        {
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            this.pnlMain.Visible = false;

           
            this.lblAviso.Text = string.Empty;
            //verifica as datas 
            if (cboDtFim.Value == null || cboDtInicio.Value == null)
            {
                this.lblAviso.Text = "Favor selecionar as datas";
                return;
            }

            if (cboDtInicio.Date > cboDtFim.Date)
            {
                this.lblAviso.Text = "A data início não pode ser superior a data fim";
                return;
            }

            if (cboDtFim.Date.Subtract(cboDtInicio.Date).TotalDays > 365)
            {
                this.lblAviso.Text = "Intervalo muito grande, não é possível realizar a consulta";
                return;
            }


            #region Causas
            //Causas
            List<Produtividade> dtCausas = Produtividade.GetCausas(cboDtInicio.Date, cboDtFim.Date);
            this.chartCausas.Series.Clear();
            this.chartCausas.DataSource = dtCausas;
            chartCausas.SeriesDataMember = "Causa";
            chartCausas.SeriesTemplate.ArgumentDataMember = "PeriodoFormatado";
            chartCausas.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "qtdRecs" });
            chartCausas.DataBind();
            chartCausas.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
            chartCausas.CrosshairOptions.ShowCrosshairLabels = false;
            foreach (DevExpress.XtraCharts.Series serie in chartCausas.Series)
            {
                serie.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            }
            #endregion


            #region Tratamentos

            //Tratamentos
            List<Produtividade> dtTratamento = Produtividade.GetTratamentos(cboDtInicio.Date, cboDtFim.Date);
            this.chartTratamento.Series.Clear();
            this.chartTratamento.DataSource = dtTratamento;
            chartTratamento.SeriesDataMember = "Tratamento";
            chartTratamento.SeriesTemplate.ArgumentDataMember = "PeriodoFormatado";
            chartTratamento.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "qtdRecs" });
            chartTratamento.DataBind();
            chartTratamento.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
            chartTratamento.CrosshairOptions.ShowCrosshairLabels = false;
            foreach (DevExpress.XtraCharts.Series serie in chartTratamento.Series)
            {
                serie.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            }

            #endregion




            this.pnlMain.Visible = true;



        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        string[] Cores = new string[] { "#B20000","#4A004A","#FF0000","#000066","#FFFF00","#333352","#009933","#BA99BA","#404042","#660066","#CC00CC","#006B24","#999900","#FF99FF","#6666A3","#80B592","#145214","#661C1C","#930093","#FF4D4D" };

        
        protected void chartTop_CustomDrawSeriesPoint(object sender, DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs e)
        {
            
            int indice = e.Series.Points.IndexOf(e.SeriesPoint);

            if(indice < Cores.Length)
            {
               e.SeriesDrawOptions.Color = System.Drawing.ColorTranslator.FromHtml(Cores[indice]);
               e.LegendDrawOptions.Color = e.SeriesDrawOptions.Color;
            }

        }



    }
}
