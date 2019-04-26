using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Data;

namespace com.sandigital.sharepoint.webparts.Modelos
{

    [Serializable]
    public class Pauta
    {

        public Pauta()
        {
            this.Tarefas = new List<Tarefa>();

        }

        #region Propriedades 
        public Int32 ID { get; set; }
        public string Titulo { get; set; }
        public string Observacoes { get; set; }
        public string Responsavel { get; set; }
        public DateTime? DataReuniao { get; set; }
        public string Anexos { get; set; }
        public List<Tarefa> Tarefas { get; set; }


        public DateTime? Modificado { get; set; }
        public DateTime? Criado { get; set; }



        public DateTime dt_modificado
        {
            get
            {
                DateTime?[] Datas;

                if (this.Tarefas.Count > 0)
                {
                    DateTime dtTarefas = this.Tarefas.Max(f => f.dt_modificado);
                    Datas = new DateTime?[] { dtTarefas, Modificado, Criado };


                }
                else
                    Datas = new DateTime?[] { Modificado, Criado };


                return (Datas.Max().Value);



            }
        }
         
        public string Status
        {
            get
            {
                if (this.Tarefas != null && this.Tarefas.Count > 0)
                {
                    return (this.Tarefas.Where(f => f.Status != "Concluído").Count() > 0) ? "Em Andamento" : "Concluído";
                }
                else
                {
                    return "Em Andamento";
                }
            }
        }

        #endregion


        #region Metodos
       
