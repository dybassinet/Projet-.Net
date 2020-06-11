using BusinessLayer;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.ViewModels.Common;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// ViewModel représentant un Produit (avec son détail)
    /// Hérite de BaseViewModel
    /// </summary>
    public class DetailEleveViewModel : BaseViewModel
    {
        #region Variables

        private string _prenom;
        private string _nom;
        private double _moyenne;
        private int _nbAbsences;
        private Eleve _eleve;
        private DateTime _dateNaissance;
        private RelayCommand _editOperation;
        private RelayCommand _showAddNoteOperation;
        private RelayCommand _addNoteOperation;
        private string _visibility;
        private string _nouvelleNoteValeur;
        private string _nouvelleNoteMatiere;
        private DateTime _nouvelleNoteDate;
        private string _nouvelleNoteAppreciation;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// <param name="eleve">Eleve à transformer en DetailEleveViewModel</param>
        /// </summary>
        public DetailEleveViewModel(Eleve eleve)
        {
            _eleve = eleve;
            _nom = eleve.Nom;
            _prenom = eleve.Prenom;
            _dateNaissance = eleve.DateNaissance;
            _moyenne = Manager.Instance.GetAverageByEleveId(eleve.EleveId);
            _nbAbsences = Manager.Instance.GetNbAbsencesByEleveId(eleve.EleveId);
            _visibility = "Hidden";
            _nouvelleNoteDate = DateTime.Now.Date;
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Nom de l'élève
        /// </summary>
        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                OnPropertyChanged("Nom");
            }
        }

        /// <summary>
        /// Prenom de l'élève
        /// </summary>
        public string Prenom
        {
            get { return _prenom; }
            set
            {
                _prenom = value;
                OnPropertyChanged("Prenom");
            }
        }

        public double Moyenne
        {
            get { return _moyenne; }
            set
            {
                _moyenne = value;
                OnPropertyChanged("Moyenne");
            }
        }

        public int NbAbsences
        {
            get { return _nbAbsences; }
            set { _nbAbsences = value; }
        }

        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set { _dateNaissance = value; }
        }

        public string Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged("Visibility");
            }
        }

        public string NouvelleNoteValeur
        {
            get { return _nouvelleNoteValeur; }
            set { _nouvelleNoteValeur = value; }
        }

        public string NouvelleNoteMatiere
        {
            get { return _nouvelleNoteMatiere; }
            set { _nouvelleNoteMatiere = value; }
        }

        public DateTime NouvelleNoteDate
        {
            get { return _nouvelleNoteDate; }
            set { _nouvelleNoteDate = value; }
        }

        public string NouvelleNoteAppreciation
        {
            get { return _nouvelleNoteAppreciation; }
            set { _nouvelleNoteAppreciation = value; }
        }

        #endregion

        #region Commandes

        public ICommand EditOperation
        {
            get
            {
                if (_editOperation == null)
                {
                    _editOperation = new RelayCommand(() => this.EditEleve(_eleve));
                }

                return _editOperation;
            }
        }

        public ICommand ShowAddNoteOperation
        {
            get
            {
                if (_showAddNoteOperation == null)
                {
                    _showAddNoteOperation = new RelayCommand(() => this.ShowAddNote());
                }

                return _showAddNoteOperation;
            }
        }

        public ICommand AddNoteOperation
        {
            get
            {
                if (_addNoteOperation == null)
                {
                    _addNoteOperation = new RelayCommand(() => this.AddNote(_nouvelleNoteMatiere, _nouvelleNoteDate, _nouvelleNoteAppreciation, _nouvelleNoteValeur));
                }

                return _addNoteOperation;
            }
        }

        private void EditEleve(Eleve eleve)
        {
            eleve.Nom = Nom;
            eleve.Prenom = Prenom;
            eleve.DateNaissance = DateNaissance;
            Manager.Instance.EditEleve(eleve);
        }

        private void ShowAddNote()
        {
            Visibility = "Visible";
        }

        private void AddNote(string matiere, DateTime date, string appreciation, string valeur)
        {
            int valeurNote = int.Parse(valeur);
            Note note = new Note { Matiere = matiere, DateNote = date, Appreciation = appreciation, ValeurNote = valeurNote, EleveId = _eleve.EleveId };
            Manager.Instance.AddNote(note);
            Moyenne = Manager.Instance.GetAverageByEleveId(_eleve.EleveId);
            Visibility = "Hidden";
        }

        #endregion
    }
}