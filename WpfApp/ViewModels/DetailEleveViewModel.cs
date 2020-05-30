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
        //private RelayCommand _addOperation;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// <param name="eleve">Eleve à transformer en DetailEleveViewModel</param>
        /// </summary>
        public DetailEleveViewModel(Eleve eleve)
        {
            _nom = eleve.Nom;
            _prenom = eleve.Prenom;
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Nom du produit
        /// </summary>
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        /// <summary>
        /// Prenom du produit
        /// </summary>
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        #endregion
    }
}