using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sandigital.sharepoint.webparts.Modelos
{

    public class ItemRanking
    {
        public DateTime Dt_Inicio { get; set; }
        public string Foto { get; set; }
        public DateTime Dt_Fim { get; set; }
        public int Rank { get; set; }
        public string Funcionario { get; set; }
        public string id_usuario { get; set; }
        public List<Produtividade> Registros { get; set; }

        public decimal Prod
        {
            get
            {
                if (qtdHoras == 0) return 0;

                return (Convert.ToDecimal(qtdRecs) / Convert.ToDecimal(qtdHoras));
            }
        }

        public int qtdMeses
        {
            get
            {
                var tmpI = Dt_Inicio;
                var lsSaida = new List<string>();
                while (Dt_Fim > tmpI)
                {
                    lsSaida.Add(tmpI.ToString("MM/yy"));
                    tmpI = tmpI.AddDays(1);
                }

                return lsSaida.Distinct().Count();
            }
        }

        public int qtdHoras
        {
            get
            { 
                return Convert.ToInt32(Dt_Fim.Date.Subtract(Dt_Inicio.Date).TotalDays+1) * 8;
            }
        }

        public int qtdRecs
        {
            get
            {
                return Convert.ToInt32(Registros.Sum(f => f.qtdRecs));
            }
        }

        public static List<ItemRanking> GeraRanking(DateTime Dt_Inicio, DateTime Dt_Fim)
        {
            //<a title='Clique aqui para modificar sua foto!' href='/my/default.aspx'><img id="PeoplePlaceholder" src="/images/loading.gif"  style="width:30px;height:30px;" /></a>	

            //var strUrl= '/my/User%20Photos/Imagens%20de%20Perfil/EMBRATEL_'+ usuario +'_MThumb.jpg'
	

            List<ItemRanking> objSaida = new List<ItemRanking>();
            List<Produtividade> objProdutividade = Produtividade.GetDiaria(Dt_Inicio, Dt_Fim);
           
         

            foreach (var usuario in (from u in objProdutividade
                                     select new { u.id_usuario, u.Funcionario }).Distinct())
            {
                var strLogin = usuario.id_usuario.Replace(@"EMBRATEL\", "").Replace(@"SHAREPOINT\", "").Replace(@"embratel\","").Replace(@"sharepoint\","");

                if (strLogin == "system") strLogin = "_svc_sql";


                var strUrlFoto = SPContext.Current.Site.Url + "/my/User%20Photos/Imagens%20de%20Perfil/EMBRATEL_" +  strLogin + "_MThumb.jpg";

                if (!(com.sandigital.sharepoint.Utilidades.ArquivoExiste(strUrlFoto)))
                {
                    strUrlFoto = "/images/PeoplePlaceholder.jpg";
                }


                objSaida.Add(new ItemRanking
                {
                    Dt_Inicio = Dt_Inicio,
                    Dt_Fim = Dt_Fim,
                    Foto =  strUrlFoto ,
                    Funcionario = usuario.Funcionario,
                    id_usuario = usuario.id_usuario,
                    Registros = objProdutividade.Where(f => f.id_usuario == usuario.id_usuario).ToList()
                });
            }

            //carrega info complementares  
            objSaida = objSaida.OrderByDescending(f => f.Prod).ToList();
            for (int i = 0; i < objSaida.Count; i++)
            {
                objSaida[i].Rank = i + 1;
            }

            return objSaida;

        }

    }


}
