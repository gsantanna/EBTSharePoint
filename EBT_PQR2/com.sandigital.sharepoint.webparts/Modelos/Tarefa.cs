using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sandigital.sharepoint.webparts.Modelos
{   [Serializable]
    public class Tarefa
    {


    public Tarefa()
    {
        this.Itens = new List<ItemTarefa>();

    }
        public int ID { get; set; }
        public int ID_Pauta { get; set; }

        public string Titulo { get; set; }
        public string Status
        {
            get
            {
                if (this.Itens != null && this.Itens.Count>0)
                {


                    return (this.Itens.Where(f => f.Status == "Concluído" || f.Status == "Informação").Count() == this.Itens.Count() ? "Concluído" : "Em Andamento");

                    //return (this.Itens.Where(f => f.Status != "Concluído" || f.Status != "Informação").Count() > 0) ? "Em Andamento" : "Concluído";
                }
                else
                {
                    return "Em Andamento";
                }
            }
        }


        public string Atribuidaa { get; set; }
        public DateTime? DataConclusao { get; set; }
        public DateTime? DataPrevista { get; set; }
        public DateTime? DataReuniao { get; set; }
        public string Anexos { get; set; }
        public List<ItemTarefa> Itens { get; set; }
        public string Descricao { get; set; }

        public DateTime? Criado { get; set; }
        public DateTime? Modificado { get; set; }

        public DateTime dt_modificado
        {
            get
            {  
                DateTime?[] Datas;

                if(this.Itens.Count >0)
                {
                     DateTime dtTarefas = this.Itens.Max(f => f.dt_modificado);
                     Datas = new DateTime?[] { dtTarefas, Modificado, Criado };


                }  else
                    Datas = new DateTime?[] { Modificado, Criado };


                return (Datas.Max().Value);

            }
        


        }



    }





}
