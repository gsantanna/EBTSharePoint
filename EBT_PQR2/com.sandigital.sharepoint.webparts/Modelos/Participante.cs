using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sandigital.sharepoint.webparts.Modelos
{
    public class Participante
    {
        public int ID_Reuniao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }



        public static List<Participante> Participantes( int id_reuniao)
        {
            spsWrapper2 objWrapper = new spsWrapper2();


            return
                (from SPListItem item in
                     objWrapper.RetornaLista("ParticipantesReuniao",new string[] {"id_usuario"}, SPContext.Current.Web.ID)
                 where item.Title == id_reuniao.ToString()
                 select new Participante
                 {
                     Nome = SPContext.Current.Web.EnsureUser(Convert.ToString(item["id_usuario"])).Name,
                     ID_Reuniao = id_reuniao,
                     Email = SPContext.Current.Web.EnsureUser(Convert.ToString(item["id_usuario"])).Email
                 }).ToList();



        }






    }

}
