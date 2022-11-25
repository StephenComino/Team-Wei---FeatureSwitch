using ConfigurationProvider.Contracts;
using System.Security.Cryptography;

namespace ConfigurationProvider
{
    public class RsaEncryption : IEncryptionManager
    {

        public string Encrypt(string contentToEncrypt)
        {
            //try
            //{
            //    byte[] encryptedData;
            //    using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            //    {
            //        RSA.ImportParameters(RSAKey);
            //        encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
            //    }
            //    return encryptedData;
            //}
            //catch (CryptographicException e)
            //{
            //    Console.WriteLine(e.Message);
            //    return null;
            //}
            return null;
        }

        public string Decrypt(string contentToDecrypt)
        {
            //try
            //{
            //    byte[] decryptedData;
            //    using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            //    {
            //        RSA.ImportParameters(RSAKey);
            //        decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
            //    }
            //    return decryptedData;
            //}
            //catch (CryptographicException e)
            //{
            //    Console.WriteLine(e.ToString());
            //    return null;
            //}
            return null;
        }
    }
}
