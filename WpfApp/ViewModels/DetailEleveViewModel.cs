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
        private string _visibility;
        private int _nouvelleNote;

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
            set { _moyenne = value; }
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

        public int NouvelleNote
        {
            get { return _nouvelleNote; }
            set { _nouvelleNote = value; }
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

        #endregion
    }
}