using BusinessLayer.Queries;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Manager
    {
        private readonly ContexteDA monContexte;
        private static Manager _businessManager = null;

        public Manager()
        {
            monContexte = new ContexteDA();
        }

        /// <summary>
        /// Récupérer l'instance du pattern Singleton
        /// </summary>
        public static Manager Instance
        {
            get
            {
                if (_businessManager == null)
                    _businessManager = new Manager();
                return _businessManager;
            }
        }

        #region Classes

        /// <summary>
        /// Retourne toutes les classes
        /// </summary>
        /// <returns>Liste d'entités <see cref="Classe"/></returns>
        public List<Classe> GetAllClasses()
        {
            ClasseQuery query = new ClasseQuery(monContexte);
            List<Classe> result = query.GetAll();
            return result;
        }

        /// <summary>
        /// Retourne la classe correspondant à l'identifiant
        /// </summary>
        /// <param name="id">Identifiant de la classe</param>
        /// <returns>Entité <see cref="Classe"/></returns>
        public Classe GetClasseById(int id)
        {
            ClasseQuery query = new ClasseQuery(monContexte);
            Classe result = query.GetById(id);
            return result;
        }

        #endregion

        #region Eleves

        /// <summary>
        /// Retourne tous les élèves
        /// </summary>
        /// <returns>Liste d'entités <see cref="Eleve"/></returns>
        public List<Eleve> GetAllEleves()
        {
            EleveQuery query = new EleveQuery(monContexte);
            List<Eleve> result = query.GetAll();
            return result;
        }

        /// <summary>
        /// Retourne l'élève correspondant à l'identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'élève</param>
        /// <returns>Entité <see cref="Eleve"/></returns>
        public Eleve GetEleveById(int id)
        {
            EleveQuery query = new EleveQuery(monContexte);
            Eleve result = query.GetById(id);
            return result;
        }

        #endregion

        #region Notes

        /// <summary>
        /// Retourne toutes les notes
        /// </summary>
        /// <returns>Liste d'entités <see cref="Note"/></returns>
        public List<Note> GetAllNotes()
        {
            NoteQuery query = new NoteQuery(monContexte);
            List<Note> result = query.GetAll();
            return result;
        }

        /// <summary>
        /// Retourne la note correspondant à l'identifiant
        /// </summary>
        /// <param name="id">Identifiant de la note</param>
        /// <returns>Entité <see cref="Note"/></returns>
        public Note GetNoteById(int id)
        {
            NoteQuery query = new NoteQuery(monContexte);
            Note result = query.GetById(id);
            return result;
        }

        /// <summary>
        /// Retourne les notes correspondant à un élève
        /// </summary>
        /// <param name="eleveId">Identifiant de l'élève</param>
        /// <returns>Liste d'entités <see cref="Note"/></returns>
        public List<Note> GetNotesByEleveId(int eleveId)
        {
            NoteQuery query = new NoteQuery(monContexte);
            List<Note> result = query.GetByEleveId(eleveId);
            return result;
        }

        #endregion

        #region Absences

        /// <summary>
        /// Retourne toutes les absences
        /// </summary>
        /// <returns>Liste d'entités <see cref="Absence"/></returns>
        public List<Absence> GetAllAbsences()
        {
            AbsenceQuery query = new AbsenceQuery(monContexte);
            List<Absence> result = query.GetAll();
            return result;
        }

        /// <summary>
        /// Retourne l'absence correspondant à l'identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'absence</param>
        /// <returns>Entité <see cref="Absence"/></returns>
        public Absence GetAbsenceById(int id)
        {
            AbsenceQuery query = new AbsenceQuery(monContexte);
            Absence result = query.GetById(id);
            return result;
        }

        /// <summary>
        /// Retourne les absences correspondant à un élève
        /// </summary>
        /// <param name="eleveId">Identifiant de l'élève</param>
        /// <returns>Liste d'entités <see cref="Absence"/></returns>
        public List<Absence> GetAbsencesByEleveId(int eleveId)
        {
            AbsenceQuery query = new AbsenceQuery(monContexte);
            List<Absence> result = query.GetByEleveId(eleveId);
            return result;
        }

        #endregion
    }
}
