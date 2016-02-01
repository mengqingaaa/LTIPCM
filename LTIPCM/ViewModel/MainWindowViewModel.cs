using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LTIPCM.Service;

namespace LTIPCM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IDataAccessService _dataAccessService;
        private ViewModelLocator _viewModelLocator;

        private ViewModelBase _currentViewModel;

        public MainWindowViewModel(IDataAccessService dataAccessService, ViewModelLocator viewModelLocator)
        {
            _dataAccessService = dataAccessService;
            _viewModelLocator = viewModelLocator;

            OpenClientManagerCommand = new RelayCommand(SetCurrentVMToClientVM);
        }

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if ( _currentViewModel != value )
                {
                    _currentViewModel = value;
                    RaisePropertyChanged("CurrentViewModel");
                }
            }
        }

        public RelayCommand OpenClientManagerCommand
        {
            get;
            private set;
        }

        void SetCurrentVMToClientVM()
        {
            CurrentViewModel = _viewModelLocator.ClientViewModel; 
        }

    }
}
