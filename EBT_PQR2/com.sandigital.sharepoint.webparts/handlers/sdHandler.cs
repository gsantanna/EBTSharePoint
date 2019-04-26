using com.sandigital.sharepoint.webparts.Modelos;
using Microsoft.SharePoint;
using System;
using System.Data;
using System.Text;
using System.Web;

namespace com.sandigital.sharepoint.webparts
{
    public class sdHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {   
            if (string.IsNullOrEmpty(context.Request.QueryString["op"]))
            {
                context.Response.Write("Operacao Ausente");
                context.Response.End();
                return;
            }

            string strOp = context.Request.QueryString["op"].ToUpper();


            switch (strOp)
            {
                case "LIMPACACHEPAUTA" :
                    LimpaCachePautas(context);
                    break;
                case "GETPAUTASFOREXPORT" :
                    getPautasForExport();
                    break;
                default:
                    context.Response.Write("Operacao Inexistente");
                    break;
            }


         

        }

        





        #endregion






        #region Métodos


       

        public void LimpaCachePautas(HttpContext context)
        {
            string strSaida = "{'Resposta': {" +
                            "  'Codigo': '{0}', " +
                            "  'Descricao': '{1}' " +
                            "}} ";


            try
            {
                SPContext.Current.Site.Cache["Pautas"] = Pauta.Pautas();
                context.Response.Write(strSaida.Replace("{0}", "0").Replace("{1}", "Sucesso"));
                
            }
            catch (Exception ex)
            {
                context.Response.Write(strSaida.Replace("{0}", "-1").Replace("{1}",  ex.Message));
                
            }


        }

        public void getPautasForExport()
        {

          
        }










        #endregion












    }
}
