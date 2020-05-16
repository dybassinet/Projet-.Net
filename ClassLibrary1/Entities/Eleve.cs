using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Eleve
    {
        public int EleveId { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime DateNaissance { get; set; }

        public int ClassId { get; set; }
    }
}
