using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using testcallLib;
public partial interface iClient
{
    /// <summary>
    /// Баланс клиента
    /// </summary>
    Task<ClientBalance> ClientBalance();
    /// <summary>
    /// публичная информация по клиенту
    /// </summary>
    Task<ClientPublicData> ClientData();
    /// <summary>
    /// Список избранных
    /// </summary>
    Task ClientInfoSet(ClientInfoData data);
    /// <summary>
    /// Персональные данные клиента
    /// </summary>
    Task<ClientPrivateDataOut> PersonalDataGet();
}
