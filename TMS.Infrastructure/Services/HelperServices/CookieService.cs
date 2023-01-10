using Microsoft.AspNetCore.Http;

namespace TMS.Infrastructure.Services.HelperServices
{
    public class CookieService
    {
        public readonly IHttpContextAccessor _accessor;

        public CookieService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public bool SetCookie(string cookieName, string cookieValue)
        {
            try
            {
                if (_accessor.HttpContext == null)
                    return false;

                _accessor.HttpContext.Response.Cookies.Append(
                cookieName,
                cookieValue,
                new CookieOptions()
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true,
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string? GetCookie(string cookieName)
        {
            try
            {
                if (_accessor.HttpContext == null)
                    return string.Empty;

                string cookie = _accessor.HttpContext.Request.Cookies[cookieName];

                return cookie;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public bool RemoveCookie(string key)
        {
            try
            {
                if (_accessor.HttpContext == null)
                    return false;

                _accessor.HttpContext.Response.Cookies.Delete(key);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
