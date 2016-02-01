using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using LTIPCM.Model;

namespace LTIPCM.Service
{
    class ServicesDesignTime : IDataAccessService
    {
        static ObservableCollection<Client> _clients;
        static ObservableCollection<Case> _cases;

        static ServicesDesignTime()
        {
            _clients = new ObservableCollection<Client>()
            {
                new Client { NameChn = "测试用户1" }
            };

            _cases = new ObservableCollection<Case>()
            {
                new Case { Name = "测试案件1" }
            };
        }

        #region ClientViewModel related
        public ObservableCollection<Client> GetClients()
        {
            return _clients;
        }

        public int AddClient(Client client)
        {
            _clients.Add(client);
            return 1;
        }

        public void SaveClient(Client client)
        {
            
        }

        public Client GetClient(int clientId)
        {
            var query = (from c in _clients
                         where c.ClientID == clientId
                         select c).FirstOrDefault<Client>();
            return query;
        }
        #endregion

        #region CaseViewModel related
        public ObservableCollection<Case> GetCases()
        {
            return _cases;
        }
        #endregion
    }
}
