using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LTIPCM.Service;
using LTIPCM.Model;

namespace LTIPCM.ViewModel
{
    public class CaseViewModel : ViewModelBase
    {
        private IDataAccessService _dataAccessService;

        private ObservableCollection<Case> _cases;

        public CaseViewModel(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;

            OpenExistedCaseTabCommand = new RelayCommand<Case>(OpenEsistedCaseTab);
        }

        public RelayCommand<Case> OpenExistedCaseTabCommand
        {
            get;
            private set;
        }

        void OpenEsistedCaseTab(Case currentCase)
        {
            throw new NotImplementedException();
        }
    }
}
