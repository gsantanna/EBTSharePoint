using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sandigital.sharepoint.webparts.Modelos
{   [Serializable]
    public class ItemTarefa
    {
        public int ID { get; set; }
        public int ID_TAREFA { get; set; }
        public string Titulo { get; set; }
        public string Status { get; set; }
        public DateTime? Criado { get; set; }
        public DateTime? Modificado { get; set; }
        public string Autor { get; set; }
        public DateTime? dt_reuniao { get; set; }
        public string Responsavel { get; set; }
        public string LoginResponsavel { get; set; }
        public string Detalhes { get; set; }
        public DateTime? Prazo { get; set; }


        public DateTime dt_modificado
        {
            get
            {
                if (!Modificado.HasValue) return Criado.Value;

                if (Criado > Modificado)
                {
                    return Criado.Value;
                }
                else
                {
                  return   Modificado.Value;
                }
            }
        }




    }
}
