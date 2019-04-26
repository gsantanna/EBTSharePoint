using com.sandigital.sharepoint.webparts.Modelos;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Linq;

namespace com.sandigital.sharepoint.webparts.ControlTemplates.com.sandigital.sharepoint.webparts
{
    public partial class ctlGridProdutividade : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {


            this.lblAviso.Text = string.Empty;
            //verifica as datas 
            if (this.cboDtInicio.Value == null)
            {
                this.lblAviso.Text = "Favor selecionar as datas";
                return;
            }

            var prodBase = Produtividade.GetHoraria(this.cboDtInicio.Date);

            var prod =  (from p in prodBase
             group p by new
             {
                 Usuario = p.id_usuario
 
             } into pp
             select new 
             {
                 Usuario = pp.Key.Usuario,
                 QtdRecs = prodBase.Where(f=> f.id_usuario== pp.Key.Usuario).Sum(g=>g.qtdRecs),
                 Prod = (prodBase.Where(f => f.id_usuario == pp.Key.Usuario).Sum(g=> g.qtdRecs) / 8.00).ToString("0.##"), 
                 QtdHoras =8 , 
                 C1 = pp.Where(f=>  f.Periodo=="1").Sum(g=>g.qtdRecs) ,
                 C2 = pp.Where(f => f.Periodo == "2").Sum(g => g.qtdRecs),
                 C3 = pp.Where(f => f.Periodo == "3").Sum(g => g.qtdRecs),
                 C4 = pp.Where(f => f.Periodo == "4").Sum(g => g.qtdRecs),
                 C5 = pp.Where(f => f.Periodo == "5").Sum(g => g.qtdRecs),
                 C6 = pp.Where(f => f.Periodo == "6").Sum(g => g.qtdRecs),
                 C7 = pp.Where(f => f.Periodo == "7").Sum(g => g.qtdRecs),
                 C8 = pp.Where(f => f.Periodo == "8").Sum(g => g.qtdRecs),
                 C9 = pp.Where(f => f.Periodo == "9").Sum(g => g.qtdRecs),
                 C10 = pp.Where(f => f.Periodo == "10").Sum(g => g.qtdRecs),
                 C11 = pp.Where(f => f.Periodo == "11").Sum(g => g.qtdRecs),
                 C12 = pp.Where(f => f.Periodo == "12").Sum(g => g.qtdRecs),
                 C13 = pp.Where(f => f.Periodo == "13").Sum(g => g.qtdRecs),
                 C14 = pp.Where(f => f.Periodo == "14").Sum(g => g.qtdRecs),
                 C15 = pp.Where(f => f.Periodo == "15").Sum(g => g.qtdRecs),
                 C16 = pp.Where(f => f.Periodo == "16").Sum(g => g.qtdRecs),
                 C17 = pp.Where(f => f.Periodo == "17").Sum(g => g.qtdRecs),
                 C18 = pp.Where(f => f.Periodo == "18").Sum(g => g.qtdRecs),
                 C19 = pp.Where(f => f.Periodo == "19").Sum(g => g.qtdRecs),
                 C20 = pp.Where(f => f.Periodo == "20").Sum(g => g.qtdRecs),
                 C21 = pp.Where(f => f.Periodo == "21").Sum(g => g.qtdRecs),
                 C22 = pp.Where(f => f.Periodo == "22").Sum(g => g.qtdRecs),
                 C23 = pp.Where(f => f.Periodo == "23").Sum(g => g.qtdRecs),
                 C24 = pp.Where(f => f.Periodo == "0").Sum(g => g.qtdRecs) 

             }).ToList();

            //Adiciona o Total 
            prod.Add(new
            {
                Usuario = "Total",
                QtdRecs = prodBase.Sum(f=>f.qtdRecs),
                Prod = (prodBase.Sum(f=>f.qtdRecs) / (prod.Count *8.00)).ToString("0.##"),
                QtdHoras =  prod.Count *8 ,
                C1 = prodBase.Where(f => f.Periodo == "1").Sum(g=> g.qtdRecs),
                C2 = prodBase.Where(f => f.Periodo == "2").Sum(g=> g.qtdRecs),
                C3 = prodBase.Where(f => f.Periodo == "3").Sum(g=> g.qtdRecs),
                C4 = prodBase.Where(f => f.Periodo == "4").Sum(g=> g.qtdRecs),
                C5 = prodBase.Where(f => f.Periodo == "5").Sum(g=> g.qtdRecs),
                C6 = prodBase.Where(f => f.Periodo == "6").Sum(g=> g.qtdRecs),
                C7 = prodBase.Where(f => f.Periodo == "7").Sum(g=> g.qtdRecs),
                C8 = prodBase.Where(f => f.Periodo == "8").Sum(g=> g.qtdRecs),
                C9 = prodBase.Where(f => f.Periodo == "9").Sum(g=> g.qtdRecs),
                C10 = prodBase.Where(f => f.Periodo == "10").Sum(g=> g.qtdRecs),
                C11 = prodBase.Where(f => f.Periodo == "11").Sum(g=> g.qtdRecs),
                C12 = prodBase.Where(f => f.Periodo == "12").Sum(g=> g.qtdRecs),
                C13 = prodBase.Where(f => f.Periodo == "13").Sum(g=> g.qtdRecs),
                C14 = prodBase.Where(f => f.Periodo == "14").Sum(g=> g.qtdRecs),
                C15 = prodBase.Where(f => f.Periodo == "15").Sum(g=> g.qtdRecs),
                C16 = prodBase.Where(f => f.Periodo == "16").Sum(g=> g.qtdRecs),
                C17 = prodBase.Where(f => f.Periodo == "17").Sum(g=> g.qtdRecs),
                C18 = prodBase.Where(f => f.Periodo == "18").Sum(g=> g.qtdRecs),
                C19 = prodBase.Where(f => f.Periodo == "19").Sum(g=> g.qtdRecs),
                C20 = prodBase.Where(f => f.Periodo == "20").Sum(g=> g.qtdRecs),
                C21 = prodBase.Where(f => f.Periodo == "21").Sum(g=> g.qtdRecs),
                C22 = prodBase.Where(f => f.Periodo == "22").Sum(g=> g.qtdRecs),
                C23 = prodBase.Where(f => f.Periodo == "23").Sum(g=> g.qtdRecs),
                C24 = prodBase.Where(f => f.Periodo == "0").Sum(g=> g.qtdRecs)
            });






            this.dGridMain.DataSource = prod;
            this.dGridMain.DataBind();

                           
          




        }
    }
}
