//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace testcallLib
{
    public class VoxImplant
    {
        //public static int CreateUser(string id, string name, string pass)
        //{
          
        //    var parametres = new Dictionary<string, string>
        //    {
        //        { "application_id", VOX.applicationId},
        //        { "user_name", id},
        //        { "user_display_name", name},
        //        { "user_password", pass},
        //    };
        //    var restult = MakeVoxImplantPostRequest("AddUser", parametres);
        //    if (restult.StatusCode != System.Net.HttpStatusCode.OK)
        //    {
        //        throw new Exception("Ошибка создания пользователя системы связи.");
        //    }
        //    return 0;
        //}


        public static void SendSMS(string message, string phone)
        {

            var parametres = new Dictionary<string, string>
            {
                { "source", VOX.smsPhone},
                { "destination", phone},
                { "sms_body", message},
            };

            var result = MakeVoxImplantPostRequest("SendSmsMessage", parametres);
            var content = result.Content.ReadAsStringAsync();
            content.Wait();

            //var status = JsonConvert.DeserializeObject<SendMessageStatus>(content.Result);

            //if (status.result != 1)
            //{
            //    throw new Exception("Ошибка отправки смс.");
            //}
        }
        public static HttpResponseMessage MakeVoxImplantPostRequest(string method, Dictionary<string, string> parametres)
        {
            using (MultipartFormDataContent httpParams = new MultipartFormDataContent())
            {
                foreach (var p in parametres)
                {
                    httpParams.Add(new StringContent(p.Value), p.Key);
                }
                return Post(method, httpParams);
            }
        }



        static HttpResponseMessage Post(string method, MultipartFormDataContent data)
        {
            string uri = $"https://api.voximplant.com/platform_api/{method}";
            data.Add(new StringContent(VOX.accountId), "account_id");
            data.Add(new StringContent(VOX.apiKey), "api_key");

            using (HttpClient client = new HttpClient())
            {
                var task = client.PostAsync(uri, data);
                task.Wait();
                return task.Result;
            }
        }
        public static VoxData VOX = new VoxData();

        //public static async Task<VoxPhoneNumber[]> GetNewPhoneNumbers()
        //{
        //    // 177 msk, 132 spb коды регионовов
        //    var region = "132";
        //    var parametres = new Dictionary<string, string>()
        //    {
        //          { "phone_region_id", region},
        //          { "country_code", "RU"},
        //          { "phone_category_name","MOBILE" },
        //          { "application_id", VOX.applicationId}
        //    };
        //    var restult = MakeVoxImplantPostRequest("GetNewPhoneNumbers", parametres);
        //    var res = await restult.Content.ReadAsStringAsync();
        //    var arr = res.JSON<VoxPhoneNumberHolder>();
        //    return arr.result;
        //}
    }
    public class VoxData
    {
        internal string accountId = "2991333000";
        internal string apiKey = "6710sadfsdfff6a-4323327d4-46sdafsd83-9d9f-b996ab7ff156";
        internal string Scenario_CallWithCode = "26905435303";
        internal string applicationId = "436534";
        internal string smsPhone = "79581043202735";   //"79581006851";
    }
    class SendMessageStatus
    {
        public int result = 0;
        public int fragments_count = 0;
    }
}
