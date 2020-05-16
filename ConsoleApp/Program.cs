using Model;
using Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ContexteDA monContexte = new ContexteDA();
            List<Classe> classes = monContexte.Classes.ToList();
        }
    }
}
