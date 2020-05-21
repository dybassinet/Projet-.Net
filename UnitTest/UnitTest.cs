using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Entities;
using System.Linq;
using System.Data.Entity;

namespace UnitTest
{
    /// <summary>
    /// Description résumée pour UnitTest
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        public ContexteDA monContexte { get; set; }

        public UnitTest()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            monContexte = new ContexteDA();
            monContexte.Classes.RemoveRange(monContexte.Classes.ToList());
            monContexte.Absences.RemoveRange(monContexte.Absences.ToList());
            monContexte.Notes.RemoveRange(monContexte.Notes.ToList());
            monContexte.Eleves.RemoveRange(monContexte.Eleves.ToList());
            monContexte.SaveChanges();
        }

        [TestMethod]
        public void TestAddClasse()
        {
            monContexte.Classes.Add(new Classe { NomEtablissement = "test", Niveau = "term" });
            monContexte.SaveChanges();
            Assert.AreEqual(1, monContexte.Classes.Count());
        }

        [TestMethod]
        public void TestAddEleve()
        {
            //On ajoute dans un premier temps une classe pour vérifier la relation Classe/Eleve
            monContexte.Classes.Add(new Classe { NomEtablissement = "test", Niveau = "term" });
            monContexte.SaveChanges();
            Assert.AreEqual(1, monContexte.Classes.Count());

            Classe classe = monContexte.Classes.ToList().LastOrDefault();

            monContexte.Eleves.Add(new Eleve { Nom = "Bassinet", Prenom = "Dylan", DateNaissance = new DateTime(1999, 3, 1), ClassId = classe.ClassId });
            monContexte.SaveChanges();
            Assert.AreEqual(1, monContexte.Eleves.Count());
            int nbEleveClasse1 = monContexte.Classes.Where(c => c.ClassId == classe.ClassId).SingleOrDefault().Eleves.Count();
            Assert.AreEqual(1, nbEleveClasse1);
        }

        [TestMethod]
        public void TestAddAbsence()
        {
            //On ajoute dans un premier temps une classe pour vérifier la relation Classe/Eleve
            monContexte.Classes.Add(new Classe { NomEtablissement = "test", Niveau = "term" });
            monContexte.SaveChanges();
            Assert.AreEqual(1, monContexte.Classes.Count());

            Classe classe = monContexte.Classes.ToList().LastOrDefault();

            //On ajoute dans un premier temps un élève pour vérifier la relation Eleve/Absence
            monContexte.Eleves.Add(new Eleve { Nom = "Bassinet", Prenom = "Dylan", DateNaissance = new DateTime(1999, 3, 1), ClassId = classe.ClassId });
            monContexte.SaveChanges();

            Eleve eleve = monContexte.Eleves.ToList().LastOrDefault();

            monContexte.Absences.Add(new Absence { DateAbsence = DateTime.Now, Motif = "Malade", EleveId = eleve.EleveId });
            monContexte.SaveChanges();
            Assert.AreEqual(1, monContexte.Absences.Count());
            int nbAbsenceEleve1 = monContexte.Eleves.Where(e => e.EleveId == eleve.EleveId).SingleOrDefault().Absences.Count();
            Assert.AreEqual(1, nbAbsenceEleve1);
        }

        [TestMethod]
        public void TestAddNote()
        {
            //On ajoute dans un premier temps une classe pour vérifier la relation Classe/Eleve
            monContexte.Classes.Add(new Classe { NomEtablissement = "test", Niveau = "term" });
            monContexte.SaveChanges();
            Assert.AreEqual(1, monContexte.Classes.Count());

            Classe classe = monContexte.Classes.ToList().LastOrDefault();

            //On ajoute dans un premier temps un élève pour vérifier la relation Eleve/Absence
            monContexte.Eleves.Add(new Eleve { Nom = "Bassinet", Prenom = "Dylan", DateNaissance = new DateTime(1999, 3, 1), ClassId = classe.ClassId });
            monContexte.SaveChanges();

            Eleve eleve = monContexte.Eleves.ToList().LastOrDefault();

            monContexte.Notes.Add(new Note { ValeurNote = 10, DateNote = DateTime.Now, Matiere = "Mathématique", Appreciation = "Effort à faire", EleveId = eleve.EleveId });
            monContexte.SaveChanges();
            Assert.AreEqual(1, monContexte.Notes.ToList().Count());
            int nbNotesEleve1 = monContexte.Eleves.Where(e => e.EleveId == eleve.EleveId).SingleOrDefault().Notes.Count();
            Assert.AreEqual(1, nbNotesEleve1);
        }

        [TestMethod]
        public void TestRemoveClasse()
        {
            //ajout de la classe
            monContexte.Classes.Add(new Classe { Niveau = "CP", NomEtablissement = "test" });
            monContexte.SaveChanges();
            Classe classe = monContexte.Classes.ToList().LastOrDefault();
            Assert.AreEqual("CP", classe.Niveau);
            Assert.AreEqual("test", classe.NomEtablissement);

            //Suppression de la classe
            monContexte.Classes.Remove(classe);
            monContexte.SaveChanges();
            bool exist = monContexte.Classes.Where(c => c.ClassId == classe.ClassId).Any();
            Assert.AreEqual(false, exist);
        }

        [TestMethod]
        public void TestRemoveEleve()
        {
            //Ajout classe pour élève
            monContexte.Classes.Add(new Classe { Niveau = "CP", NomEtablissement = "test" });
            monContexte.SaveChanges();
            Classe classe = monContexte.Classes.ToList().LastOrDefault();

            //Ajout de l'élève
            monContexte.Eleves.Add(new Eleve { Nom = "Bassinet", Prenom = "Dylan", DateNaissance = new DateTime(1999, 3, 1), ClassId = classe.ClassId });
            monContexte.SaveChanges();
            Eleve eleve = monContexte.Eleves.ToList().LastOrDefault();
            Assert.AreEqual("Bassinet", eleve.Nom);
            Assert.AreEqual("Dylan", eleve.Prenom);

            //Suppression de l'élève
            monContexte.Classes.Remove(classe);
            monContexte.Eleves.Remove(eleve);
            monContexte.SaveChanges();
            bool exist = monContexte.Eleves.Where(e => e.EleveId == eleve.EleveId).Any();
            Assert.AreEqual(false, exist);
        }

        [TestMethod]
        public void TestRemoveAbsence()
        {
            //Ajout classe pour élève
            monContexte.Classes.Add(new Classe { Niveau = "CP", NomEtablissement = "test" });
            monContexte.SaveChanges();
            Classe classe = monContexte.Classes.ToList().LastOrDefault();

            //Ajout de l'élève pour l'absence
            monContexte.Eleves.Add(new Eleve { Nom = "Bassinet", Prenom = "Dylan", DateNaissance = new DateTime(1999, 3, 1), ClassId = classe.ClassId });
            monContexte.SaveChanges();
            Eleve eleve = monContexte.Eleves.ToList().LastOrDefault();

            //Ajout de l'absence
            monContexte.Absences.Add(new Absence { Motif = "Grippe", DateAbsence = DateTime.Now.Date, EleveId = eleve.EleveId });
            monContexte.SaveChanges();
            Absence absence = monContexte.Absences.ToList().LastOrDefault();
            Assert.AreEqual("Grippe", absence.Motif);
            Assert.AreEqual(DateTime.Now.Date, absence.DateAbsence);

            //Suppression de l'absence
            monContexte.Classes.Remove(classe);
            monContexte.Eleves.Remove(eleve);
            monContexte.Absences.Remove(absence);
            monContexte.SaveChanges();
            bool exist = monContexte.Absences.Where(abs => abs.AbsenceId == absence.AbsenceId).Any();
            Assert.AreEqual(false, exist);
        }

        [TestMethod]
        public void TestRemoveNote()
        {
            //Ajout classe pour élève
            monContexte.Classes.Add(new Classe { Niveau = "CP", NomEtablissement = "test" });
            monContexte.SaveChanges();
            Classe classe = monContexte.Classes.ToList().LastOrDefault();

            //Ajout de l'élève pour la note
            monContexte.Eleves.Add(new Eleve { Nom = "Bassinet", Prenom = "Dylan", DateNaissance = new DateTime(1999, 3, 1), ClassId = classe.ClassId });
            monContexte.SaveChanges();
            Eleve eleve = monContexte.Eleves.ToList().LastOrDefault();

            //Ajout de la note
            monContexte.Notes.Add(new Note { Matiere = "SVT", ValeurNote = 16, Appreciation = "Bon travail", DateNote = DateTime.Now, EleveId = eleve.EleveId });
            monContexte.SaveChanges();
            Note note = monContexte.Notes.ToList().LastOrDefault();
            Assert.AreEqual("SVT", note.Matiere);
            Assert.AreEqual(16, note.ValeurNote);

            //Suppression de la note
            monContexte.Classes.Remove(classe);
            monContexte.Eleves.Remove(eleve);
            monContexte.Notes.Remove(note);
            monContexte.SaveChanges();
            bool exist = monContexte.Notes.Where(n => n.NoteId == note.NoteId).Any();
            Assert.AreEqual(false, exist);
        }

        [TestMethod]
        public void TestEditClasse()
        {
            //Ajout classe
            monContexte.Classes.Add(new Classe { Niveau = "DUT", NomEtablissement = "uca" });
            monContexte.SaveChanges();
            Classe classe = monContexte.Classes.ToList().LastOrDefault();
            Assert.AreEqual("DUT", classe.Niveau);
            Assert.AreEqual("uca", classe.NomEtablissement);

            //Modification classe
            classe.Niveau = "term";
            classe.NomEtablissement = "Lycee";
            monContexte.SaveChanges();
            Classe expectedClass = monContexte.Classes.Where(c => c.ClassId == classe.ClassId).SingleOrDefault();
            Assert.AreEqual(expectedClass.Niveau, classe.Niveau);
            Assert.AreEqual(expectedClass.NomEtablissement, classe.NomEtablissement);

        }

        [TestMethod]
        public void TestEditEleve()
        {
            //Ajout élève
            monContexte.Classes.Add(new Classe { Niveau = "DUT", NomEtablissement = "uca" });
            monContexte.SaveChanges();
            Classe classe = monContexte.Classes.ToList().LastOrDefault();

            monContexte.Eleves.Add(new Eleve { Nom = "Kolac", Prenom = "Jean", DateNaissance = DateTime.Now.Date, ClassId = classe.ClassId });
            monContexte.SaveChanges();
            Eleve eleve = monContexte.Eleves.ToList().LastOrDefault();
            Assert.AreEqual("Kolac", eleve.Nom);
            Assert.AreEqual("Jean", eleve.Prenom);

            //Modification élève
            eleve.Nom = "Zidane";
            eleve.Prenom = "Zinedine";
            monContexte.SaveChanges();
            Eleve expectedEleve = monContexte.Eleves.Where(e => e.EleveId == eleve.EleveId).SingleOrDefault();
            Assert.AreEqual(expectedEleve.Nom, eleve.Nom);
            Assert.AreEqual(expectedEleve.Prenom, eleve.Prenom);
        }

        [TestMethod]
        public void TestEditAbsence()
        {
            //Ajout absence
            monContexte.Classes.Add(new Classe { Niveau = "DUT", NomEtablissement = "uca" });
            monContexte.SaveChanges();
            Classe classe = monContexte.Classes.ToList().LastOrDefault();

            monContexte.Eleves.Add(new Eleve { Nom = "Kolac", Prenom = "Jean", DateNaissance = DateTime.Now.Date, ClassId = classe.ClassId });
            monContexte.SaveChanges();
            Eleve eleve = monContexte.Eleves.ToList().LastOrDefault();     

            monContexte.Absences.Add(new Absence { Motif = "Otite", DateAbsence = DateTime.Now.Date, EleveId = eleve.EleveId });
            monContexte.SaveChanges();
            Absence absence = monContexte.Absences.ToList().LastOrDefault();
            Assert.AreEqual("Otite", absence.Motif);
            Assert.AreEqual(DateTime.Now.Date, absence.DateAbsence);

            //Modification absence
            absence.Motif = "Gastro";
            absence.DateAbsence = new DateTime(2020, 11, 21);
            monContexte.SaveChanges();
            Absence expectedAbsence = monContexte.Absences.Where(abs => abs.AbsenceId == absence.AbsenceId).SingleOrDefault();
            Assert.AreEqual(expectedAbsence.Motif, absence.Motif);
            Assert.AreEqual(expectedAbsence.DateAbsence, absence.DateAbsence);
        }

        [TestMethod]
        public void TestEditNote()
        {
            //Ajout note
            monContexte.Classes.Add(new Classe { Niveau = "DUT", NomEtablissement = "uca" });
            monContexte.SaveChanges();
            Classe classe = monContexte.Classes.ToList().LastOrDefault();

            monContexte.Eleves.Add(new Eleve { Nom = "Kolac", Prenom = "Jean", DateNaissance = DateTime.Now.Date, ClassId = classe.ClassId });
            monContexte.SaveChanges();
            Eleve eleve = monContexte.Eleves.ToList().LastOrDefault();

            monContexte.Notes.Add(new Note { Matiere = "Histoire", ValeurNote = 12, Appreciation = "à améliorer", DateNote = DateTime.Now.Date, EleveId = eleve.EleveId });
            monContexte.SaveChanges();
            Note note = monContexte.Notes.ToList().LastOrDefault();
            Assert.AreEqual("à améliorer", note.Appreciation);
            Assert.AreEqual(12, note.ValeurNote);

            //Modification note
            note.ValeurNote = 18;
            note.Appreciation = "très bien";
            monContexte.SaveChanges();
            Note expectedNote = monContexte.Notes.Where(n => n.NoteId == note.NoteId).SingleOrDefault();
            Assert.AreEqual(expectedNote.ValeurNote, note.ValeurNote);
            Assert.AreEqual(expectedNote.Appreciation, note.Appreciation);
        }
    }
}
