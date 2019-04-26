using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sandigital.sharepoint.webparts.Modelos
{

    public class Produtividade
    {

        public string Funcionario { get; set; }
        public string id_usuario { get; set; }
        public int qtdRecs { get; set; }
        public string Periodo { get; set; }
        public string PeriodoFormatado { get; set; }
        public string Causa { get; set; }
        public string Tratamento { get; set; }

        #region Métodos

        public static List<Produtividade> GetEvolucaoMensal(DateTime dt_ini, DateTime dt_fim)
        {
            List<Produtividade> objSaida = (from p in GetDiaria(dt_ini, dt_fim)
                                            group p by new { Periodo = Convert.ToDateTime(p.Periodo).ToString("MMM/yy"), } into pp
                                            select new Produtividade { Funcionario = "Evolucao", Periodo = pp.Key.Periodo, id_usuario = "Evolucao", qtdRecs = pp.Sum(f => f.qtdRecs) }
                          ).ToList();

            return objSaida;

        }

        public static List<Produtividade> GetEvolucaoDiaria(DateTime dt_ini, DateTime dt_fim)
        {
            List<Produtividade> objSaida = (from p in GetDiaria(dt_ini, dt_fim)
                                            group p by new
                                            {
                                                Periodo = Convert.ToDateTime(p.Periodo)
                                            } into pp
                                            select new Produtividade
                                            {
                                                Funcionario = "Evolucao",
                                                Periodo = pp.Key.Periodo.ToString("yyyy-MM-dd hh:mm:ss"),
                                                PeriodoFormatado = pp.Key.Periodo.ToString("dd/MMM"),
                                                id_usuario = "Evolucao",
                                                qtdRecs = pp.Sum(f => f.qtdRecs)
                                            }
                          ).OrderBy(f => f.Periodo).ToList();

            return objSaida;

        }

        public static List<Produtividade> GetEvolucaoMensalPorFuncionario(DateTime dt_ini, DateTime dt_fim)
        {
            List<Produtividade> objSaida = (from p in GetDiaria(dt_ini, dt_fim)
                                            group p by new { Funcionario = p.id_usuario.Split('\\')[1], id_usuario = p.id_usuario, Periodo = Convert.ToDateTime(p.Periodo).ToString("MMM/yy"), } into pp
                                            select new Produtividade { Funcionario = pp.Key.Funcionario, Periodo = pp.Key.Periodo, id_usuario = pp.Key.id_usuario, qtdRecs = pp.Sum(f => f.qtdRecs) }
                          ).ToList();

            return objSaida;
        }

        public static List<Produtividade> GetEvolucaoMensal(DateTime dt_ini, DateTime dt_fim, string id_usuario)
        {

            // List<Produtividade> objSaida = new List<Produtividade>();

            var saida = (from p in GetDiaria(dt_ini, dt_fim, id_usuario)
                         group p by new { Funcionario = p.Funcionario, id_usuario = p.id_usuario, Periodo = Convert.ToDateTime(p.Periodo).ToString("MMM/yy"), } into pp
                         select new Produtividade { Funcionario = pp.Key.Funcionario, Periodo = pp.Key.Periodo, id_usuario = pp.Key.id_usuario, qtdRecs = pp.Sum(f => f.qtdRecs) }
                           ).ToList();

            return saida;

        }





        #endregion

        #region Conexão com Sharepoint

        //Conexão com Sharepoint. (Diária)
        public static List<Produtividade> GetDiaria(DateTime dt_ini, DateTime dt_fim)
        {
            return GetDiaria(dt_ini, dt_fim, null);

        }

        //Conexão com portal. (Diária por usuário)
        public static List<Produtividade> GetDiaria(DateTime dt_ini, DateTime dt_fim, string id_usuario)
        {

            spsWrapper2 objWrapper = new spsWrapper2();

            string strViewFields = @"<FieldRef Name='Title' /><FieldRef Name='Created' /><FieldRef Name='Usuario' />";
            string strQuery;

            if (id_usuario == null)
            {
                strQuery = string.Format("<Where><And><Geq><FieldRef Name='Created' /><Value Type='DateTime' IncludeTimeValue='FALSE'>{0:yyyy-MM-dd}</Value></Geq><Leq><FieldRef Name='Created' /><Value Type='DateTime' IncludeTimeValue='FALSE'>{1:yyyy-MM-dd}</Value></Leq></And></Where>", dt_ini, dt_fim);

            }
            else
            {
                strQuery = string.Format("<Where><And><And><Geq><FieldRef Name='Created' /><Value Type='DateTime' IncludeTimeValue='FALSE'>{0:yyyy-MM-dd}</Value></Geq><Leq><FieldRef Name='Created' /><Value Type='DateTime' IncludeTimeValue='FALSE'>{1:yyyy-MM-dd}</Value></Leq></And><Eq><FieldRef Name='Usuario' /><Value Type='Text'>{2}</Value></Eq></And></Where>", dt_ini, dt_fim, id_usuario);

            }

            var lstProd = objWrapper.RetornaLista("Produtividade", strQuery, strViewFields, SPContext.Current.Web.ID);


            //Agrupa por dia.
            var objSaida = (from p in lstProd
                            group p by new
                            {
                                Periodo = Convert.ToDateTime(p["Created"]).Date,
                                id_usuario = Convert.ToString(p["Usuario"])
                            } into pp
                            select new Produtividade
                            {
                                id_usuario = pp.Key.id_usuario,
                                Periodo = pp.Key.Periodo.ToString("yyyy-MM-dd 00:00:00"),
                                qtdRecs = pp.Count(),
                                Funcionario = spsWrapper.Utilidades.NomeUsuario(pp.Key.id_usuario)
                            }).ToList();


            //Tapa os Buracos
            List<Produtividade> prdInsert = new List<Produtividade>();


            foreach (var usuario in (from u in objSaida
                                     select new { u.id_usuario, u.Funcionario }).Distinct())
            {

                //Tapa os buracos
                for (DateTime d = dt_ini; d <  dt_fim ; d = d.AddDays(1))
                {
                    if (objSaida.Find(f => f.Periodo == d.ToString("yyyy-MM-dd 00:00:00") && f.id_usuario == usuario.id_usuario) == null)
                    {
                        prdInsert.Add(new Produtividade
                        {
                            Funcionario = usuario.Funcionario,
                            Periodo = d.ToString("yyyy-MM-dd hh:mm:ss"),
                            PeriodoFormatado = d.ToString("dd/MMM"),
                            id_usuario = usuario.id_usuario,
                            qtdRecs = 0
                        });
                    }
                }

            }





            objSaida.AddRange(prdInsert);
            return objSaida.OrderBy(f=> f.Periodo).ToList();

        }

        public static List<Produtividade> GetHoraria(DateTime dt)
        {
            spsWrapper2 objWrapper = new spsWrapper2();

            string strViewFields = @"<FieldRef Name='Title' /><FieldRef Name='Created' /><FieldRef Name='Usuario' />";
            string strQuery;

            strQuery = string.Format("<Where><And><Geq><FieldRef Name='Created' /><Value Type='DateTime' IncludeTimeValue='FALSE'>{0:yyyy-MM-dd}</Value></Geq><Leq><FieldRef Name='Created' /><Value Type='DateTime' IncludeTimeValue='FALSE'>{1:yyyy-MM-dd}</Value></Leq></And></Where>", dt, dt);


            var lstProd = objWrapper.RetornaLista("Produtividade", strQuery, strViewFields, SPContext.Current.Web.ID);


            //Agrupa a saida 
            var objSaida = (from p in lstProd
                            group p by new
                            {
                                Periodo = Convert.ToDateTime(p["Created"]).Hour.ToString(),
                                id_usuario = Convert.ToString(p["Usuario"]).Replace(@"SHAREPOINT\", "").Replace(@"EMBRATEL\", "")
                            } into pp
                            select new Produtividade
                            {
                                id_usuario = pp.Key.id_usuario,
                                Periodo = pp.Key.Periodo,
                                qtdRecs = pp.Count(),
                                Funcionario = spsWrapper.Utilidades.NomeUsuario(pp.Key.id_usuario)
                            }).ToList();

            /*
            var prodTMP = new Produtividade[] { 
                new Produtividade { id_usuario = "fulano", Periodo="0", qtdRecs=3 } ,
                new Produtividade { id_usuario = "fulano", Periodo="1", qtdRecs=1 } ,
                new Produtividade { id_usuario = "fulano", Periodo="5", qtdRecs=1 } ,
                new Produtividade { id_usuario = "fulano", Periodo="6", qtdRecs=1 } ,
                new Produtividade { id_usuario = "fulano", Periodo="17", qtdRecs=1 } ,
                new Produtividade { id_usuario = "fulano", Periodo="9", qtdRecs=3 } ,
                new Produtividade { id_usuario = "fulano", Periodo="10", qtdRecs=2 } ,
                new Produtividade { id_usuario = "fulano", Periodo="21", qtdRecs=1 } ,
                new Produtividade { id_usuario = "fulano", Periodo="23", qtdRecs=1 } ,

                new Produtividade { id_usuario = "outra", Periodo="2", qtdRecs=1 } ,
                new Produtividade { id_usuario = "outra", Periodo="3", qtdRecs=1 } ,
                new Produtividade { id_usuario = "outra", Periodo="4", qtdRecs=2 } ,
                new Produtividade { id_usuario = "outra", Periodo="5", qtdRecs=1 } ,
                new Produtividade { id_usuario = "outra", Periodo="6", qtdRecs=2 } ,
                new Produtividade { id_usuario = "outra", Periodo="17", qtdRecs=3 } ,
                new Produtividade { id_usuario = "outra", Periodo="8", qtdRecs=4 } ,
                new Produtividade { id_usuario = "outra", Periodo="22", qtdRecs=4 } ,
                new Produtividade { id_usuario = "outra", Periodo="23", qtdRecs=1 } ,
                new Produtividade { id_usuario = "Last one!! ", Periodo="17", qtdRecs=1 } 




            };



            return prodTMP.ToList();*/


            return objSaida;







        }

        public static Object[] GetExport(DateTime dt_ini, DateTime dt_fim)
        {
            spsWrapper2 objWrapper = new spsWrapper2();

            string strViewFields = @"<FieldRef Name='Title' /><FieldRef Name='Created' /><FieldRef Name='Usuario' /><FieldRef Name='Causa' /> <FieldRef Name='Tratamento'/>";
            string strQuery;

            strQuery = string.Format("<Where><And><Geq><FieldRef Name='Created' /><Value Type='DateTime' IncludeTimeValue='FALSE'>{0:yyyy-MM-dd}</Value></Geq><Leq><FieldRef Name='Created' /><Value Type='DateTime' IncludeTimeValue='FALSE'>{1:yyyy-MM-dd}</Value></Leq></And></Where>", dt_ini, dt_fim);


            var lstProd = objWrapper.RetornaLista("Produtividade", strQuery, strViewFields, SPContext.Current.Web.ID);


            //Agrupa a saida 
            var objSaida = (from p in lstProd
                            select new
                            {
                                Periodo = Convert.ToDateTime(p["Created"]).Hour.ToString(),
                                Num_rec = Convert.ToString(p.Title),
                                Login = Convert.ToString(p["Usuario"]).Replace(@"SHAREPOINT\", "").Replace(@"EMBRATEL\", ""),
                                Funcionario = spsWrapper.Utilidades.NomeUsuario(Convert.ToString(p["Usuario"]).Replace(@"SHAREPOINT\", "").Replace(@"EMBRATEL\", "")),
                                Data_Cadastro = Convert.ToDateTime(p["Created"]).ToString("dd/MM/yyyy"),
                                Hora_Cadastro = Convert.ToDateTime(p["Created"]).ToString("HH:mm"), 
                                Causa = Convert.ToString(p["Causa"]), 
                                Tratamento = Convert.ToString(p["Tratamento"])

                            }).ToArray();



            return objSaida;

        }

        public static List<Produtividade> GetCausas(DateTime dt_ini, DateTime dt_fim)
        {

            spsWrapper2 objWrapper = new spsWrapper2();

            string strQuery = string.Format("<Where><And><Neq><FieldRef Name='Causa'/><Value Type='Text'>Retorno de operadora</Value></Neq><And><IsNotNull><FieldRef Name='Causa'/></IsNotNull><And><Geq><FieldRef Name='Created' /><Value Type='DateTime' IncludeTimeValue='FALSE'>{0:yyyy-MM-dd}</Value></Geq><Leq><FieldRef Name='Created' /><Value Type='DateTime' IncludeTimeValue='FALSE'>{1:yyyy-MM-dd}</Value></Leq></And></And></And></Where>", dt_ini, dt_fim);
            string strViewFields = @"<FieldRef Name='Created' /><FieldRef Name='Causa' />";
            var lstProd = objWrapper.RetornaLista("Produtividade", strQuery, strViewFields, SPContext.Current.Web.ID);


            var objSaida = (from p in lstProd
                            group p by new
                            {
                                Periodo = Convert.ToDateTime(p["Created"]).Date,
                                Causa = Convert.ToString(p["Causa"])
                            } into pp
                            select new Produtividade
                            {
                                Causa = pp.Key.Causa,
                                Periodo = pp.Key.Periodo.ToString("yyyy-MM-dd 00:00:00"),
                                PeriodoFormatado = pp.Key.Periodo.ToString("dd/MMM"),
                                qtdRecs = pp.Count()
                            }).OrderBy(f => f.Periodo).ToList();


            return objSaida;

        }//GetCausas

        public static List<Produtividade> GetTratamentos(DateTime dt_ini, DateTime dt_fim)
        {

            spsWrapper2 objWrapper = new spsWrapper2();

            string strQuery = string.Format("<Where><And><Neq><FieldRef Name='Causa'/><Value Type='Text'>Retorno de operadora</Value></Neq><And><IsNotNull><FieldRef Name='Tratamento'/></IsNotNull><And><Geq><FieldRef Name='Created' /><Value Type='DateTime' IncludeTimeValue='FALSE'>{0:yyyy-MM-dd}</Value></Geq><Leq><FieldRef Name='Created' /><Value Type='DateTime' IncludeTimeValue='FALSE'>{1:yyyy-MM-dd}</Value></Leq></And></And></And></Where>", dt_ini, dt_fim);
            string strViewFields = @"<FieldRef Name='Created' /><FieldRef Name='Tratamento' />";
            var lstProd = objWrapper.RetornaLista("Produtividade", strQuery, strViewFields, SPContext.Current.Web.ID);


            var objSaida = (from p in lstProd
                            group p by new
                            {
                                Periodo = Convert.ToDateTime(p["Created"]).Date,
                                Tratamento = Convert.ToString(p["Tratamento"])
                            } into pp
                            select new Produtividade
                            {
                                Tratamento = pp.Key.Tratamento,
                                Periodo = pp.Key.Periodo.ToString("yyyy-MM-dd 00:00:00"),
                                PeriodoFormatado = pp.Key.Periodo.ToString("dd/MMM"),
                                qtdRecs = pp.Count()
                            }).OrderBy(f => f.Periodo).ToList();


            return objSaida;

        }//GetCausas



        #endregion


    }


}
