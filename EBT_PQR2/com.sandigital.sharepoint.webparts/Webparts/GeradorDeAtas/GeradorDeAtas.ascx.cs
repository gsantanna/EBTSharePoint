using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Linq;
using System.Collections.Generic;
using com.sandigital.sharepoint.webparts.Modelos;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Xml.Serialization;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;

namespace com.sandigital.sharepoint.webparts.GeradorDeAtas
{
    [ToolboxItemAttribute(false)]
    public partial class GeradorDeAtas : WebPart
    {



        #region Propriedades

        private string _strAssuntoEmail = "Ata da reunião: @titulo. do dia: @dt_reuniao";
        private string _strCorpoEmail = "@nome, segue a ata da reunião: @titulo que ocorreu no dia: @dt_reuniao. <br/> Atenciosamente <br /> Equipe Preventivas";

        [WebBrowsable(true)]
        [WebDisplayName("Assunto")]
        [WebDescription("Texto do Assunto do e-mail")]
        [Personalizable(PersonalizationScope.User)]
        [Category("Configurações do Email Automático")]
        public string Assunto
        {
            get { return _strAssuntoEmail; }
            set { _strAssuntoEmail = value; }
        }



        [WebBrowsable(true)]
        [WebDisplayName("Corpo")]
        [WebDescription("Corpo do e-mail")]
        [Personalizable(PersonalizationScope.User)]
        [Category("Configurações do Email Automático")]
        public string Corpo
        {
            get { return _strCorpoEmail; }
            set { _strCorpoEmail = value; }
        }