        public static List<Pauta> Pautas()
        {

            
            //Cria o wrapper
            spsWrapper2 objWrapper = new spsWrapper2();

           // List<SPListItem> objTmpTarefa;
           // List<SPListItem> objTmpItemTarefa;

            DateTime tp = DateTime.Now;



            List<ItemTarefa> objTmpItemTarefa = (from SPListItem i in objWrapper.RetornaLista("Detalhe Tarefa", new string[] { "Author", "Modified", "Created", "Status", "DataReuniao", "Responsavel", "Tarefa", "Detalhes", "Prazo" },
                                                     SPContext.Current.Site.AllWebs["ComunidadePreventivasVoc"].ID)
                                                 select new ItemTarefa
                                                 {
                                                     Titulo = i.Title,
                                                     Autor = spsWrapper.Utilidades.NomeUsuario(((string)i["Author"]).Split('#')[1]),
                                                     Criado = Convert.ToDateTime(i["Created"]),
                                                     Modificado = Convert.ToDateTime(i["Modified"]),
                                                     Status = Convert.ToString(i["Status"]),
                                                     Detalhes = Convert.ToString(i["Detalhes"]),
                                                     ID = i.ID,
                                                     dt_reuniao = Convert.ToDateTime(i["DataReuniao"]),
                                                     LoginResponsavel = Convert.ToString(i["Responsavel"]) ,
                                                     Prazo = Convert.ToDateTime(i["Prazo"]),
                                                     Responsavel = spsWrapper.Utilidades.NomeUsuario(Convert.ToString(i["Responsavel"])),
                                                     ID_TAREFA = Convert.ToInt32(i["Tarefa"].ToString().Split(";#".ToCharArray())[0])
                                                 }).ToList();



            List<Tarefa> objTmpTarefa = (from SPListItem i in objWrapper.RetornaLista("Tarefas Da Pauta", new string[] { "Attachments", "Title", "Atribuidaa", "Data_x0020_de_x0020_Conclus_x00e", "Data_x0020_Prevista", "Data_x0020_Reuni_x00e3_o", "Detalhes", "Modified", "Created", "Pauta" }, SPContext.Current.Site.AllWebs["ComunidadePreventivasVoc"].ID)
                                         select new Tarefa
                                         {
                                             Titulo = i.Title,
                                             Anexos = spsWrapper.Utilidades.MontaLinksAnexo(i.Attachments),
                                             Atribuidaa =  spsWrapper.Utilidades.NomeUsuario( Convert.ToString(i["Atribuidaa"])),
                                             DataConclusao = Convert.ToDateTime(i["Data_x0020_de_x0020_Conclus_x00e"]),
                                             DataPrevista = Convert.ToDateTime(i["Data_x0020_Prevista"]),
                                             DataReuniao = Convert.ToDateTime(i["Data_x0020_Reuni_x00e3_o"]),
                                             Descricao = Convert.ToString(i["Detalhes"]),
                                             Modificado = Convert.ToDateTime(i["Modified"]),
                                             Criado = Convert.ToDateTime(i["Created"]),
                                             ID = i.ID,
                                             ID_Pauta = string.IsNullOrEmpty(Convert.ToString(i["Pauta"])) ? 0 :
                                             Convert.ToInt32(i["Pauta"].ToString().Split(";#".ToCharArray())[0]),
                                             Itens = objTmpItemTarefa.Where(f => f.ID_TAREFA == i.ID).ToList()
                                         }).ToList();


            //Cria o objeto de saída
            List<Pauta> objSaida = new List<Pauta>();

            //para cada Pauta carrega todo o conteúdo dela.
            foreach (SPListItem p in objWrapper.RetornaLista("Pautas", new string[] { "Attachments", "Title", "Created", "Modified", "Responsavel", "Observacoes", "Data_x0020_da_x0020_Reuniao" }, SPContext.Current.Site.AllWebs["ComunidadePreventivasVoc"].ID))
            {
                Pauta objPauta = new Pauta();
                objPauta.ID = p.ID;
                objPauta.DataReuniao = (DateTime?)p["Data_x0020_da_x0020_Reuniao"];
                objPauta.Observacoes = (string)p["Observacoes"];
                objPauta.Responsavel = (p["Responsavel"] == null) ? "" : spsWrapper.Utilidades.NomeUsuario(((string)p["Responsavel"]).Split('#')[1]);
                objPauta.Titulo = p.Title;
                
                objPauta.Anexos = spsWrapper.Utilidades.MontaLinksAnexo(p.Attachments);

                objPauta.Modificado = (DateTime?)p["Modified"];
                objPauta.Criado = (DateTime?)p["Created"];

                //Adiciona as tarefas
                objPauta.Tarefas = objTmpTarefa.Where(f => f.ID_Pauta == p.ID).ToList();

                objSaida.Add(objPauta);
                
            };


            double qtdTotal = DateTime.Now.Subtract(tp).TotalSeconds;

            return objSaida;

        }



