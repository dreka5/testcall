using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace testcallLib.Entity
{
    public class Client:BaseEntity
    {
        public async Task Create()
        {

        }
        public async Task SetInfo(ClientInfoData data)
        {
            using (var db = GetDB)
            {
                //.....
            }
        }

        public async Task Balance()
        {
            using (var db = GetDB)
            {
                //.....
            }
        }
    }
}
