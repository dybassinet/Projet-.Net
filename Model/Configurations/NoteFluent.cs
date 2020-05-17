using Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Configurations
{
    public class NoteFluent : EntityTypeConfiguration<Note>
    {
        public NoteFluent()
        {
            ToTable("App_Note");
            HasKey(e => e.NoteId);

            Property(e => e.NoteId)
                .HasColumnName("Note_Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Matiere)
                .HasColumnName("Note_Matiere")
                .HasMaxLength(255)
                .IsRequired();

            Property(e => e.Appreciation)
                .HasColumnName("Note_Appreciation")
                .HasMaxLength(255)
                .IsRequired();

            Property(e => e.DateNote)
                .HasColumnName("Note_Date")
                .IsRequired();

            Property(e => e.ValeurNote)
                .HasColumnName("Note_Valeur")
                .IsRequired();

            HasRequired(e => e.Eleve)
                .WithMany(eleve => eleve.Notes)
                .HasForeignKey(e => e.EleveId);
        }
    }
}
