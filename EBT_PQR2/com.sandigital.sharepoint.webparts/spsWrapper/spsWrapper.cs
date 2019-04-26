using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;
using System.Net.Mail;
using System.IO;

namespace com.sandigital.sharepoint.spsWrapper
{

    public class spsWrapper
    {
        public string Erro { get; set; }
        SPWeb objWeb;

        public spsWrapper()
        {

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                objWeb = new SPSite(SPContext.Current.Site.ID).AllWebs[SPContext.Current.Web.ID];
            });

        }

        public spsWrapper(string Site)
        {
            objWeb = new SPSite(Site).RootWeb;
        }

        public spsWrapper(Guid guidSite)
        {
            objWeb = new SPSite(guidSite).RootWeb;

        }

        public SPListItemCollection RetornaLista(string NomeLista, string NomeView)
        {
            try
            {
                if (string.IsNullOrEmpty(NomeView))
                {
                    return RetornaLista(NomeLista);
                }
                else
                {
                    SPList Lista = objWeb.GetList(NomeLista);
                    SPView View = Lista.Views[NomeView];
                    SPListItemCollection resultado = Lista.GetItems(View);
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                Erro = ex.Message;
                return null;
            }
        }

        public SPListItemCollection RetornaLista(String NomeLista)
        {

            try
            {
                SPList Lista = objWeb.GetList(NomeLista);
                SPListItemCollection resultado = Lista.Items;
                return resultado;
            }
            catch (Exception ex)
            {
                Erro = ex.Message;
                return null;
            }

        }

        public SPListItemCollection RetornaLista(string NomeLista, string NomeView, string NomeSite)
        {

            try
            {

                if (string.IsNullOrEmpty(NomeView))
                {
                    return objWeb.Webs[NomeSite].Lists[NomeLista].Items;
                }
                else
                {
                    return (objWeb.Webs[NomeSite].Lists[NomeLista].GetItems(objWeb.Webs[NomeSite].Lists[NomeLista].Views[NomeView]));
                }


            }
            catch (Exception ex)
            {
                Erro = ex.Message;
                return null;

            }


        }

        public SPListItemCollection RetornaLista(string NomeLista, string Query, string ViewFields, string Projected, Guid Site)
        {

            try
            {
                SPQuery objQuery = new SPQuery();
                objQuery.Query = Query;
                objQuery.ProjectedFields = Projected;
                objQuery.ViewFields = ViewFields;
                objQuery.ExpandRecurrence = true;

                return SPContext.Current.Site.AllWebs[Site].Lists[NomeLista].GetItems(objQuery);
            }
            catch (Exception ex)
            {
                this.Erro = ex.Message;
                return null;
            }


        }

        public SPListItemCollection RetornaPastas(string NomeLista)
        {
            try
            {
                SPList Lista = objWeb.GetList(NomeLista);
                return Lista.Folders;
            }
            catch
            {
                return null;
            }


        }



        public SPListItemCollection RetornaLista(string NomeLista, string[] Campos, Guid GuidSite)
        {

            object objSaida = new object();

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                SPWeb web = new SPSite(SPContext.Current.Site.ID).AllWebs[GuidSite];
                string strViewFields = "";
                foreach (string campo in Campos)
                {
                    strViewFields += "<FieldRef Name=\"" + campo + "\" />";
                }

                SPQuery q = new SPQuery();
                q.ViewFields = strViewFields;
                q.IncludeAttachmentUrls = true;
                q.IncludeMandatoryColumns = true;

                SPList lista = web.Lists[NomeLista];
                objSaida = lista.GetItems(q);
            });


            return (objSaida as SPListItemCollection);


        }


        public SPListItemCollection RetornaLista(string NomeLista, Guid GuidSite)
        {
            try
            {
                object objSaida = new object();

                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    objSaida = new SPSite(SPContext.Current.Site.ID).AllWebs[GuidSite].Lists[NomeLista].Items;
                });

                return objSaida as SPListItemCollection;


            }
            catch (Exception ex)
            {
                Erro = ex.Message;
                return null;
            }
        }

        public bool PertenceAoGrupo(string strNomeGrupo)
        {

            SPUser currentUser = SPContext.Current.Web.CurrentUser;


            foreach (SPGroup g in currentUser.Groups)
            {
                if (g.Name.Equals(strNomeGrupo)) return true;
            }

            return false;

        }

        public bool AtualizaItemLocal(string strLista, Guid ID, string strCampo, object Valor)
        {

            try
            {
                SPWeb web = SPContext.Current.Web;
                web.AllowUnsafeUpdates = true;
                SPList item = web.Lists[strLista];
                SPListItem valor = item.Items[ID];
                valor[strCampo] = Valor;
                valor.Update();
                return true;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                this.Erro = exception.Message;
                return false;
            }

        }

        public bool AtualizaItemLocal(string strLista, int ID, string strCampo, object objvalor)
        {

            objWeb.AllowUnsafeUpdates = true;
            SPList item = objWeb.Lists[strLista];
            SPListItem valor = item.GetItemById(ID);
            valor[strCampo] = objvalor;
            valor.Update();
            return true;

        }

        public SPListItemCollection RetornaListaLocal(string NomeLista)
        {
            SPWeb web = SPContext.Current.Web;
            SPList item = web.Lists[NomeLista];
            SPListItemCollection items = item.Items;
            SPListItemCollection sPListItemCollection = items;
            return sPListItemCollection;
        }

        public string RetornaUrlListaLocal(string NomeLista)
        {

            SPWeb web = SPContext.Current.Web;
            SPList item = web.Lists[NomeLista];
            if (item != null)
                return item.DefaultViewUrl;


            return string.Empty;

        }

        public SPListItemCollection RetornaListaFiltrada(string NomeLista, string strQuery)
        {
            SPWeb web = SPContext.Current.Web;
            SPQuery q = new SPQuery();
            q.Query = strQuery;
            SPList lista = web.Lists[NomeLista];
            return lista.GetItems(q);



        }

        public bool ListaExiste(string NomeLista)
        {
            bool flag;
            try
            {
                SPList list = objWeb.GetList(NomeLista);
                flag = list != null;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public SPListItem AdicionaItemLista(string NomeLista, Dictionary<string, object> Valores)
        {

            Object objSaida = new object();


            SPSecurity.RunWithElevatedPrivileges(delegate
            {
               SPWeb  objSite = (new SPSite(SPContext.Current.Site.ID).AllWebs[SPContext.Current.Web.ID]);

               SPListItemCollection objLista = objSite.Lists[NomeLista].Items;

               //monta o Item da lista 
               SPListItem objItem = objLista.Add();

               //para item no dicionario 
               foreach (var i in Valores)
               {
                   objItem[i.Key] = i.Value;

               }

               objItem.Web.AllowUnsafeUpdates = true;

               objItem.Update();

               objSaida = objItem;
            });

            
            return objSaida as SPListItem;

        }

        public bool DeletaItens(SPListItemCollection Itens)
        {

            foreach (SPListItem i in Itens)
            {
                Itens.DeleteItemById(i.ID);

            }

            Itens.List.Update();


            return true;


        }

        public bool DeletaItem(string NomeLista, int id)
        {
            try
            {


                //SPListItem objItem = SPContext.Current.Web.Lists[NomeLista].GetItemById(id);

                SPListItem objItem = objWeb.Lists[NomeLista].GetItemById(id);

                objItem.Web.AllowUnsafeUpdates = true;
                objItem.Delete();
                objItem.Update();

                return true;
            }
            catch (Exception ex)
            {
                Erro = ex.Message;
                return false;

            }


        }


        public bool AdicionaAnexo(string NomeLista, int id_ListItem, string NomeArquivo, byte[] Arquivo, Guid Site)
        {
            try
            {
                //Site
                SPWeb objSite = SPContext.Current.Site.AllWebs[Site];
                if (objSite == null) throw new Exception("Site não encontrdo!");

                objSite.AllowUnsafeUpdates = true;

                //Lista
                SPList Lista = objSite.Lists[NomeLista];
                if (Lista == null) throw new Exception("Lista não encontrdo!");

                //Item 
                SPListItem item = Lista.Items.GetItemById(id_ListItem);
                if (item == null) throw new Exception("Item não encontrdo!");

                //Adiciona o anexo 
                item.Attachments.AddNow(NomeArquivo, Arquivo);

                return true;
            }
            catch (Exception ex)
            {
                this.Erro = ex.Message;
                return false;
            }


        }

        public bool LimpaAnexos(string NomeLista, int id_ListItem, Guid Site)
        {
            try
            {
                //Site
                SPWeb objSite = SPContext.Current.Site.AllWebs[Site];
                if (objSite == null) throw new Exception("Site não encontrdo!");

                objSite.AllowUnsafeUpdates = true;

                //Lista
                SPList Lista = objSite.Lists[NomeLista];
                if (Lista == null) throw new Exception("Lista não encontrdo!");

                //Item 
                SPListItem item = Lista.Items.GetItemById(id_ListItem);
                if (item == null) throw new Exception("Item não encontrdo!");

                //Para cada attachament deleta 
                while (item.Attachments.Count > 0)
                {
                    item.Attachments.DeleteNow(item.Attachments[0]);
                }






                return true;
            }
            catch (Exception ex)
            {
                this.Erro = ex.Message;
                return false;
            }


        }



        public SPListItem RetornaItem(string NomeLista, int id_ListItem, Guid Site)
        {
            try
            {
                return SPContext.Current.Site.AllWebs[Site].Lists[NomeLista].GetItemById(id_ListItem);
            }
            catch (Exception ex)
            {
                this.Erro = ex.Message;
                return null;
            }

        }





    }//fim da classe

    public static class Utilidades
    {

        private static object _lock = new object();

        public static string NomeUsuario(string strIdUsuario)
        {

            if (strIdUsuario.ToLower().Contains("_svc_sql") || strIdUsuario.ToLower().Contains("administrator") ||
                strIdUsuario.ToLower().Contains("administrador")) return "Conta de Sistema";

            if (strIdUsuario.Contains("#")) return strIdUsuario.Split("#".ToCharArray())[1];

            if (strIdUsuario.Contains(" ")) return strIdUsuario;

            string strSaida = string.Empty;
            SPSecurity.RunWithElevatedPrivileges(delegate
         {
             Dictionary<string, string> objCache;
             lock (_lock)
             {
                 if (SPContext.Current.Site.Cache["UserNames"] == null)
                 {
                     SPContext.Current.Site.Cache["UserNames"] = new Dictionary<string, string>();
                     objCache = new Dictionary<string, string>();
                 }
                 else
                 {
                     objCache = SPContext.Current.Site.Cache["UserNames"] as Dictionary<string, string>;
                 }
             }




             //Caso  exista o cache ele tenta procurar no cache.
             if (objCache.Count > 0 && objCache.ContainsKey(strIdUsuario))
             {
                 strSaida = objCache.Where(f => f.Key == strIdUsuario).First().Value;
                 return;
             }


             try
             {
                 SPUser usr = SPContext.Current.Web.EnsureUser(strIdUsuario);
                 if (usr != null)
                 {
                     strSaida= usr.Name;
                     //Atualiza o Cache 
                     lock (_lock) (SPContext.Current.Site.Cache["UserNames"] as Dictionary<string, string>).Add(strIdUsuario, usr.Name);
                 
                 }
                 
             }
             catch 
             {
                 
             }



         });




            return strSaida;

        }

        public static string MontaLinksAnexo(SPAttachmentCollection anexos)
        {
          

            if (anexos == null)
            {
                return string.Empty;
            }
            else
            {
                StringBuilder strSaida = new StringBuilder();

                strSaida.Append("<table class='tb_anexos'>");

                foreach (var anexo in anexos)
                {

                    var docicon = SPUtility.MapToIcon(SPContext.Current.Web, anexo.ToString(), "");


                    strSaida.Append("<tr class='tb_anexos_tr'>");
                    strSaida.AppendFormat("<td class='tb_anexos_icon'><img border=0 src='/_layouts/images/{2}'></td><td class='tb_anexos_link'><a href=\"{0}{1}\">{1}</a></td>", anexos.UrlPrefix, anexo, docicon );
                    strSaida.Append("</tr>");
                }

                strSaida.Append("</table>");

                return strSaida.ToString();


            }




        }

        private static object getDocIcon(object anexo)
        {
            throw new NotImplementedException();
        }

        public static bool Administrador()
        {
         
            bool ret = false;

            //Cria o contexto com privilégios elevados
            SPSecurity.RunWithElevatedPrivileges(delegate
          {
              SPSite  Site = new SPSite(SPContext.Current.Site.ID);
              SPWeb  objWeb = Site.AllWebs[SPContext.Current.Web.ID];
              ret=
             objWeb.DoesUserHavePermissions( SPContext.Current.Web.CurrentUser.LoginName,    SPBasePermissions.ManageWeb);
          });


            return ret;

            //SPContext.Current.Web.CurrentUser.Roles.
            //
            //return true;
        }



        public static string FormataDataSPSISO(DateTime dt)
        {
            return SPUtility.CreateISO8601DateTimeFromSystemDateTime(dt);
        }

        public static string NomeSite()
        {
            return SPContext.Current.Web.Title;

        }

        public static string UrlBase()
        {
            return SPContext.Current.Web.Url;
        }


        public static void EnviaEmail(string strPara, string strAssunto, string strCorpo, Dictionary<string, byte[]> Anexos)
        {

              //Cria o contexto com privilégios elevados
            SPSecurity.RunWithElevatedPrivileges(delegate
          {



              //Envia o e-mail 
              string strSMTP = SPAdministrationWebApplication.Local.OutboundMailServiceInstance.Server.Address;
              string strDE = SPAdministrationWebApplication.Local.OutboundMailSenderAddress;


              MailMessage objMensagem = new MailMessage(strDE, strPara);
              objMensagem.IsBodyHtml = true;
              objMensagem.Subject = strAssunto;
              objMensagem.Body = strCorpo;


              foreach (var anexo in Anexos)
              {
                  objMensagem.Attachments.Add(new Attachment(new MemoryStream(anexo.Value), anexo.Key));
              }

              SmtpClient objSmtp = new SmtpClient(strSMTP);
              objSmtp.Send(objMensagem);

          });





        }



    }



}