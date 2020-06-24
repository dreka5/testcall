using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace Webtestcall
{
    public class testcallControllerBase : ControllerBase
    {
        /// <summary>
        /// Базовый API
        /// </summary>

        protected const string API = "api/v1.1/";

        protected testcallLib.Client Client()
        {
            return new testcallLib.Client() { User = User };
        }
    }
}
