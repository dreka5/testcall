using System;
using System.Collections.Generic;
using System.Text;

namespace testcallLib
{
    public class ErrorList
    {
        public static ErrorData IncorrectPhonePass_100 = new ErrorData() { errorCode = 100, errorMessage = "телефон/пароль не верный" };
        public static ErrorData IncorrectPhone_110 = new ErrorData() { errorCode = 110, errorMessage = "формат телефона не верен" };
        public static ErrorData PhoneExisted_111 = new ErrorData() { errorCode = 111, errorMessage = "номер занят" };
        public static ErrorData PhoneNotExisted_112 = new ErrorData() { errorCode = 112, errorMessage = "нет такого номера" };
        public static ErrorData NoSuchCode_120 = new ErrorData() { errorCode = 120, errorMessage = "нет такого кода" };

        public static ErrorData NotAMail_130 = new ErrorData() { errorCode = 130, errorMessage = "это не почта" };
        public static ErrorData MailExist_131 = new ErrorData() { errorCode = 131, errorMessage = "такая почта уже есть" };
        public static ErrorData PassNotEqval_132 = new ErrorData() { errorCode = 132, errorMessage = "пароли не совпадают" };
        public static ErrorData MailTooBig_133 = new ErrorData() { errorCode = 133, errorMessage = "mail length too big" };


        public static ErrorData AllRight200 = new ErrorData() { errorCode = 200, errorMessage = "всё хорошо" };

        public static ErrorData NoRights_401 = new ErrorData() { errorCode = 401, errorMessage = "нет прав на выполнение этой операции" };
        public static ErrorData NoService_404 = new ErrorData() { errorCode = 404, errorMessage = "нет такого сервиса" };
        public static ErrorData NoConsul_403 = new ErrorData() { errorCode = 403, errorMessage = "нет такого консультанта" };
        public static ErrorData NoFile_405 = new ErrorData() { errorCode = 405, errorMessage = "нет такого файла" };
        public static ErrorData NoClient_406 = new ErrorData() { errorCode = 406, errorMessage = "нет такого клиента" };
        public static ErrorData NoSchedulerCall_407 = new ErrorData() { errorCode = 407, errorMessage = "нет такого звонка в ожидании" };
        public static ErrorData NoCancelReason_408 = new ErrorData() { errorCode = 408, errorMessage = "не хватает причин для отказа консультации" };
        public static ErrorData NoScheduler_409 = new ErrorData() { errorCode = 409, errorMessage = "нет такого расписания" };


        public static ErrorData CantNotSetFeedBack_410 = new ErrorData() { errorCode = 410, errorMessage = "не могу записать фидбэк" };
        public static ErrorData FileTooBig_411 = new ErrorData() { errorCode = 411, errorMessage = "файл слишком велик" };

        public static ErrorData NoTag_412 = new ErrorData() { errorCode = 412, errorMessage = "no this tag" };
        public static ErrorData NoTagInCategory_413 = new ErrorData() { errorCode = 413, errorMessage = "NoTagInCategory" };


        public static ErrorData UnknownError_1001 = new ErrorData() { errorCode = 1001, errorMessage = "1001 error" };
        public static ErrorData UnknownError_1002 = new ErrorData() { errorCode = 1002, errorMessage = "1002 error" };

        public static ErrorData IllegalField_999 = new ErrorData() { errorCode = 999, errorMessage = "ошибка валидации" };

        public static ErrorData NoCategory_501 = new ErrorData() { errorCode = 501, errorMessage = "No Category" };
    }
}
