using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Service
{
    public class UserService
    {
        public readonly IHttpContextAccessor httpcontext;
        public UserService(IHttpContextAccessor httpcontext)
        {
            this.httpcontext = httpcontext;
        }

        //public string GetUserId()
        //{
        //    return httpcontext.HttpContext.User?.fin
        //}
    }
}
