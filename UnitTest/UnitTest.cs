using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Entities;
using System.Linq;

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
            monContexte.Classes.Add(new Classe { NomEtablissement = "test", Niveau = "cp" });
            monContexte.SaveChanges();
            Assert.AreEqual(1, monContexte.Classes.Count());
        }

        [TestMethod]
        public void TestAddEleve()
        {
            //On ajoute dans un premier temps une classe pour vérifier la relation Classe/Eleve
            monContexte.Classes.Add(new Classe { NomEtablissement = "test", Niveau = "cp" });
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
            monContexte.Classes.Add(new Classe { NomEtablissement = "test", Niveau = "cp" });
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
            monContexte.Classes.Add(new Classe { NomEtablissement = "test", Niveau = "cp" });
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
    }
}
