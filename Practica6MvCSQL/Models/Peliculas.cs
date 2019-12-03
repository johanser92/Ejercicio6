using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica6MvCSQL.Models
{
    public class Peliculas
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
         public string AutorPrincipal { get; set; }
        public int NumAutores { get; set; }
         public double Duracion { get; set; }
        public int Estreno { get; set; }
    }
}