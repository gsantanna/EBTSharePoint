using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Linq;
using com.sandigital.sharepoint.webparts.Modelos;
using DevExpress.XtraCharts;


namespace com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts
{
    public partial class ctlPainelProdutividade : UserControl
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


            //Produtividade
            List<Produtividade> dtProd = Produtividade.GetEvolucaoMensalPorFuncionario(cboDtInicio.Date, cboDtFim.Date);
            this.chartTop.DataSource = dtProd;
            chartTop.SeriesDataMember = "Periodo";
            chartTop.SeriesTemplate.ArgumentDataMember = "Funcionario";
            chartTop.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "qtdRecs" });
            chartTop.DataBind();
            foreach (DevExpress.XtraCharts.Series serie in chartTop.Series)
            {
                
                serie.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                serie.Label.LineVisible = true;
                serie.LegendPointOptions.PointView = DevExpress.XtraCharts.PointView.Values;

            }

            XYDiagram diagram = (XYDiagram)chartTop.Diagram;
            diagram.EnableAxisXScrolling = true;



            //Evolução Geral
            List<Produtividade> dtEvolucao = Produtividade.GetEvolucaoMensal(cboDtInicio.Date, cboDtFim.Date);
            this.chartRight.DataSource = dtEvolucao;
            this.chartRight.SeriesDataMember = "Funcionario";
            this.chartRight.SeriesTemplate.ArgumentDataMember = "Periodo";
            this.chartRight.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "qtdRecs" });
            this.chartRight.DataBind();

            foreach (DevExpress.XtraCharts.Series serie in chartRight.Series)
            {
                serie.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                serie.Label.LineVisible = true;
                serie.LegendPointOptions.PointView = DevExpress.XtraCharts.PointView.Values;

            }



            //Evolução Diaria
            List<Produtividade> dtEvolucaoDiaria = Produtividade.GetEvolucaoDiaria(cboDtInicio.Date, cboDtFim.Date);



            for (DateTime d = this.cboDtInicio.Date; d < cboDtFim.Date; d = d.AddDays(1))
            {
                if (dtEvolucaoDiaria.Find(f => f.Periodo == d.ToString("yyyy-MM-dd")) == null)
                {
                    dtEvolucaoDiaria.Add(new Produtividade
                    {
                        Funcionario = "Evolucao",
                        Periodo = d.ToString("yyyy-MM-dd hh:mm:ss"),
                        PeriodoFormatado = d.ToString("dd/MMM"),
                        id_usuario = "Evolucao",
                        qtdRecs = 0
                    });
                }
            }



            this.chrEvolDiaria.DataSource = dtEvolucaoDiaria.OrderBy(f => f.Periodo).ToList();
            chrEvolDiaria.SeriesDataMember = "Funcionario";
            chrEvolDiaria.SeriesTemplate.ArgumentDataMember = "PeriodoFormatado";
            chrEvolDiaria.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "qtdRecs" });
            chrEvolDiaria.DataBind();
            foreach (DevExpress.XtraCharts.Series serie in chrEvolDiaria.Series)
            {
                serie.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                serie.Label.LineVisible = true;
                serie.LegendPointOptions.PointView = DevExpress.XtraCharts.PointView.Values;

            }






            //Painel BSC
            List<ItemRanking> objRanking = ItemRanking.GeraRanking(cboDtInicio.Date, cboDtFim.Date);
            rptBscItens.DataSource = objRanking;
            rptBscItens.DataBind();

            this.pnlMain.Visible = true;



        }

       

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
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


            var dsExport = Produtividade.GetExport(this.cboDtInicio.Date, this.cboDtFim.Date).ToList();
            this.dGridExport.DataSource = dsExport;

            this.dGridExport.DataBind();
            this.dGridExportExporter.FileName = string.Format("ExportProdutividade_{0:yyyy_MM_dd}_{1:yyyy_MM_dd}.xlsx", this.cboDtInicio.Date, this.cboDtFim.Date);
           
            this.dGridExportExporter.WriteXlsxToResponse(true);
        }



    }
}
