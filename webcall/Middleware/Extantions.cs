using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webtestcall
{
    public static class Extantions
    {
        /// <summary>
        /// проверим роль токена
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetRole(this System.Security.Claims.ClaimsPrincipal user)
        {
            return "";
        }
    }
}
