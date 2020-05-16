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
        public static ContexteDA monContexte { get; set; }

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

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            monContexte = new ContexteDA();   
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
            monContexte.Eleves.Add(new Eleve { Nom = "Bassinet", Prenom = "Dylan", DateNaissance = new DateTime(1999, 3, 1), ClassId = 1 });
            monContexte.SaveChanges();
            Assert.AreEqual(1, monContexte.Eleves.Count());
            int nbEleveClasse1 = monContexte.Classes.Where(classe => classe.ClassId == 1).SingleOrDefault().Eleves.Count();
            Assert.AreEqual(1, nbEleveClasse1);
        }
    }
}