        public static List<Pauta> Pautas(DateTime dt_inicio, DateTime dt_fim )
        {

            //Cria o wrapper
            spsWrapper2 objWrapper = new spsWrapper2();

            
            List<ItemTarefa> objTmpItemTarefa = (from SPListItem i in objWrapper.RetornaLista("Detalhe Tarefa", new string[] { "Author", "Modified", "Created", "Status", "DataReuniao", "Responsavel", "Tarefa", "Detalhes", "Prazo" },
                                                     SPContext.Current.Site.AllWebs["ComunidadePreventivasVoc"].ID)
                                                 select new ItemTarefa
                                                 {
                                                     Titulo = i.Title,
                                                     Autor = spsWrapper.Utilidades.NomeUsuario(((string)i["Author"]).Split('#')[1]),
                                                     Criado = Convert.ToDateTime(i["Created"]),
                                                     Modificado = Convert.ToDateTime(i["Modified"]),
                                                     Status = Convert.ToString(i["Status"]),
                                                     Detalhes = Convert.ToString(i["Detalhes"]),
                                                     ID = i.ID,
                                                     dt_reuniao = Convert.ToDateTime(i["DataReuniao"]),
                                                     LoginResponsavel = Convert.ToString(i["Responsavel"]),
                                                     Prazo = Convert.ToDateTime(i["Prazo"]),
                                                     
                                                     Responsavel = spsWrapper.Utilidades.NomeUsuario(Convert.ToString(i["Responsavel"])),
                                                     ID_TAREFA = Convert.ToInt32(i["Tarefa"].ToString().Split(";#".ToCharArray())[0])
                                                 }).Where(f =>  f.dt_modificado.Date >= dt_inicio.Date && f.dt_modificado.Date <= dt_fim.Date ).ToList();

            

            List<Tarefa> objTmpTarefa = (from SPListItem i in objWrapper.RetornaLista("Tarefas Da Pauta", new string[] { "Attachments", "Title", "Atribuidaa", "Data_x0020_de_x0020_Conclus_x00e", "Data_x0020_Prevista", "Data_x0020_Reuni_x00e3_o", "Detalhes", "Modified", "Created", "Pauta" }, SPContext.Current.Site.AllWebs["ComunidadePreventivasVoc"].ID)
                                         select new Tarefa
                                         {
                                             Titulo = i.Title,
                                             Anexos = spsWrapper.Utilidades.MontaLinksAnexo(i.Attachments),
                                             Atribuidaa = spsWrapper.Utilidades.NomeUsuario(Convert.ToString(i["Atribuidaa"])),
                                             DataConclusao = Convert.ToDateTime(i["Data_x0020_de_x0020_Conclus_x00e"]),
                                             DataPrevista = Convert.ToDateTime(i["Data_x0020_Prevista"]),
                                             DataReuniao = Convert.ToDateTime(i["Data_x0020_Reuni_x00e3_o"]),
                                             Descricao = Convert.ToString(i["Detalhes"]),
                                             Modificado = Convert.ToDateTime(i["Modified"]),
                                             Criado = Convert.ToDateTime(i["Created"]),
                                             ID = i.ID,
                                             ID_Pauta = string.IsNullOrEmpty(Convert.ToString(i["Pauta"])) ? 0 :
                                             Convert.ToInt32(i["Pauta"].ToString().Split(";#".ToCharArray())[0]),
                                             Itens = objTmpItemTarefa.Where(f => f.ID_TAREFA == i.ID).ToList()
                                         }).Where(f=> f.Itens.Count() >0).ToList();


            //Cria o objeto de saída
            List<Pauta> objSaida = new List<Pauta>();

            //para cada Pauta carrega todo o conteúdo dela.
            foreach (SPListItem p in objWrapper.RetornaLista("Pautas", new string[] { "Attachments", "Title", "Created", "Modified", "Responsavel", "Observacoes", "Data_x0020_da_x0020_Reuniao" }, SPContext.Current.Site.AllWebs["ComunidadePreventivasVoc"].ID))
            {

                if (objTmpTarefa.Where(f => f.ID_Pauta == p.ID).Count() > 0)
                {

                    Pauta objPauta = new Pauta();
                    objPauta.ID = p.ID;
                    objPauta.DataReuniao = (DateTime?)p["Data_x0020_da_x0020_Reuniao"];
                    objPauta.Observacoes = (string)p["Observacoes"];

                    //objPauta.Responsavel = (p["Responsavel"] == null) ? "" :  spsWrapper.Utilidades.NomeUsuario(((string)p["Responsavel"]).Split('#')[1]);
                    objPauta.Responsavel = (p["Responsavel"] == null) ? "" : ((string)p["Responsavel"]).Split('#')[1];
                    
                    objPauta.Titulo = p.Title;

                    objPauta.Anexos = spsWrapper.Utilidades.MontaLinksAnexo(p.Attachments);

                    objPauta.Modificado = (DateTime?)p["Modified"];
                    objPauta.Criado = (DateTime?)p["Created"];

                    //Adiciona as tarefas
                    objPauta.Tarefas = objTmpTarefa.Where(f => f.ID_Pauta == p.ID).ToList();

                    objSaida.Add(objPauta);

                }

            };


          



            return objSaida;



        }


