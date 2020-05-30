using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.ViewModels.Common;

namespace WpfApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Variables

        private ListeEleveViewModel _listeEleveViewModel = null;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public HomeViewModel()
        {
            _listeEleveViewModel = new ListeEleveViewModel();
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Obtient ou définit le ListeEleveViewModel
        /// </summary>
        public ListeEleveViewModel ListeEleveViewModel
        {
            get { return _listeEleveViewModel; }
            set { _listeEleveViewModel = value; }
        }

        #endregion
    }
}