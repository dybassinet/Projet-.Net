using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Entities;
using System.Linq;
using System.Data.Entity;
using BusinessLayer;

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
            Manager.Instance.AddClasse(new Classe { NomEtablissement = "test", Niveau = "term" });
            Assert.AreEqual(1, Manager.Instance.GetAllClasses().Count);
        }

        [TestMethod]
        public void TestAddEleve()
        {
            //On ajoute dans un premier temps une classe pour vérifier la relation Classe/Eleve
            Manager.Instance.AddClasse(new Classe { NomEtablissement = "test", Niveau = "term" });
            Assert.AreEqual(1, Manager.Instance.GetAllClasses().Count);

            Classe classe = Manager.Instance.GetAllClasses().LastOrDefault();

            Manager.Instance.AddEleve(new Eleve { Nom = "Bassinet", Prenom = "Dylan", DateNaissance = new DateTime(1999, 3, 1), ClassId = classe.ClassId });
            Assert.AreEqual(1, Manager.Instance.GetAllEleves("").Count);
            int nbEleveClasse1 = Manager.Instance.GetClasseById(classe.ClassId).Eleves.Count();
            Assert.AreEqual(1, nbEleveClasse1);
        }

        [TestMethod]
        public void TestAddAbsence()
        {
            //On ajoute dans un premier temps une classe pour vérifier la relation Classe/Eleve
            Manager.Instance.AddClasse(new Classe { NomEtablissement = "test", Niveau = "term" });
            Assert.AreEqual(1, Manager.Instance.GetAllClasses().Count);

            Classe classe = Manager.Instance.GetAllClasses().LastOrDefault();

            //On ajoute dans un premier temps un élève pour vérifier la relation Eleve/Absence
            Manager.Instance.AddEleve(new Eleve { Nom = "Bassinet", Prenom = "Dylan", DateNaissance = new DateTime(1999, 3, 1), ClassId = classe.ClassId });
            Assert.AreEqual(1, Manager.Instance.GetAllEleves("").Count);

            Eleve eleve = Manager.Instance.GetAllEleves("").LastOrDefault();

            Manager.Instance.AddAbsence(new Absence { DateAbsence = DateTime.Now, Motif = "Malade", EleveId = eleve.EleveId });
            Assert.AreEqual(1, Manager.Instance.GetAllAbsences().Count);
            int nbAbsenceEleve1 = Manager.Instance.GetEleveById(eleve.EleveId).Absences.Count();
            Assert.AreEqual(1, nbAbsenceEleve1);
        }

        [TestMethod]
        public void TestAddNote()
        {
            //On ajoute dans un premier temps une classe pour vérifier la relation Classe/Eleve
            Manager.Instance.AddClasse(new Classe { NomEtablissement = "test", Niveau = "term" });
            Assert.AreEqual(1, Manager.Instance.GetAllClasses().Count);

            Classe classe = Manager.Instance.GetAllClasses().LastOrDefault();

            //On ajoute dans un premier temps un élève pour vérifier la relation Eleve/Absence
            Manager.Instance.AddEleve(new Eleve { Nom = "Bassinet", Prenom = "Dylan", DateNaissance = new DateTime(1999, 3, 1), ClassId = classe.ClassId });
            Assert.AreEqual(1, Manager.Instance.GetAllEleves("").Count);

            Eleve eleve = Manager.Instance.GetAllEleves("").LastOrDefault();

            Manager.Instance.AddNote(new Note { ValeurNote = 10, DateNote = DateTime.Now, Matiere = "Mathématique", Appreciation = "Effort à faire", EleveId = eleve.EleveId });
            Assert.AreEqual(1, Manager.Instance.GetAllNotes().Count());
            int nbNotesEleve1 = Manager.Instance.GetEleveById(eleve.EleveId).Notes.Count();
            Assert.AreEqual(1, nbNotesEleve1);
        }

        [TestMethod]
        public void TestRemoveClasse()
        {
            //ajout de la classe
            Manager.Instance.AddClasse(new Classe { Niveau = "DUT", NomEtablissement = "test" });
            Classe classe = Manager.Instance.GetAllClasses().LastOrDefault();
            Assert.AreEqual("DUT", classe.Niveau);
            Assert.AreEqual("test", classe.NomEtablissement);

            //Suppression de la classe
            Manager.Instance.DeleteClasse(classe.ClassId);
            bool exist = monContexte.Classes.Where(c => c.ClassId == classe.ClassId).Any();
            Assert.AreEqual(false, exist);
        }

        [TestMethod]
        public void TestRemoveEleve()
        {
            //Ajout classe pour élève
            Manager.Instance.AddClasse(new Classe { Niveau = "DUT", NomEtablissement = "test" });
            Classe classe = Manager.Instance.GetAllClasses().LastOrDefault();

            //Ajout de l'élève
            Manager.Instance.AddEleve(new Eleve { Nom = "Bassinet", Prenom = "Dylan", DateNaissance = new DateTime(1999, 3, 1), ClassId = classe.ClassId });
            Eleve eleve = Manager.Instance.GetAllEleves("").LastOrDefault();
            Assert.AreEqual("Bassinet", eleve.Nom);
            Assert.AreEqual("Dylan", eleve.Prenom);

            //Suppression de l'élève
            Manager.Instance.DeleteClasse(classe.ClassId);
            Manager.Instance.DeleteEleve(eleve.EleveId);
            bool exist = monContexte.Eleves.Where(e => e.EleveId == eleve.EleveId).Any();
            Assert.AreEqual(false, exist);
        }

        [TestMethod]
        public void TestEditClasse()
        {
            //Ajout classe
            Manager.Instance.AddClasse(new Classe { Niveau = "DUT", NomEtablissement = "uca" });
            Classe classe = Manager.Instance.GetAllClasses().LastOrDefault();
            Assert.AreEqual("DUT", classe.Niveau);
            Assert.AreEqual("uca", classe.NomEtablissement);

            //Modification classe
            classe.Niveau = "term";
            classe.NomEtablissement = "Lycee";
            Manager.Instance.EditClasse(classe);
            Classe expectedClass = Manager.Instance.GetClasseById(classe.ClassId);
            Assert.AreEqual(expectedClass.Niveau, classe.Niveau);
            Assert.AreEqual(expectedClass.NomEtablissement, classe.NomEtablissement);

        }

        [TestMethod]
        public void TestEditEleve()
        {
            //Ajout classe
            Manager.Instance.AddClasse(new Classe { Niveau = "DUT", NomEtablissement = "uca" });
            Classe classe = Manager.Instance.GetAllClasses().LastOrDefault();
            Assert.AreEqual("DUT", classe.Niveau);
            Assert.AreEqual("uca", classe.NomEtablissement);

            Manager.Instance.AddEleve(new Eleve { Nom = "Kolac", Prenom = "Jean", DateNaissance = DateTime.Now.Date, ClassId = classe.ClassId });
            Eleve eleve = Manager.Instance.GetAllEleves("").LastOrDefault();
            Assert.AreEqual("Kolac", eleve.Nom);
            Assert.AreEqual("Jean", eleve.Prenom);

            //Modification élève
            eleve.Nom = "Zidane";
            eleve.Prenom = "Zinedine";
            Manager.Instance.EditEleve(eleve);
            Eleve expectedEleve = Manager.Instance.GetEleveById(eleve.EleveId);
            Assert.AreEqual(expectedEleve.Nom, eleve.Nom);
            Assert.AreEqual(expectedEleve.Prenom, eleve.Prenom);
        }

        [TestMethod]
        public void TestEditAbsence()
        {
            //Ajout classe
            Manager.Instance.AddClasse(new Classe { Niveau = "DUT", NomEtablissement = "uca" });
            Classe classe = Manager.Instance.GetAllClasses().LastOrDefault();
            Assert.AreEqual("DUT", classe.Niveau);
            Assert.AreEqual("uca", classe.NomEtablissement);

            Manager.Instance.AddEleve(new Eleve { Nom = "Kolac", Prenom = "Jean", DateNaissance = DateTime.Now.Date, ClassId = classe.ClassId });
            Eleve eleve = Manager.Instance.GetAllEleves("").LastOrDefault();
            Assert.AreEqual("Kolac", eleve.Nom);
            Assert.AreEqual("Jean", eleve.Prenom);

            Manager.Instance.AddAbsence(new Absence { Motif = "Otite", DateAbsence = DateTime.Now.Date, EleveId = eleve.EleveId });
            Absence absence = Manager.Instance.GetAllAbsences().LastOrDefault();
            Assert.AreEqual("Otite", absence.Motif);
            Assert.AreEqual(DateTime.Now.Date, absence.DateAbsence);

            //Modification absence
            absence.Motif = "Gastro";
            absence.DateAbsence = new DateTime(2020, 11, 21);
            Manager.Instance.EditAbsence(absence);
            Absence expectedAbsence = Manager.Instance.GetAbsenceById(absence.AbsenceId);
            Assert.AreEqual(expectedAbsence.Motif, absence.Motif);
            Assert.AreEqual(expectedAbsence.DateAbsence, absence.DateAbsence);
        }

        [TestMethod]
        public void TestEditNote()
        {
            Manager.Instance.AddClasse(new Classe { Niveau = "DUT", NomEtablissement = "uca" });
            Classe classe = Manager.Instance.GetAllClasses().LastOrDefault();
            Assert.AreEqual("DUT", classe.Niveau);
            Assert.AreEqual("uca", classe.NomEtablissement);

            Manager.Instance.AddEleve(new Eleve { Nom = "Kolac", Prenom = "Jean", DateNaissance = DateTime.Now.Date, ClassId = classe.ClassId });
            Eleve eleve = Manager.Instance.GetAllEleves("").LastOrDefault();
            Assert.AreEqual("Kolac", eleve.Nom);
            Assert.AreEqual("Jean", eleve.Prenom);

            Manager.Instance.AddNote(new Note { Matiere = "Histoire", ValeurNote = 12, Appreciation = "à améliorer", DateNote = DateTime.Now.Date, EleveId = eleve.EleveId });
            Note note = Manager.Instance.GetAllNotes().LastOrDefault();
            Assert.AreEqual("à améliorer", note.Appreciation);
            Assert.AreEqual(12, note.ValeurNote);

            //Modification note
            note.ValeurNote = 18;
            note.Appreciation = "très bien";
            Manager.Instance.EditNote(note);
            Note expectedNote = Manager.Instance.GetNoteById(note.NoteId);
            Assert.AreEqual(expectedNote.ValeurNote, note.ValeurNote);
            Assert.AreEqual(expectedNote.Appreciation, note.Appreciation);
        }
    }
}
