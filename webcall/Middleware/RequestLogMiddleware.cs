
using testcallLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Webtestcall
{
    /// <summary>
    /// Обработчик ошибок
    /// </summary>
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate next;

        public RequestLogMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        /// <summary>
        /// Отправить ошибку во фронт
        /// </summary>
        /// <param name="R"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        async Task SendErrorToFront(HttpResponse R, byte[] data)
        {
            R.StatusCode = 400;
            R.ContentType = "application/json; charset=utf-8";
            await R.Body.WriteAsync(data);
        }

        /// <summary>
        /// Перехват исключений.
        /// в зависимости от типа ошибки , высылаем обратно то что нужно фронту
        /// </summary>
        /// <param name="context"></param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (testcallValidationException exceptWithField)
            {
                await SendErrorToFront(context.Response, exceptWithField.BadResultArray);
            }
            catch (testcallException except)
            {
                await SendErrorToFront(context.Response, except.BadResultArray);
            }
            catch (Exception ee)
            {
                var E = new ErrorData() { errorCode = 1002, errorMessage = ee.Message };
                await SendErrorToFront(context.Response, E.ToBjson());
                //SendErrorContext(context, ee);
            }
        }
        async void SendErrorContext(HttpContext context, Exception e)
        {
            // BUG в 2.2 оно работало , в 3.0 EnableRewind не работает
            var R = context.Request;
            HttpRequestRewindExtensions.EnableBuffering(R);
            //context.Request.EnableRewind();
            //R.Body.Seek(0, SeekOrigin.Begin);
            var buffer = new byte[R.ContentLength.ToInt()];
            await R.Body.ReadAsync(buffer, 0, buffer.Length);
            var s = System.Text.Encoding.UTF8.GetString(buffer);
        }
    }
}
