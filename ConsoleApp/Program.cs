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
            List<Classe> classes = manager.GetAllClasses();
            foreach (Classe classe in classes)
            {
                Console.WriteLine(classe.NomEtablissement);
            }
        }
    }
}
