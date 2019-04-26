using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sandigital.sharepoint.webparts.Modelos
{
    public class Slide
    {
        
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Link { get; set; }
        public int Ordem { get; set; }
        public string css { get; set; }
        public string Tamanho { get; set; }


    }
}
