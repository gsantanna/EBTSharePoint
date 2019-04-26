using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sandigital.sharepoint.webparts.Modelos
{
    public class Reuniao
    {
            public int ID_Reuniao { get; set; }
            public DateTime dt_reuniao { get; set; }
            public string Titulo { get; set; }
            public List<Participante> Participantes { get; set; }
            public List<Pauta> Pautas { get; set; }

            public Reuniao()
            {
                Participantes = new List<Participante>();
                Pautas = new List<Pauta>();
            }






          

        }

}