        public static System.Data.DataTable PautasAsDataTable()
        {

            DataTable dtSaida = new DataTable();
            dtSaida.Columns.AddRange(new DataColumn[] { 
                //PAUTA
                new DataColumn("ID_PAUTA"),
                new DataColumn("RESPONSAVEL_PAUTA"),
                new DataColumn("STATUS_PAUTA"),
                new DataColumn("PAUTA"),
                new DataColumn("OBSERVACOES_PAUTA"),
                new DataColumn("DATA_REUNIAO"),
                //TAREFA
                new DataColumn("TAREFA"),
                new DataColumn("STATUS_TAREFA"),
                new DataColumn("DESCRICAO_TAREFA"),
                new DataColumn("DATA_REUNIAO_TAREFA"),
                new DataColumn("DATA_PREVISTA_TAREFA"),
                new DataColumn("DATA_CONCLUSAO_TAREFA"),
                new DataColumn("ATRIBUIDA_A_TAREFA"),
                //DETALHE TAREFA 
                new DataColumn("TITULO_DETALHE_TAREFA"),
                new DataColumn("DETALHES_DETALHE_TAREFA"),
                new DataColumn("AUTOR_DETALHE_TAREFA"), 
                new DataColumn("DATA_REUNIAO_DETALHE_TAREFA"),
                new DataColumn("PRAZO_DETALHE_TAREFA"),
                new DataColumn("RESPONSAVEL_DETALHE_TAREFA"),
                new DataColumn("STATUS_DETALHE_TAREFA")
            });

            //monta o flatfile
            List<Pauta> objPautas = Pautas(); 
            foreach (Pauta p in objPautas)
            {
                if (p.Tarefas.Count == 0) //Pauta sem tarefas 
                {
                    DataRow dtrPauta = dtSaida.NewRow();
                    dtrPauta.ItemArray = new object[] { p.ID, p.Responsavel, p.Status, p.Titulo, p.Observacoes, string.Format("{0:dd/MM/yyyy}", p.DataReuniao) };
                    dtSaida.Rows.Add(dtrPauta);
                }
                else //Processa as tarefas 
                {
                    foreach (Tarefa t in p.Tarefas)
                    {
                        if (t.Itens.Count == 0) //Tarefa sem detalhes 
                        {
                            DataRow dtrTarefa = dtSaida.NewRow();
                            dtrTarefa.ItemArray = new object[] { p.ID, p.Responsavel, p.Status, p.Titulo, p.Observacoes, string.Format("{0:dd/MM/yyyy}", p.DataReuniao) , t.Titulo, t.Status, t.Descricao,   string.Format("{0:dd/MM/yyyy}", t.DataReuniao), string.Format("{0:dd/MM/yyyy}", t.DataPrevista),  string.Format("{0:dd/MM/yyyy}", t.DataConclusao), t.Atribuidaa };
                            dtSaida.Rows.Add(dtrTarefa);
                        }
                        else //Processa os Itens Tarefa
                        {
                            foreach (ItemTarefa it in t.Itens)
                            {

                                DataRow dtrItem = dtSaida.NewRow();
                                dtrItem.ItemArray = new object[] { p.ID, p.Responsavel, p.Status, p.Titulo, p.Observacoes, string.Format("{0:dd/MM/yyyy}", p.DataReuniao) , t.Titulo, t.Status, t.Descricao,   string.Format("{0:dd/MM/yyyy}", t.DataReuniao), string.Format("{0:dd/MM/yyyy}", t.DataPrevista),  string.Format("{0:dd/MM/yyyy}", t.DataConclusao), t.Atribuidaa,
                                it.Titulo, it.Detalhes, it.Autor,   string.Format("{0:dd/MM/yyyy}", it.dt_reuniao),  string.Format("{0:dd/MM/yyyy}", it.Prazo),  it.Responsavel, it.Status
                                };
                                dtSaida.Rows.Add(dtrItem);

                            }


                        }
                    }
                }





            }



            return dtSaida;

           


        }


        



        #endregion




    } 
}
