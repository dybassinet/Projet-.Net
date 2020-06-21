using BusinessLayer;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = Manager.Instance;
            ContexteDA contexte = new ContexteDA();
            contexte.Classes.Add(new Classe { Niveau = "Terminal", NomEtablissement = "test" });
            contexte.SaveChanges();
            Classe classe = manager.GetAllClasses().LastOrDefault();
            contexte.Eleves.Add(new Eleve { Nom = "Dubois", Prenom = "Jean", DateNaissance = new DateTime(1999, 5, 2), ClassId = classe.ClassId });
            contexte.Eleves.Add(new Eleve { Nom = "Dupont", Prenom = "Marie", DateNaissance = new DateTime(2000, 9, 5), ClassId = classe.ClassId });
            contexte.Eleves.Add(new Eleve { Nom = "Roche", Prenom = "Pierre", DateNaissance = new DateTime(2000, 11, 6), ClassId = classe.ClassId });
            contexte.Eleves.Add(new Eleve { Nom = "Hette", Prenom = "Julie", DateNaissance = new DateTime(2000, 12, 10), ClassId = classe.ClassId });
            contexte.SaveChanges();
        }
    }
}
