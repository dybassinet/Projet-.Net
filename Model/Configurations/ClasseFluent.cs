using Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Configurations
{
    public class ClasseFluent : EntityTypeConfiguration<Classe>
    {
        public ClasseFluent()
        {
            ToTable("App_Classe");
            HasKey(e => e.ClassId);

            Property(e => e.ClassId)
                .HasColumnName("Classe_Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.NomEtablissement)
                .HasColumnName("Classe_NomEtab")
                .HasMaxLength(50)
                .IsRequired();

            Property(e => e.Niveau)
                .HasColumnName("Classe_Niveau")
                .HasMaxLength(30)
                .IsRequired();

            HasMany(e => e.Eleves)
                .WithRequired(eleve => eleve.Classe)
                .HasForeignKey(eleve => eleve.ClassId);
        }
    }
}
