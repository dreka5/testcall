using System;
using System.Collections.Generic;
using System.Text;

namespace testcallLib
{
    public static class SupportExtantion
    {
        /// <summary>
        /// получаем число из объекта
        /// </summary>
        /// <param name="q"></param>
        public static int ToInt(this object q)
        {
            if (q == null) return 0;
            try
            {
                return Convert.ToInt32(q);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Конвертируем в Byte[] JSON
        /// </summary>
        /// <param name="data"></param>
        public static byte[] ToBjson(this object data)
        {
            return System.Text.Encoding.UTF8.GetBytes(ToJson(data));
        }

        /// <summary>
        /// конвертируем в JSON
        /// </summary>
        /// <param name="data"></param>
        public static string ToJson(this object data)
        {
            if (data==null) return Newtonsoft.Json.JsonConvert.SerializeObject("{}");
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        
        

    }
}
