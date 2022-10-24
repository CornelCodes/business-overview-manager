using DAL;
using DAL.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DAL.Helpers
{
    public static class AuthenticationHelper
    {
        public static bool LoggedIn(HttpContext context)
        {
            if (context.User != null && context.User.Claims != null)
            {
                var claims = context.User.Claims;
                return claims.Any(x => x.Type == "id");
            }
            else
            {
                return false;
            }
        }

        public static string GetUserRole(HttpContext context)
        {
            //default is entrant
            return context.User.Claims.FirstOrDefault(x => x.Type == "role").Value ?? "entrant";
        }

        public static bool IsUserAdmin(HttpContext context)
        {
            var claim = context.User.Claims.FirstOrDefault(x => x.Type == "isAdmin").Value;
            //default is entrant
            return claim.ToLower() == "true";
        }

        public static string GetUserId(HttpContext context)
        {
            return context.User.Claims.First(x => x.Type == "id").Value;
        }
    }
}
