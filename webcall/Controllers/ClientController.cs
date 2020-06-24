using Webtestcall;
using testcallLib;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Webtestcall
{
    [ApiController]
    [Route(API+ "[controller]")]
    public  partial class ClientController:testcallControllerBase
    {
       
         
        /// <summary>
        /// Баланс клиента
        /// </summary>
 
        [ProducesResponseType(typeof(ErrorData), 400)]
        [ProducesResponseType(typeof(ClientBalance), 200)]
        [HttpGet][Route("client/balance")]
        public async Task <ClientBalance> ClientBalance(  ) =>await Client().ClientBalance();

         
        /// <summary>
        /// публичная информация по клиенту
        /// </summary>
 
        [ProducesResponseType(typeof(ErrorData), 400)]
        [ProducesResponseType(typeof(ClientPublicData), 200)]
        [HttpGet][Route("client/publicdata")]
        public async Task <ClientPublicData> ClientData(  ) =>await Client().ClientData();

         
        /// <summary>
        /// Список избранных
        /// </summary>
 
        [ProducesResponseType(typeof(ErrorData), 400)]
        [ProducesResponseType(typeof(void), 200)]
        [HttpPost][Route("data/set")]
        public async Task  ClientInfoSet( ClientInfoData data) =>await Client().ClientInfoSet(data);

         
        /// <summary>
        /// Персональные данные клиента
        /// </summary>
 
        [ProducesResponseType(typeof(ErrorData), 400)]
        [ProducesResponseType(typeof(ClientPrivateDataOut), 200)]
        [HttpGet][Route("data")]
        public async Task <ClientPrivateDataOut> PersonalDataGet(  ) =>await Client().PersonalDataGet();


    }
}