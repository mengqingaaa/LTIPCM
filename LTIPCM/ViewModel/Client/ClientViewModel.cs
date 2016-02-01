using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LTIPCM.Service;
using LTIPCM.Model;

namespace LTIPCM.ViewModel
{
    public class ClientViewModel : ViewModelBase
    {
        private IDataAccessService _dataAccessService;
        private ViewModelLocator _viewModelLocator;

        private ObservableCollection<Client> _clients;
        private ObservableCollection<ClientTabViewModel> _clientTabVMs;

        private ClientTabViewModel _selectedClientTabItem;

        public ClientViewModel(IDataAccessService dataAccessService, ViewModelLocator viewModelLocator)
        {
            _dataAccessService = dataAccessService;
            _viewModelLocator = viewModelLocator;

            //_clients = new ObservableCollection<Client>();
            //GetClients();
            _clients = _dataAccessService.GetClients();

            OpenExistedClientTabCommand = new RelayCommand<Client>(OpenExistedClientTab);

            // Register the Tab Close Messenger
            Messenger.Default.Register<Client>(this, "CloseClientTabItem", CloseClientTab);
        }

        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                RaisePropertyChanged("Clients");
            }
        }

        public ObservableCollection<ClientTabViewModel> ClientTabVMs
        {
            get
            {
                if (_clientTabVMs == null)
                    _clientTabVMs = new ObservableCollection<ClientTabViewModel>();
                return _clientTabVMs;
            }
            set
            {
                _clientTabVMs = value;
                RaisePropertyChanged("ClientTabVMs");
            }
        }

        public ClientTabViewModel SelectedClientTabItem
        {
            get { return _selectedClientTabItem; }
            set
            {
                _selectedClientTabItem = value;
                RaisePropertyChanged("SelectedClientTabItem");
            }
        }

        public RelayCommand<Client> OpenExistedClientTabCommand
        {
            get;
            private set;
        }

        public RelayCommand OpenNewClientTabCommand
        {
            get;
            private set;
        }

        void GetClients()
        {
            Clients.Clear();
            foreach(var item in _dataAccessService.GetClients())
            {
                Clients.Add(item);
            }
        }


        #region delegation for RelayCommand

        void OpenExistedClientTab(Client client)
        {
            var newTab = (from ctvm in ClientTabVMs
                          where ctvm.CurrentClient.ClientID == client.ClientID
                          select ctvm).FirstOrDefault();
            if (newTab == null)
            {
                newTab = _viewModelLocator.GetClientTabViewModel(client);
                ClientTabVMs.Add(newTab);
            }
            SelectedClientTabItem = newTab;

        }

        void OpenNewClientTab()
        {
            var newClient = new Client();
            this.OpenExistedClientTab(newClient);
        }

        #endregion


        #region delegation for Registration of Messenger

        void CloseClientTab(Client client)
        {
            var currentTab = (from ctvm in ClientTabVMs
                              where ctvm.CurrentClient.ClientID == client.ClientID
                              select ctvm).FirstOrDefault();
            if (currentTab != null)
            {
                ClientTabVMs.Remove(currentTab);
                SelectedClientTabItem = ClientTabVMs.FirstOrDefault();
            }
        }
        #endregion


    }
}
