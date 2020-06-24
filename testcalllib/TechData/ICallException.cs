using System;
using System.Collections.Generic;
using System.Text;

namespace testcallLib
{
    /// <summary>
    /// Перехват ошибок логики. не те данные. Защита системы
    /// </summary>
    public class testcallException : Exception
    {
        public ErrorData EData;
        public byte[] BadResultArray;
        public testcallException(ErrorData d)
        {         
            EData = d;
            BadResultArray = d.ToBjson();
        }
    }
    /// <summary>
    /// Перехват ошибки валидации
    /// </summary>
    public class testcallValidationException : Exception
    {
        public class ValidErrorData : ErrorData
        {
            public string fieldName;
        }
        public byte[] BadResultArray;
        public testcallValidationException(string fieldName, string errorMessage)
        {
            BadResultArray = new ValidErrorData()
            {
                fieldName = fieldName,
                errorMessage = errorMessage,
                errorCode = 300
            }.ToBjson();
        }
    }
}
