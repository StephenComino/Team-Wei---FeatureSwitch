using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationProvider.Contracts;

namespace ConfigurationProvider
{
    public class PlainEncryption : IEncryptionManager
    {
        public string Encrypt(string contentToEncrypt)
        {
            return contentToEncrypt;
        }

        public string Decrypt(string contentToDecrypt)
        {
            return contentToDecrypt;
        }
    }
}
