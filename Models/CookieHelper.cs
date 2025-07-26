using Microsoft.AspNetCore.Http;
using System;

namespace Equinox.Models
{
    public static class CookieHelper
    {
        public static void SetCookie(HttpResponse response, string key, string value, int days = 7)
        {
            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(days)
            };
            response.Cookies.Append(key, value, option);
        }

        public static string? GetCookie(HttpRequest request, string key)
        {
            request.Cookies.TryGetValue(key, out string? value);
            return value;
        }

        public static void RemoveCookie(HttpResponse response, string key)
        {
            response.Cookies.Delete(key);
        }
    }
}