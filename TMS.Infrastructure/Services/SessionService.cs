using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace DataAccess.Services
{
    public class SessionService
    {
        private readonly IHttpContextAccessor _accessor;

        public SessionService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public bool Set<T>(T value, string key)
        {
            if (value == null || string.IsNullOrEmpty(key))
                return false;

            try
            {
                if (_accessor.HttpContext == null)
                    return false;

                if(typeof(T).BaseType.Name == "Object")
                {
                    _accessor.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
                    return true;
                }

                var converted = Convert.ToString(value);
                _accessor.HttpContext.Session.SetString(key, Convert.ToString(converted));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T? Get<T>(string key)
        {
            try
            {
                if (_accessor.HttpContext == null)
                    return default(T);

                var value = _accessor.HttpContext.Session.GetString(key);

                if (typeof(T).BaseType.Name == "Object")
                {
                    var obj = JsonConvert.DeserializeObject<T>(value);
                    return obj;
                }

                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public bool Delete(string key)
        {
            try
            {
                if (_accessor.HttpContext == null)
                    return false;

                _accessor.HttpContext.Session.Remove(key);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
