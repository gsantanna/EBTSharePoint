using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace com.sandigital.sharepoint.spsWrapper
{

    public class spsWrapper
    {
        public string Erro { get; set; }
        SPWeb objWeb;
        public spsWrapper()
        {
           objWeb = SPContext.Current.Site.RootWeb;
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
                   return  objWeb.Webs[NomeSite].Lists[NomeLista].Items;
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


        public SPListItemCollection RetornaLista(string NomeLista, Guid GuidSite)
        {
            try
            {
                return SPContext.Current.Site.AllWebs[GuidSite].Lists[NomeLista].Items;

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
            SPWeb web = SPContext.Current.Web;
            web.AllowUnsafeUpdates = true;
            SPList item = web.Lists[strLista];
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
                SPList list =  objWeb.GetList(NomeLista);
                flag = list != null;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public SPListItem AdicionaItemLista(string NomeLista,  Dictionary<string,object> Valores)
        {

            SPWeb objSite = SPContext.Current.Web;

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

            return objItem;


            

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
                
                SPListItem objItem = SPContext.Current.Web.Lists[NomeLista].GetItemById(id);
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








    }//fim da classe

    //utilizades
    public static class Utilidades
    {
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

        public static string NomeUsuario(string strIdUsuario)
        {
            try
            {
             
                SPUser usr =  SPContext.Current.Web.EnsureUser(strIdUsuario);

                if (usr.ID == SPContext.Current.Web.Site.SystemAccount.ID)   //web.Site.SystemAccount.ID)
                {
                    return "Conta de Sistema";
                }
                else
                {
                    return usr.Name;
                }



            }
            catch 
            {
                return strIdUsuario;
            }


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

                foreach (var anexo in anexos)
                {
                    strSaida.AppendFormat("<a href=\"{0}{1}\">{1}</a><br/>", anexos.UrlPrefix, anexo);

                }

                return strSaida.ToString();


            }

            


        }




        

        public static bool Administrador()
        {
            try
            {
                SPUser currentUser = SPContext.Current.Web.CurrentUser;
                return currentUser.IsSiteAdmin;
            }
            catch
            {
                return false;
            }


        }

        public static bool Administrador(string strSite)
        {
            try
            {
                SPWeb site = SPContext.Current.Site.AllWebs[strSite];
                return site.CurrentUser.IsSiteAdmin;
            }
            catch
            {   
                return false;
            }
        }




    }



}
