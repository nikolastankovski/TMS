using Microsoft.AspNetCore.DataProtection;
using System;

namespace TMS.Infrastructure.Services.HelperServices
{
    public class EncryptService
    {
        private readonly IDataProtector _protector;
        public EncryptService(IDataProtectionProvider dataProtection)
        {
            _protector = dataProtection.CreateProtector("xcR$G^$RZugrQW2zk%Dv");
        }
        public string Encrypt(dynamic value)
        {
            try
            {
                string converted = Convert.ToString(value);
                return _protector.Protect(converted);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public T Decrypt<T>(string value) where T : struct
        {
            try
            {
                return (T)Convert.ChangeType(_protector.Unprotect(value), typeof(T));
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
