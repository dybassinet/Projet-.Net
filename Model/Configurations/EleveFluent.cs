using Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Configurations
{
    public class EleveFluent : EntityTypeConfiguration<Eleve>
    {
        public EleveFluent()
        {
            ToTable("App_Eleve");
            HasKey(e => e.EleveId);

            Property(e => e.EleveId)
                .HasColumnName("Eleve_Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Nom)
                .HasColumnName("Eleve_Nom")
                .HasMaxLength(30)
                .IsRequired();

            Property(e => e.Prenom)
                .HasColumnName("Eleve_Prenom")
                .HasMaxLength(30)
                .IsRequired();

            Property(e => e.DateNaissance)
                .HasColumnName("Eleve_DateNaissance")
                .IsRequired();

            HasRequired(e => e.Classe)
                .WithMany(classe => classe.Eleves)
                .HasForeignKey(e => e.ClassId);

            HasMany(e => e.Notes)
                .WithRequired(note => note.Eleve)
                .HasForeignKey(note => note.EleveId);

            HasMany(e => e.Absences)
                .WithRequired(absence => absence.Eleve)
                .HasForeignKey(absence => absence.EleveId);
        }
    }
}