        #endregion










        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public GeradorDeAtas()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregaDatasReunioes();
            }

        }


        private void CarregaDatasReunioes()
        {
            //cria o obj
            spsWrapper2 objWrapper = new spsWrapper2();

            var listaReunioes = from SPListItem item in objWrapper.RetornaLista("Reunioes", new string[] { "Title", "Hora de Início" }, SPContext.Current.Web.ID)
                                 select new
                                 {
                                     dt_evento = ((DateTime)item["Hora de Início"]).ToString("dd/MM/yyyy"),
                                     dt_evento_date = ((DateTime)item["Hora de Início"]),
                                     ID = item.ID
                                 };
                                


            this.cboDataReuniao.DataSource = listaReunioes.OrderByDescending(f=>f.dt_evento_date);
            this.cboDataReuniao.DataBind();


        }

        #region Métodos Interface


        //Gerar a ata
        protected void btnGerar_Click(object sender, EventArgs e)
        {

            if (this.cboDataReuniao.SelectedItem == null)
            {
                this.lblErro.Text = "Erro, você deve selecionar uma reunião para gerar a ATA";
                this.pnlErro.Visible = true;
                return;
            }

            int idReuniao = Convert.ToInt32(this.cboDataReuniao.SelectedItem.Value);


            //Carrega a reunião
            Reuniao objReuniao = CarregaReuniao(idReuniao);

            //Verifica se a reunião existe
            if (objReuniao == null)
            {
                lblErro.Text = "Reunião Não encontrada!";
                this.pnlErro.Visible = true;
                return;
            }

            try
            {
                //Instancia o relatório 
                reports.rptGeradorAta2 objRelatorio = new reports.rptGeradorAta2();

                 
                //Instancia o dataset 
                DataSet objDs = objRelatorio.dsAta1;
                


                //Adiciona a reunião 
                objDs.Tables["Reuniao"].Rows.Add(objReuniao.ID_Reuniao,
                    objReuniao.dt_reuniao > new DateTime(2000,1,1) ? (DateTime?)objReuniao.dt_reuniao : null,
                    //objReuniao.dt_reuniao, 
                    objReuniao.Titulo);


                //Adiciona os PArticipantes
                foreach (Participante p in objReuniao.Participantes)
                {
                    objDs.Tables["Participantes"].Rows.Add(p.ID_Reuniao, p.Nome, "mailto:" + p.Email);

                }


                //Pautas originais (status originais) 
                List<Pauta> objPautasOriginais = Pauta.Pautas();

                //Adiciona as Pautas
                foreach (Pauta pauta in objReuniao.Pautas)
                {
                    //Adiciona a pauta
                    objDs.Tables["Pauta"].Rows.Add(idReuniao, pauta.ID, pauta.Titulo, objPautasOriginais.Find(p=>p.ID== pauta.ID).Status      );


                    


                    foreach (Tarefa tarefa in pauta.Tarefas)
                    {
                        //Id-tarefa, idpauta, titulo, atribuidoa, status, data prevista
                        //Adiciona as tarefas da pauta.
                        objDs.Tables["Tarefa"].Rows.Add(tarefa.ID, 
                            tarefa.ID_Pauta, 
                            tarefa.Titulo,
                            tarefa.Atribuidaa, 
                            objPautasOriginais.Find(p => p.ID == pauta.ID).Tarefas.Find(t => t.ID == tarefa.ID).Status,
                            ((tarefa.DataPrevista.HasValue && tarefa.DataPrevista.Value > new DateTime(2000, 01, 01)) ? tarefa.DataPrevista : null),
                            tarefa.Descricao,
                            ((tarefa.DataConclusao.HasValue && tarefa.DataConclusao.Value > new DateTime(2000, 01, 01)) ? tarefa.DataConclusao : null));

                        foreach (ItemTarefa itemTarefa in tarefa.Itens)
                        {
                            objDs.Tables["ItemTarefa"].Rows.Add(
                                itemTarefa.ID,
                                itemTarefa.ID_TAREFA,
                                //itemTarefa.dt_reuniao,
                                ((itemTarefa.dt_reuniao.HasValue && itemTarefa.dt_reuniao.Value > new DateTime(2000, 01, 01)) ?  itemTarefa.dt_reuniao : null),
                                
                                objPautasOriginais.Find(p=> p.ID == pauta.ID  ).Tarefas.Find(t=>t.ID== tarefa.ID ).Itens.Find(i=> i.ID== itemTarefa.ID).Status,
                                //itemTarefa.Status,
                                itemTarefa.LoginResponsavel.Replace("EMBRATEL\\","").Replace("DESENV2010\\","") + "@",
                                itemTarefa.Detalhes, 
                                itemTarefa.Titulo, 
                                itemTarefa.Prazo.HasValue && itemTarefa.Prazo.Value > new DateTime(2000,1,1) ? itemTarefa.Prazo : null
                                //itemTarefa.Prazo
                                
                                );

                        }


                    }

                }

                //Verifica se há pauta em andamento caso não adiciona uma pauta em branco 
               // objDs.Tables["Pauta"].Rows.Add(idReuniao, pauta.ID, pauta.Titulo, objPautasOriginais.Find(p => p.ID == pauta.ID).Status);

                objDs.Tables["Pauta"].DefaultView.Sort = "Status desc";

                if (!(objDs.Tables["Pauta"].DefaultView.Find("Concluído") >= 0))
                {
                    objDs.Tables["Pauta"].Rows.Add(idReuniao , -1 , "", "Concluído");
                }

                if (!(objDs.Tables["Pauta"].DefaultView.Find("Em Andamento") >= 0))
                {
                    objDs.Tables["Pauta"].Rows.Add(idReuniao, -1, "", "Em Andamento");
                }



                //Grava o arquivo no sharepoint 

                //Limpa os arquivos anexos da reuniao

                MemoryStream msArquivo = new MemoryStream();
                objRelatorio.ExportToRtf(msArquivo);

                //monta o nome do arquivo
                string strNomeArquivo = string.Format("ATA_PREVENTIVAS_{0:dd_MM_yyyy}_.RTF", objReuniao.dt_reuniao);
                GravaAtaReuniao(objReuniao.ID_Reuniao, strNomeArquivo, msArquivo.ToArray());

                //seta os componentes
                this.btnEnviarEmail.CommandArgument = objReuniao.ID_Reuniao.ToString();

                this.btnVisualizar.NavigateUrl = string.Format("/ComunidadePreventivasVoc/Lists/Reunioes/Attachments/{0}/{1}",  objReuniao.ID_Reuniao,  strNomeArquivo );



                this.pnlErro.Visible = false;
                this.pnlResultado.Visible = true;




            }
            catch (Exception ex)
            {
                this.lblErro.Text = "Erro ao gerar a ATA o erro foi: " + ex.Message;
                this.pnlErro.Visible = true;
            }





        }




        #endregion

        #region Conexão com o Portal


        protected Reuniao CarregaReuniao(int id_reuniao)
        {
            //Cria o wrapper 
            spsWrapper2 objWrapper = new spsWrapper2();

            //carrega a REunião 
            var objSaida = (from SPListItem item in
                                objWrapper.RetornaLista("Reunioes", new string[] { "Hora de Início", "Title" }, SPContext.Current.Web.ID)
                            where item.ID == id_reuniao
                            select new Reuniao { dt_reuniao = Convert.ToDateTime(item["Hora de Início"]), ID_Reuniao = item.ID, Titulo = item.Title }
                         ).FirstOrDefault();


            //Adiciona os Participantes.

            //Participantes..
            objSaida.Participantes.AddRange(Participante.Participantes(objSaida.ID_Reuniao));

          



            DateTime dtInicioFiltro = objSaida.dt_reuniao.Date.AddDays(-7);

            ////Carrega as pautas que tiveram tarefas alteradas
            List<Pauta> objPautas = Pauta.Pautas(dtInicioFiltro, objSaida.dt_reuniao);

                
                //Pauta.Pautas().Where(f => f.dt_modificado >= dtInicioFiltro && f.dt_modificado <= objSaida.dt_reuniao).ToList();


            objSaida.Pautas.AddRange(objPautas.OrderBy(f=>f.Titulo ));
            return objSaida;





        }

        protected void GravaAtaReuniao(int id_reuniao, string NomeArquivo, Byte[] barAta)
        {

            //Cria o Wrapper
            spsWrapper2 objWrapper = new spsWrapper2();


            //Limpa os anexos 
            if (!objWrapper.LimpaAnexos("Reunioes", id_reuniao, SPContext.Current.Web.ID)) throw new Exception(objWrapper.Erro);

            //Adiciona o novo Anexo 
            if (!objWrapper.AdicionaAnexo("Reunioes", id_reuniao, NomeArquivo, barAta, SPContext.Current.Web.ID)) throw new Exception(objWrapper.Erro);



        }


        #endregion

        protected void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            try
            {
                spsWrapper2 objWrapper = new spsWrapper2();

                //Carrega a Reunião 
                Reuniao objReuniao = CarregaReuniao(Convert.ToInt32(btnEnviarEmail.CommandArgument));

                if (!(objReuniao.Participantes.Count > 0)) throw new Exception("Nenhum participante localizado!");

                //Carrega o ListItem para capturar os anxos 
                SPListItem objItem = objWrapper.RetornaItem("Reunioes", objReuniao.ID_Reuniao, SPContext.Current.Web.ID);

                //Verifica se existe o anexo para ser enviado.
                if (!(objItem.Attachments.Count > 0)) throw new Exception("ATA não gerada! você deve gerar a ATA da reunião antes de enviar!");


                //Cria o anexo 
                Dictionary<string, Byte[]> objAnexo = new Dictionary<string, byte[]>();
                
                /*
                 * SPFolder folder = web.Folders["Lists"].SubFolders[strListName].SubFolders["Attachments"].SubFolders[item.ID.ToString()]; 
		            foreach(SPFile file in folder.Files)
                 */
                foreach (SPFile arquivo in SPContext.Current.Web.Folders["Lists"].SubFolders[ objItem.ParentList.Title].SubFolders["Attachments"].SubFolders[objItem.ID.ToString()].Files)
                {
                    objAnexo.Add(arquivo.Name, arquivo.OpenBinary());
                }

                //Para cada participante da reunião com o e-mail preenchido
                foreach (Participante participante in objReuniao.Participantes.Where(f => f.Email != string.Empty))
                {

                    //Cria o corpo e o assunto montando os campos dinâmicos
                    string strAssunto = Assunto.Replace("@titulo", objReuniao.Titulo).Replace("@dt_reuniao", objReuniao.dt_reuniao.ToString("dd/MM/yyyy")).Replace("@nome", participante.Nome);
                    string strCorpo = Corpo.Replace("@titulo", objReuniao.Titulo).Replace("@dt_reuniao", objReuniao.dt_reuniao.ToString("dd/MM/yyyy")).Replace("@nome", participante.Nome);
                    
                    spsWrapper.Utilidades.EnviaEmail(participante.Email, strAssunto, strCorpo, objAnexo);


                }

                this.lblResultado.Text = "ATA enviada com sucesso!";



            }
            catch (Exception ex)
            {
                this.lblErro.Text = ex.Message;
                this.pnlErro.Visible = true;
            }

        }

    }

}

