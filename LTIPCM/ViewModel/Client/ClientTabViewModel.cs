using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LTIPCM.Model;
using LTIPCM.Service;

namespace LTIPCM.ViewModel
{
    public class ClientTabViewModel : ViewModelBase
    {
        private IDataAccessService _dataAccessService;
        private Client _currentClient;
        private Client _originalCurrentClinet;

        public ClientTabViewModel(IDataAccessService dataAccessService, Client currentClient)
        {
            _dataAccessService = dataAccessService;
            _currentClient = currentClient;
            _originalCurrentClinet = (Client)_currentClient.Clone();

            CloseTabCommand = new RelayCommand(closeTab);
            SaveCurrentCommand = new RelayCommand(saveCurrentClient, canSaveCurrentClientExecute);

        }

        #region Property
        public Client CurrentClient
        {
            get { return _currentClient; }
            set
            {
                _currentClient = value;
                RaisePropertyChanged("CurrentClient");
            }
        }
        #endregion

        #region Command Property

        public RelayCommand CloseTabCommand
        {
            get;
            private set;
        }

        public RelayCommand SaveCurrentCommand
        {
            get;
            private set;
        }

        #endregion

        #region Private method

        private void closeTab()
        {
            Messenger.Default.Send<Client>(_currentClient, "CloseClientTabItem");
        }

        private void saveCurrentClient()
        {
            _dataAccessService.SaveClient(CurrentClient);
        }

        private bool canSaveCurrentClientExecute()
        {
            if (_currentClient.ClientID == 0)
                return true;
            if (_currentClient.Address1Chn == _originalCurrentClinet.Address1Chn
                && _currentClient.Address1Eng == _originalCurrentClinet.Address1Eng
                && _currentClient.Address2Chn == _originalCurrentClinet.Address2Chn
                && _currentClient.Address2Eng == _originalCurrentClinet.Address2Eng
                && _currentClient.Fax == _originalCurrentClinet.Fax
                && _currentClient.Email == _originalCurrentClinet.Email
                && _currentClient.Homepage == _originalCurrentClinet.Homepage
                && _currentClient.NameChn == _originalCurrentClinet.NameChn
                && _currentClient.NameEng == _originalCurrentClinet.NameEng
                && _currentClient.Tel1 == _originalCurrentClinet.Tel1
                && _currentClient.Tel2 == _originalCurrentClinet.Tel2
                && _currentClient.Zip == _originalCurrentClinet.Zip
                && _currentClient.CreateTime == _originalCurrentClinet.CreateTime
                && _currentClient.LastModifyTime == _originalCurrentClinet.LastModifyTime)
                return false;
            return true;
        }
        #endregion
    }
}
