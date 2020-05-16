using Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Configurations
{
    public class AbsenceFluent : EntityTypeConfiguration<Absence>
    {
        public AbsenceFluent()
        {
            ToTable("App_Absence");
            HasKey(e => e.AbsenceId);

            Property(e => e.AbsenceId)
                .HasColumnName("Absence_Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.DateAbsence)
                .HasColumnName("Absence_Date")
                .IsRequired();

            Property(e => e.Motif)
                .HasColumnName("Absence_Motif")
                .IsRequired();

            HasRequired(e => e.Eleve)
                .WithMany(eleve => eleve.Absences)
                .HasForeignKey(e => e.EleveId);
        }
    }
}
