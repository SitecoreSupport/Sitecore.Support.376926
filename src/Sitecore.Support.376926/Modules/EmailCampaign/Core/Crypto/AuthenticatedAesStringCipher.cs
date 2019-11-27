using System;
using Sitecore.Diagnostics;
using Sitecore.ExM.Framework.Diagnostics;
using Sitecore.Modules.EmailCampaign.Core.Crypto;

namespace Sitecore.Support.Modules.EmailCampaign.Core.Crypto
{
    public class AuthenticatedAesStringCipher : Sitecore.Modules.EmailCampaign.Core.Crypto.AuthenticatedAesStringCipher, IStringCipher
    {
        public AuthenticatedAesStringCipher(byte[] cryptographicKey, byte[] authenticationKey, ILogger logger) : base(cryptographicKey, authenticationKey, logger)
        {
        }
        public AuthenticatedAesStringCipher(string cryptographicKeyName, string authenticationKeyName, ILogger logger) : base(cryptographicKeyName, authenticationKeyName, logger)
        {
        }

        string IStringCipher.TryDecrypt(string encryptedMessage)
        {
            byte[] buffer;
            Assert.ArgumentNotNull(encryptedMessage, "encryptedMessage");
            try
            {
                buffer = System.Convert.FromBase64String(encryptedMessage);
            }
            catch (FormatException)
            {
                return base.TryDecrypt(encryptedMessage.Replace(" ", "+"));
            }

            return base.TryDecrypt(encryptedMessage);
        }

    }
}