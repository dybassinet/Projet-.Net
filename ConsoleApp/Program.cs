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
            /*contexte.Classes.Add(new Classe { Niveau = "Terminal", NomEtablissement = "test" });
            contexte.SaveChanges();
            Classe classe = manager.GetAllClasses().LastOrDefault();
            contexte.Eleves.Add(new Eleve { Nom = "Michel", Prenom = "Jean", DateNaissance = new DateTime(2000, 3, 2), ClassId = classe.ClassId });
            contexte.Eleves.Add(new Eleve { Nom = "Trapou", Prenom = "Olivier", DateNaissance = new DateTime(2000, 9, 2), ClassId = classe.ClassId });
            contexte.Eleves.Add(new Eleve { Nom = "Hule", Prenom = "Laurent", DateNaissance = new DateTime(2000, 11, 2), ClassId = classe.ClassId });
            contexte.Eleves.Add(new Eleve { Nom = "Foki", Prenom = "Maude", DateNaissance = new DateTime(2000, 10, 2), ClassId = classe.ClassId });
            contexte.SaveChanges();*/
            Eleve eleve = contexte.Eleves.ToList().LastOrDefault();
            contexte.Notes.Add(new Note { Matiere = "Math", Appreciation = "Bien", DateNote = DateTime.Now, ValeurNote = 15, EleveId = eleve.EleveId });
            contexte.Notes.Add(new Note { Matiere = "Math", Appreciation = "pas bien", DateNote = DateTime.Now, ValeurNote = 8, EleveId = eleve.EleveId });
            contexte.Notes.Add(new Note { Matiere = "Math", Appreciation = "effort à maintenir", DateNote = DateTime.Now, ValeurNote = 11, EleveId = eleve.EleveId });
            contexte.Notes.Add(new Note { Matiere = "Math", Appreciation = "très bien", DateNote = DateTime.Now, ValeurNote = 18, EleveId = eleve.EleveId });
            contexte.Absences.Add(new Absence { DateAbsence = new DateTime(2020, 1, 22), Motif = "Gastro", EleveId = eleve.EleveId });
            contexte.Absences.Add(new Absence { DateAbsence = new DateTime(2020, 3, 12), Motif = "Grippe", EleveId = eleve.EleveId });
            contexte.SaveChanges();
        }
    }
}
