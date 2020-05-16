using Model.Configurations;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ContexteDA : DbContext
    {
        public ContexteDA() : base("name=ConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ClasseFluent());
            modelBuilder.Configurations.Add(new EleveFluent());
            modelBuilder.Configurations.Add(new NoteFluent());
            modelBuilder.Configurations.Add(new AbsenceFluent());
        }

        public DbSet<Classe> Classes { get; set; }

        public DbSet<Eleve> Eleves { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Absence> Absences { get; set; }
    }
}
