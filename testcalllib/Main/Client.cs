using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace testcallLib
{
    public partial class Client : CommonBase, iClient
    {
        public async Task ClientInfoSet(ClientInfoData data) => await CreateClient().SetInfo(data);

       

        public Task<ClientPublicData> ClientData()
        {
            throw new NotImplementedException();
        }

     
        public Task FavoriteRemoveAll()
        {
            throw new NotImplementedException();
        }

        public Task<ClientPrivateDataOut> PersonalDataGet()
        {
            throw new NotImplementedException();
        }

        public Task<ClientBalance> ClientBalance()
        {
            throw new NotImplementedException();
        }
    }
}