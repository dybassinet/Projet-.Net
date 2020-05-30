using BusinessLayer;
using Model.Entities;
using System.Collections.ObjectModel;
using System.Linq;
using WpfApp.ViewModels.Common;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// ViewModel permettant de gérer une liste de DetailProduitViewModel
    /// Hérite de BaseViewModel
    /// </summary>
    public class ListeEleveViewModel : BaseViewModel
    {
        #region Variables

        private ObservableCollection<DetailEleveViewModel> _eleves = null;
        private DetailEleveViewModel _selectedEleve;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ListeEleveViewModel()
        {
            // on appelle le mock pour initialiser une liste de produits
            _eleves = new ObservableCollection<DetailEleveViewModel>();
            foreach (Eleve p in Manager.Instance.GetAllEleves())
            {
                _eleves.Add(new DetailEleveViewModel(p));
            }

            if (_eleves != null && _eleves.Count > 0)
                _selectedEleve = _eleves.ElementAt(0);
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Obtient ou définit une collection de DetailEleveViewModel (Observable)
        /// </summary>
        public ObservableCollection<DetailEleveViewModel> Eleves
        {
            get { return _eleves; }
            set
            {
                _eleves = value;
                OnPropertyChanged("Eleves");
            }
        }

        /// <summary>
        /// Obtient ou défini le produit en cours de sélection dans la liste de DetailEleveViewModel
        /// </summary>
        public DetailEleveViewModel SelectedEleve
        {
            get { return _selectedEleve; }
            set
            {
                _selectedEleve = value;
                OnPropertyChanged("SelectedEleve");
            }
        }


        #endregion
    }
}